using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemKos1
{
    public partial class PemeliharaanForm : Form
    {
        private string connectionString = "Server=localhost;Database=SistemManagementKost;Trusted_Connection=True;";

        public PemeliharaanForm()
        {
            InitializeComponent();
        }

        // Fungsi untuk validasi input
        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(txtIdPemeliharaan.Text))
            {
                MessageBox.Show("ID Pemeliharaan tidak boleh kosong.");
                return false;
            }
            if (cmbIdKamar.SelectedIndex == -1)
            {
                MessageBox.Show("ID Kamar harus dipilih.");
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

            // Validasi panjang ID Kamar
            string selectedKamar = cmbIdKamar.SelectedValue.ToString();
            if (selectedKamar.Length != 5)
            {
                MessageBox.Show("ID Kamar harus terdiri dari 5 karakter.");
                return false;
            }

            return true;
        }

        // Fungsi untuk load data ke DataGridView
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM pemeliharaan";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPemeliharaan.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (!ValidasiInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO pemeliharaan (id_pemeliharaan, id_kamar, deskripsi, tanggal, biaya) " +
                                   "VALUES (@id_pemeliharaan, @id_kamar, @deskripsi, @tanggal, @biaya)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@id_pemeliharaan", SqlDbType.Char, 5).Value = txtIdPemeliharaan.Text;
                        cmd.Parameters.Add("@id_kamar", SqlDbType.Char, 5).Value = cmbIdKamar.SelectedValue.ToString();
                        cmd.Parameters.Add("@deskripsi", SqlDbType.VarChar, 200).Value = txtDeskripsi.Text;
                        cmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = dtpTanggal.Value.Date;
                        cmd.Parameters.Add("@biaya", SqlDbType.Decimal).Value = numBiaya.Value;

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data pemeliharaan berhasil disimpan.");
                    LoadData(); // Load ulang data ke DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (!ValidasiInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE pemeliharaan SET id_kamar = @id_kamar, deskripsi = @deskripsi, tanggal = @tanggal, biaya = @biaya " +
                                   "WHERE id_pemeliharaan = @id_pemeliharaan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@id_pemeliharaan", SqlDbType.Char, 5).Value = txtIdPemeliharaan.Text;
                        cmd.Parameters.Add("@id_kamar", SqlDbType.Char, 5).Value = cmbIdKamar.SelectedValue.ToString();
                        cmd.Parameters.Add("@deskripsi", SqlDbType.VarChar, 200).Value = txtDeskripsi.Text;
                        cmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = dtpTanggal.Value.Date;
                        cmd.Parameters.Add("@biaya", SqlDbType.Decimal).Value = numBiaya.Value;

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data pemeliharaan berhasil diperbarui.");
                    LoadData(); // Load ulang data ke DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            // Pastikan ada data yang dipilih
            if (dgvPemeliharaan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus.");
                return;
            }

            try
            {
                string idPemeliharaan = dgvPemeliharaan.SelectedRows[0].Cells[0].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM pemeliharaan WHERE id_pemeliharaan = @id_pemeliharaan";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@id_pemeliharaan", SqlDbType.Char, 5).Value = idPemeliharaan;

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data pemeliharaan berhasil dihapus.");
                    LoadData(); // Load ulang data ke DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData(); // Load data ke DataGridView
        }

        private void dgvPemeliharaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Mengambil data yang dipilih di DataGridView dan mengisi field input
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPemeliharaan.Rows[e.RowIndex];
                txtIdPemeliharaan.Text = row.Cells[0].Value.ToString();
                cmbIdKamar.SelectedValue = row.Cells[1].Value.ToString();
                txtDeskripsi.Text = row.Cells[2].Value.ToString();
                dtpTanggal.Value = Convert.ToDateTime(row.Cells[3].Value);
                numBiaya.Value = Convert.ToDecimal(row.Cells[4].Value);
            }
        }

        // Fungsi untuk load combo box ID Kamar
        private void LoadComboBoxKamar()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_kamar FROM kamar"; // Ganti dengan tabel kamar yang sesuai
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

        // Fungsi load data saat form pertama kali dibuka
        private void PemeliharaanForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxKamar(); // Memuat data kamar ke combo box
            LoadData(); // Memuat data pemeliharaan ke DataGridView
        }
    }
}
