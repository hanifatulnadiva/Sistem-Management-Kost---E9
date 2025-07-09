using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class PembayaranForm : Form
    {
        //private string connectionString = "Server=HANIFATUL-NADIV\\HANIFA;Database=SistemManagementKost;Trusted_Connection=True;";
        Koneksi kn = new Koneksi();
        string strKonek = "";

        public PembayaranForm()
        {
            InitializeComponent();
            strKonek = kn.connectionString();
        }

        private void PembayaranForm_Load(object sender, EventArgs e)
        {
            LoadNIKs();
            LoadData();
            cmbMetodePembayaran.Items.AddRange(new string[] { "Tunai", "Transfer" });
            dtpTanggalPembayaran.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTanggalPembayaran.MaxDate = DateTime.Now.AddYears(1);

            numJumlah.Maximum = 1000000000;
            numJumlah.Minimum = 500000;
        }

        private void LoadNIKs()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(kn.connectionString()))
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT p.NIK 
                        FROM Penyewa p
                        JOIN kamar k ON p.NIK = k.NIK
                        WHERE k.NIK IS NOT NULL";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbNIK.DisplayMember = "NIK";
                    cmbNIK.ValueMember = "NIK";
                    cmbNIK.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat NIK: " + ex.Message);
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                string query = "SELECT * FROM pembayaran";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewPembayaran.DataSource = dt;
            }
        }

        private void EnsurePembayaranIndexes()
        {
            string[] queries = {
        // Index untuk NIK
        @"IF NOT EXISTS (
            SELECT 1 FROM sys.indexes 
            WHERE name = 'idx_pembayaran_NIK' AND object_id = OBJECT_ID('dbo.pembayaran')
        )
        BEGIN
            CREATE NONCLUSTERED INDEX idx_pembayaran_NIK ON dbo.pembayaran (NIK);
        END",

        // Index untuk tanggal_pembayaran
        @"IF NOT EXISTS (
            SELECT 1 FROM sys.indexes 
            WHERE name = 'idx_pembayaran_tanggal' AND object_id = OBJECT_ID('dbo.pembayaran')
        )
        BEGIN
            CREATE NONCLUSTERED INDEX idx_pembayaran_tanggal ON dbo.pembayaran (tanggal_pembayaran);
        END",

        // Index untuk metode_pembayaran
        @"IF NOT EXISTS (
            SELECT 1 FROM sys.indexes 
            WHERE name = 'idx_pembayaran_metode' AND object_id = OBJECT_ID('dbo.pembayaran')
        )
        BEGIN
            CREATE NONCLUSTERED INDEX idx_pembayaran_metode ON dbo.pembayaran (metode_pembayaran);
        END"
    };

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                conn.Open();
                foreach (string query in queries)
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
        }

        // Fungsi pembantu untuk mendapatkan harga kamar berdasarkan NIK
        private decimal GetHargaKamarByNIK(string nik)
        {
            decimal hargaKamar = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(kn.connectionString()))
                {
                    conn.Open();
                    // Query untuk mendapatkan harga kamar dari tabel 'kamar' berdasarkan NIK penyewa
                    // Asumsi: Setiap NIK penyewa hanya menempati satu kamar pada satu waktu
                    // dan kolom NIK di tabel kamar terisi untuk kamar yang disewa.
                    string queryHargaKamar = "SELECT harga FROM kamar WHERE NIK = @NIK";
                    using (SqlCommand cmdHarga = new SqlCommand(queryHargaKamar, conn))
                    {
                        cmdHarga.Parameters.AddWithValue("@NIK", nik);
                        object result = cmdHarga.ExecuteScalar();
                        if (result != null && decimal.TryParse(result.ToString(), out hargaKamar))
                        {
                            return hargaKamar;
                        }
                        else
                        {
                            // NIK tidak ditemukan di tabel kamar, atau harga tidak valid
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa harga kamar: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Mengembalikan -1 sebagai indikator error
            }
        }


        private void cmbNIK_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pastikan ada item yang terpilih dan itu bukan item placeholder (jika ada)
            if (cmbNIK.SelectedValue != null && cmbNIK.SelectedIndex != -1)
            {
                string selectedNIK = cmbNIK.SelectedValue.ToString();
                decimal hargaKamar = GetHargaKamarByNIK(selectedNIK);

                if (hargaKamar != -1) // Jika harga kamar berhasil didapatkan
                {
                    numJumlah.Value = hargaKamar;
                }
                else
                {

                    MessageBox.Show("Harga kamar tidak dapat ditemukan untuk NIK ini. Silakan periksa data kamar.");
                    numJumlah.Value = numJumlah.Minimum;
                }
            }
            else
            {
                numJumlah.Value = numJumlah.Minimum; // Reset jika tidak ada NIK yang terpilih
            }
        }
        // --- Akhir Event Handler Baru ---

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtIdPembayaran.Text.Length != 5)
            {
                MessageBox.Show("ID Pembayaran harus terdiri dari 5 karakter.");
                return;
            }

            string selectedNIK = cmbNIK.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(selectedNIK))
            {
                MessageBox.Show("NIK penyewa belum dipilih.");
                return;
            }


            decimal hargaKamar = GetHargaKamarByNIK(selectedNIK);

            if (hargaKamar == -1)
            {
                return;
            }

            if (numJumlah.Value != hargaKamar)
            {
                MessageBox.Show($"Jumlah pembayaran seharusnya ({hargaKamar:C}). Data tidak dapat disimpan.", "Validasi Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("addPembayaran", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtIdPembayaran.Text);
                        cmd.Parameters.AddWithValue("@NIK", cmbNIK.SelectedValue);
                        cmd.Parameters.AddWithValue("@tanggal_pembayaran", dtpTanggalPembayaran.Value.Date);
                        cmd.Parameters.AddWithValue("@jumlah", numJumlah.Value);
                        cmd.Parameters.AddWithValue("@metode_pembayaran", cmbMetodePembayaran.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Data pembayaran berhasil disimpan.");
                    LoadData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    tran.Rollback();

                    if (ex.Number == 2627) // PRIMARY KEY violation
                    {
                        MessageBox.Show("ID Pembayaran sudah digunakan. Silakan gunakan ID yang lain.", "Duplikasi ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan data pembayaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtIdPembayaran.Text.Length != 5)
            {
                MessageBox.Show("ID Pembayaran harus terdiri dari 5 karakter.");
                return;
            }

            string selectedNIK = cmbNIK.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(selectedNIK))
            {
                MessageBox.Show("NIK penyewa belum dipilih.");
                return;
            }


            decimal hargaKamar = GetHargaKamarByNIK(selectedNIK);

            if (hargaKamar == -1)
            {
                return;
            }


            if (numJumlah.Value != hargaKamar)
            {
                MessageBox.Show($"Jumlah pembayaran seharusnya ({hargaKamar:C}). Data tidak dapat diperbarui.", "Validasi Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("UpdatePembayaran", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtIdPembayaran.Text);
                        cmd.Parameters.AddWithValue("@NIK", cmbNIK.SelectedValue);
                        cmd.Parameters.AddWithValue("@tanggal_pembayaran", dtpTanggalPembayaran.Value.Date);
                        cmd.Parameters.AddWithValue("@jumlah", numJumlah.Value);
                        cmd.Parameters.AddWithValue("@metode_pembayaran", cmbMetodePembayaran.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Data pembayaran berhasil diperbarui.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Gagal memperbarui data pembayaran: " + ex.Message);
                }
            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPembayaran.Text))
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("DeletePembayaran", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtIdPembayaran.Text);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Data pembayaran berhasil dihapus.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Gagal menghapus data pembayaran: " + ex.Message);
                }
            }
        }


        private void dataGridViewPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPembayaran.Rows[e.RowIndex];
                txtIdPembayaran.Text = row.Cells["id_pembayaran"].Value.ToString();
                cmbNIK.SelectedValue = row.Cells["NIK"].Value.ToString();
                dtpTanggalPembayaran.Value = Convert.ToDateTime(row.Cells["tanggal_pembayaran"].Value);

                decimal jumlah = Convert.ToDecimal(row.Cells["jumlah"].Value);
                if (jumlah >= numJumlah.Minimum && jumlah <= numJumlah.Maximum)
                {
                    numJumlah.Value = jumlah;
                }
                else
                {
                    numJumlah.Value = numJumlah.Maximum;
                    MessageBox.Show($"Jumlah {jumlah} melebihi batas maksimum. Nilai diatur ke maksimum ({numJumlah.Maximum}).");
                }

                cmbMetodePembayaran.SelectedItem = row.Cells["metode_pembayaran"].Value.ToString();
            }
        }

        private void BtnAnalyze_Click(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT id_pembayaran, NIK, jumlah FROM dbo.pembayaran WHERE jumlah > 1000000";
            AnalyzeQuery(heavyQuery);
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(kn.connectionString()))
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");
                conn.Open();
                var wrapped = $@"
                SET STATISTICS IO ON;
                SET STATISTICS TIME ON;
                {sqlQuery}
                SET STATISTICS IO OFF;
                SET STATISTICS TIME OFF;";
                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();      // Reload dari database
            ClearForm();     // Reset form input

            // Debugging: Cek jumlah kolom dan baris
            MessageBox.Show(
                $"Jumlah Kolom: {dataGridViewPembayaran.ColumnCount}\nJumlah Baris: {dataGridViewPembayaran.RowCount}",
                "Debugging DataGridView",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void ClearForm()
        {
            txtIdPembayaran.Clear();
            cmbNIK.SelectedIndex = -1;
            dtpTanggalPembayaran.Value = DateTime.Today;
            numJumlah.Value = numJumlah.Minimum;
            cmbMetodePembayaran.SelectedIndex = -1;
        }


        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }


    }
}