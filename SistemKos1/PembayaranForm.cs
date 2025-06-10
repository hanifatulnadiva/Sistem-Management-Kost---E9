using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class PembayaranForm : Form
    {
        string connectionString = "Server=localhost;Database=SistemManagementKost;Trusted_Connection=True;";

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

            dtpTanggalPembayaran.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
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

            if (numJumlah.Value == 0)
            {
                MessageBox.Show("Jumlah pembayaran tidak boleh 0.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO pembayaran (id_pembayaran, NIK, tanggal_pembayaran, jumlah, metode_pembayaran) " +
                                   "VALUES (@id_pembayaran, @NIK, @tanggal_pembayaran, @jumlah, @metode_pembayaran)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtIdPembayaran.Text);
                        cmd.Parameters.AddWithValue("@NIK", cmbNIK.SelectedValue);
                        cmd.Parameters.AddWithValue("@tanggal_pembayaran", dtpTanggalPembayaran.Value.Date);
                        cmd.Parameters.AddWithValue("@jumlah", numJumlah.Value);
                        cmd.Parameters.AddWithValue("@metode_pembayaran", cmbMetodePembayaran.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data pembayaran berhasil disimpan.");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtIdPembayaran.Text.Length != 5)
            {
                MessageBox.Show("ID Pembayaran harus terdiri dari 5 karakter.");
                return;
            }

            if (numJumlah.Value == 0)
            {
                MessageBox.Show("Jumlah pembayaran tidak boleh 0.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE pembayaran SET NIK=@NIK, tanggal_pembayaran=@tanggal_pembayaran, jumlah=@jumlah, metode_pembayaran=@metode_pembayaran WHERE id_pembayaran=@id_pembayaran";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_pembayaran", txtIdPembayaran.Text);
                cmd.Parameters.AddWithValue("@NIK", cmbNIK.SelectedValue);
                cmd.Parameters.AddWithValue("@tanggal_pembayaran", dtpTanggalPembayaran.Value.Date);
                cmd.Parameters.AddWithValue("@jumlah", numJumlah.Value);
                cmd.Parameters.AddWithValue("@metode_pembayaran", cmbMetodePembayaran.SelectedItem.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data pembayaran berhasil diperbarui.");
                LoadData();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM pembayaran WHERE id_pembayaran=@id_pembayaran";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_pembayaran", txtIdPembayaran.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data pembayaran berhasil dihapus.");
                LoadData();
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

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }
    }
}