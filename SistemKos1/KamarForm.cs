using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class KamarForm : Form
    {
        string connectionString = "Server=localhost;Database=SistemManagementKost;Trusted_Connection=True;";

        public KamarForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string idKamar = txtIdKamar.Text.Trim();
            if (idKamar.Length != 5)
            {
                MessageBox.Show("ID Kamar harus terdiri dari 5 karakter.");
                return;
            }

            decimal harga;
            bool isHargaValid = decimal.TryParse(txtHarga.Text, out harga);
            string status = cmbStatus.SelectedItem?.ToString();
            string nikPenyewa = cmbPenyewa.SelectedValue?.ToString();

            if (string.IsNullOrWhiteSpace(nikPenyewa))
            {
                status = "tersedia";
            }
            else
            {
                status = "disewa";
            }

            if (string.IsNullOrWhiteSpace(idKamar) || harga <= 0 || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill in all fields and ensure valid data.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(nikPenyewa))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(*) FROM kamar WHERE NIK = @nik AND status = 'disewa'";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@nik", nikPenyewa);

                    conn.Open();
                    int count = (int)checkCmd.ExecuteScalar();
                    conn.Close();

                    if (count > 0)
                    {
                        MessageBox.Show("Penyewa ini sudah menyewa kamar lain.");
                        return;
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO kamar (id_kamar, harga, status, NIK) VALUES (@idKamar, @harga, @status, @nik)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idKamar", idKamar);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@nik", string.IsNullOrWhiteSpace(nikPenyewa) ? DBNull.Value : (object)nikPenyewa);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Kamar berhasil ditambahkan.");
                LoadData();
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string idKamar = txtIdKamar.Text;

            if (string.IsNullOrWhiteSpace(idKamar))
            {
                MessageBox.Show("Please enter a valid Kamar ID.");
                return;
            }

            string query = "SELECT * FROM kamar WHERE id_kamar = @idKamar";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idKamar", idKamar);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtHarga.Text = reader["harga"].ToString();
                    cmbStatus.SelectedItem = reader["status"].ToString();
                    cmbPenyewa.SelectedValue = reader["NIK"];
                }
                else
                {
                    MessageBox.Show("Kamar tidak ditemukan.");
                }
                reader.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string idKamar = txtIdKamar.Text.Trim();
            if (idKamar.Length != 5)
            {
                MessageBox.Show("ID Kamar harus terdiri dari 5 karakter.");
                return;
            }

            decimal harga;
            bool isHargaValid = decimal.TryParse(txtHarga.Text, out harga);
            string status = cmbStatus.SelectedItem?.ToString();
            string nikPenyewa = cmbPenyewa.SelectedValue?.ToString();

            if (string.IsNullOrWhiteSpace(nikPenyewa))
            {
                status = "tersedia";
            }
            else
            {
                status = "disewa";
            }

            if (string.IsNullOrWhiteSpace(idKamar) || harga <= 0 || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill in all fields and ensure valid data.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(nikPenyewa))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(*) FROM kamar WHERE NIK = @nik AND status = 'disewa' AND id_kamar != @idKamar";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@nik", nikPenyewa);
                    checkCmd.Parameters.AddWithValue("@idKamar", idKamar);

                    conn.Open();
                    int count = (int)checkCmd.ExecuteScalar();
                    conn.Close();

                    if (count > 0)
                    {
                        MessageBox.Show("Penyewa ini sudah menyewa kamar lain.");
                        return;
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE kamar SET harga = @harga, status = @status, NIK = @nik WHERE id_kamar = @idKamar";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idKamar", idKamar);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@nik", string.IsNullOrWhiteSpace(nikPenyewa) ? DBNull.Value : (object)nikPenyewa);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Kamar berhasil diperbarui.");
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string idKamar = txtIdKamar.Text;

            if (string.IsNullOrWhiteSpace(idKamar))
            {
                MessageBox.Show("Please enter a valid Kamar ID.");
                return;
            }

            string query = "DELETE FROM kamar WHERE id_kamar = @idKamar";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idKamar", idKamar);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Kamar berhasil dihapus.");
                LoadData();
            }
        }

        private void LoadData()
        {
            string query = "SELECT * FROM kamar";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewKamar.DataSource = dt;
            }
        }

        private void LoadPenyewaData()
        {
            string query = "SELECT NIK, Nama FROM penyewa";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbPenyewa.DataSource = dt;
                cmbPenyewa.DisplayMember = "Nama";
                cmbPenyewa.ValueMember = "NIK";
            }
        }

        private void KamarForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(new object[] { "tersedia", "disewa" });
            cmbStatus.SelectedIndex = 0;
            LoadPenyewaData();
            LoadData();
        }

        private void dataGridViewKamar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewKamar.Rows[e.RowIndex];
                txtIdKamar.Text = row.Cells["id_kamar"].Value.ToString();
                txtHarga.Text = row.Cells["harga"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["status"].Value.ToString();
                cmbPenyewa.SelectedValue = row.Cells["NIK"].Value.ToString();
            }
        }

        private void dataGridViewKamar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewKamar.Columns[e.ColumnIndex].Name == "status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status == "disewa")
                    {
                        e.CellStyle.BackColor = Color.Green;
                    }
                    else if (status == "tersedia")
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
