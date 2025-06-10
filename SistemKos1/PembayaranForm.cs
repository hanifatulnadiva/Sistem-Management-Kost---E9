using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class PembayaranForm : Form
    {
        private string connectionString = "Server=HANIFATUL-NADIV\\HANIFA;Database=SistemManagementKost;Trusted_Connection=True;";


        public PembayaranForm()
        {
            InitializeComponent();
        }

        private void PembayaranForm_Load(object sender, EventArgs e)
        {
            LoadNIKs();
            LoadData();
            cmbMetodePembayaran.Items.AddRange(new string[] { "Tunai", "Transfer" });

            numJumlah.Maximum = 1000000000;
            numJumlah.Minimum = 0;
        }

        private void LoadNIKs()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT NIK FROM Penyewa";
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM pembayaran";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewPembayaran.DataSource = dt;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtIdPembayaran.Text.Length != 5)
            {
                MessageBox.Show("ID Pembayaran harus terdiri dari 5 karakter.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
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
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Gagal menyimpan data pembayaran: " + ex.Message);
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

            using (SqlConnection conn = new SqlConnection(connectionString))
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

            using (SqlConnection conn = new SqlConnection(connectionString))
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
            using (var conn = new SqlConnection(connectionString))
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