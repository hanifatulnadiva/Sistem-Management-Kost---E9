using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Caching;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class PemeliharaanForm : Form
    {
        private string connectionString = "Server=HANIFATUL-NADIV\\HANIFA; Database=SistemManagementKost;Trusted_Connection=True;";
        private MemoryCache cache = MemoryCache.Default;
        private string cacheKey = "PemeliharaanCache";
        private CacheItemPolicy cachePolicy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };

        public PemeliharaanForm()
        {
            InitializeComponent();
        }

        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(txtIdPemeliharaan.Text) || txtIdPemeliharaan.Text.Length != 5)
            {
                MessageBox.Show("ID Pemeliharaan harus terdiri dari 5 karakter.");
                return false;
            }
            if (cmbIdKamar.SelectedIndex == -1 || cmbIdKamar.SelectedValue.ToString().Length != 5)
            {
                MessageBox.Show("ID Kamar harus dipilih dan terdiri dari 5 karakter.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDeskripsi.Text))
            {
                MessageBox.Show("Deskripsi tidak boleh kosong.");
                return false;
            }
            if (numBiaya.Value <= 0)
            {
                MessageBox.Show("Biaya harus lebih besar dari 0.");
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            try
            {
                if (cache.Contains(cacheKey))
                {
                    dgvPemeliharaan.DataSource = (DataTable)cache.Get(cacheKey);
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT TOP 100 id_pemeliharaan, id_kamar, deskripsi, tanggal, biaya FROM pemeliharaan ORDER BY tanggal DESC";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPemeliharaan.DataSource = dt;
                        cache.Set(cacheKey, dt, cachePolicy);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("AddPemeliharaan", conn, trans))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pemeliharaan", txtIdPemeliharaan.Text);
                        cmd.Parameters.AddWithValue("@id_kamar", cmbIdKamar.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text);
                        cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value.Date);
                        cmd.Parameters.AddWithValue("@biaya", numBiaya.Value);

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    cache.Remove(cacheKey);
                    MessageBox.Show("Data pemeliharaan berhasil disimpan.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("UpdatePemeliharaan", conn, trans))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pemeliharaan", txtIdPemeliharaan.Text);
                        cmd.Parameters.AddWithValue("@id_kamar", cmbIdKamar.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text);
                        cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value.Date);
                        cmd.Parameters.AddWithValue("@biaya", numBiaya.Value);

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    cache.Remove(cacheKey);
                    MessageBox.Show("Data pemeliharaan berhasil diperbarui.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Terjadi kesalahan saat memperbarui: " + ex.Message);
                }
            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPemeliharaan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus.");
                return;
            }

            string idPemeliharaan = dgvPemeliharaan.SelectedRows[0].Cells["id_pemeliharaan"].Value.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DeletePemeliharaan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pemeliharaan", idPemeliharaan);
                        cmd.ExecuteNonQuery();
                    }
                    cache.Remove(cacheKey);
                    MessageBox.Show("Data pemeliharaan berhasil dihapus.");
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        // Fungsi untuk merefresh tampilan DataGridView
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();

            // Debugging: Cek jumlah kolom dan baris
            MessageBox.Show(
                $"Jumlah kolom: {dgvPemeliharaan.ColumnCount}\nJumlah baris: {dgvPemeliharaan.RowCount}",
                "Debugging DataGridView",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void LoadComboBoxKamar()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_kamar FROM kamar";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbIdKamar.DataSource = dt;
                    cmbIdKamar.DisplayMember = "id_kamar";
                    cmbIdKamar.ValueMember = "id_kamar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data kamar: " + ex.Message);
            }
        }

        private void PemeliharaanForm_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadComboBoxKamar();
            LoadData();
            dtpTanggal.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTanggal.MaxDate = DateTime.Now.AddYears(1);
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");
                conn.Open();

                // Tampilkan data ke DataGridView
                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPemeliharaan.DataSource = dt;
                }

                // Jalankan statistik performa
                string wrapped = $@"
            SET STATISTICS IO ON;
            SET STATISTICS TIME ON;

            {sqlQuery}

            SET STATISTICS IO OFF;
            SET STATISTICS TIME OFF;
        ";

                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void BtnAnalyze_Click(object sender, EventArgs e)
        {

            string heavyQuery = @"
        SELECT 
            id_kamar, 
            COUNT(*) AS jumlah_perbaikan, 
            SUM(biaya) AS total_biaya, 
            MAX(tanggal) AS terakhir_diperbaiki
        FROM pemeliharaan
        GROUP BY id_kamar
        ORDER BY total_biaya DESC;
    ";

            AnalyzeQuery(heavyQuery);
        }

        private void ClearForm()
        {
            txtIdPemeliharaan.Clear();
            cmbIdKamar.SelectedIndex = -1;
            txtDeskripsi.Clear();
            dtpTanggal.Value = DateTime.Now;
            numBiaya.Value = numBiaya.Minimum; // atau bisa juga di-set ke 0
        }

    }
}

