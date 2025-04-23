using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class PenyewaForm : Form
    {
        string connectionString = "Server=localhost;Database=SistemManagementKost;Trusted_Connection=True;";

        public PenyewaForm()
        {
            InitializeComponent();
            dataGridViewPenyewa.CellClick += dataGridViewPenyewa_CellClick;
        }

        private void PenyewaForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM penyewa";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewPenyewa.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private bool ValidasiInput(out string error)
        {
            error = "";
            string NIK = txtNIK.Text;
            string kontak = txtKontak.Text;

            if (string.IsNullOrWhiteSpace(NIK) || string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(kontak))
            {
                error = "Please fill in all fields.";
                return false;
            }

            if (NIK.Length != 16 || !NIK.All(char.IsDigit))
            {
                error = "NIK must be exactly 16 digits.";
                return false;
            }

            if (!kontak.All(char.IsDigit) || kontak.Length < 12 || kontak.Length > 13)
            {
                error = "Kontak must be numeric and between 12 to 13 digits.";
                return false;
            }

            return true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput(out string error))
            {
                MessageBox.Show(error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO penyewa (NIK, nama, kontak, tanggal_masuk) VALUES (@NIK, @nama, @kontak, @tanggalMasuk)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@kontak", txtKontak.Text);
                cmd.Parameters.Add("@tanggalMasuk", SqlDbType.Date).Value = dtpTanggalMasuk.Value.Date;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data berhasil ditambahkan.");
                LoadData();
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM penyewa WHERE NIK = @NIK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNama.Text = reader["nama"].ToString();
                    txtKontak.Text = reader["kontak"].ToString();
                    dtpTanggalMasuk.Value = Convert.ToDateTime(reader["tanggal_masuk"]);
                }
                else
                {
                    MessageBox.Show("Penyewa tidak ditemukan.");
                }
                reader.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput(out string error))
            {
                MessageBox.Show(error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE penyewa SET nama = @nama, kontak = @kontak, tanggal_masuk = @tanggalMasuk WHERE NIK = @NIK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@kontak", txtKontak.Text);
                cmd.Parameters.Add("@tanggalMasuk", SqlDbType.Date).Value = dtpTanggalMasuk.Value.Date;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data penyewa berhasil diperbarui.");
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNIK.Text))
            {
                MessageBox.Show("Isi NIK terlebih dahulu untuk menghapus.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM penyewa WHERE NIK = @NIK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NIK", txtNIK.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data penyewa berhasil dihapus.");
                LoadData();
            }
        }

        private void dataGridViewPenyewa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPenyewa.Rows[e.RowIndex];
                txtNIK.Text = row.Cells["NIK"].Value.ToString();
                txtNama.Text = row.Cells["nama"].Value.ToString();
                txtKontak.Text = row.Cells["kontak"].Value.ToString();
                dtpTanggalMasuk.Value = Convert.ToDateTime(row.Cells["tanggal_masuk"].Value);
            }
        }

        private void lblKontak_Click(object sender, EventArgs e)
        {
            // Kosong, jika tidak digunakan
        }
    }
}