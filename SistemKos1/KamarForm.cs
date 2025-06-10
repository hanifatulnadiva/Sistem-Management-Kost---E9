using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Caching;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class KamarForm : Form
    {
        private string connectionString = "Server=HANIFATUL-NADIV\\HANIFA;Database=SistemManagementKost;Trusted_Connection=True;";
        MemoryCache cache = MemoryCache.Default;
        string cacheKey = "KamarData";
        CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };

        public KamarForm()
        {
            InitializeComponent();
        }

        private void KamarForm_Load(object sender, EventArgs e)
        {
            EnsureKamarIndexes();
            cmbStatus.Items.AddRange(new object[] { "tersedia", "disewa" });
            cmbStatus.SelectedIndex = 0;
            LoadPenyewaData();
            LoadData();
        }

        private void EnsureKamarIndexes()
        {
            string[] queries =
            {
                @"IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Kamar_Status' AND object_id = OBJECT_ID('dbo.kamar')) BEGIN CREATE NONCLUSTERED INDEX idx_Kamar_Status ON dbo.kamar(status); END",
                @"IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Kamar_NIK' AND object_id = OBJECT_ID('dbo.kamar')) BEGIN CREATE NONCLUSTERED INDEX idx_Kamar_NIK ON dbo.kamar(NIK); END",
                @"IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Kamar_Harga' AND object_id = OBJECT_ID('dbo.kamar')) BEGIN CREATE NONCLUSTERED INDEX idx_Kamar_Harga ON dbo.kamar(harga); END"
            };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (string query in queries)
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private void LoadPenyewaData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT NIK, nama FROM penyewa";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbPenyewa.DataSource = dt;
                cmbPenyewa.DisplayMember = "nama";
                cmbPenyewa.ValueMember = "NIK";
            }
        }

        private void LoadData()
        {
            if (cache.Contains(cacheKey))
            {
                dataGridViewKamar.DataSource = cache[cacheKey] as DataTable;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += Conn_InfoMessage;
                SqlCommand cmd = new SqlCommand("SET STATISTICS IO ON; SET STATISTICS TIME ON; SELECT * FROM kamar;", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                cache.Set(cacheKey, dt, policy);
                dataGridViewKamar.DataSource = dt;
            }
        }

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show("STATISTICS:\n" + e.Message);
        }

        private void InvalidateCache()
        {
            if (cache.Contains(cacheKey)) cache.Remove(cacheKey);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string idKamar = txtIdKamar.Text.Trim();
                string hargaText = txtHarga.Text.Trim();

                if (string.IsNullOrEmpty(idKamar) || idKamar.Length != 5)
                {
                    MessageBox.Show("ID Kamar harus 5 karakter.");
                    return;
                }

                if (!decimal.TryParse(hargaText, out decimal harga) || harga <= 0)
                {
                    MessageBox.Show("Harga harus berupa angka dan >0.");
                    return;
                }

                string nik = cmbPenyewa.SelectedValue?.ToString();
                string status = string.IsNullOrWhiteSpace(nik) ? "tersedia" : "disewa";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_CreateKamar", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_kamar", idKamar);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@NIK", string.IsNullOrWhiteSpace(nik) ? (object)DBNull.Value : nik);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();

                        InvalidateCache();
                        LoadData();
                        ClearForm();
                        MessageBox.Show("Kamar berhasil ditambahkan.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Transaksi gagal: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan umum: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string idKamar = txtIdKamar.Text.Trim();
                string hargaText = txtHarga.Text.Trim();

                if (string.IsNullOrEmpty(idKamar) || idKamar.Length != 5)
                {
                    MessageBox.Show("ID Kamar harus 5 karakter.");
                    return;
                }

                if (!decimal.TryParse(hargaText, out decimal harga) || harga <= 0)
                {
                    MessageBox.Show("Harga harus berupa angka positif dan >0.");
                    return;
                }

                string nik = cmbPenyewa.SelectedValue?.ToString();
                string status = string.IsNullOrWhiteSpace(nik) ? "tersedia" : "disewa";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_UpdateKamar", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_kamar", idKamar);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@NIK", string.IsNullOrWhiteSpace(nik) ? (object)DBNull.Value : nik);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();

                        InvalidateCache();
                        LoadData();
                        ClearForm();
                        MessageBox.Show("Kamar diperbarui.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Transaksi gagal: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan umum: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string idKamar = txtIdKamar.Text.Trim();
                if (string.IsNullOrWhiteSpace(idKamar))
                {
                    MessageBox.Show("Pilih kamar yang akan dihapus.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_DeleteKamar", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_kamar", idKamar);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();

                        InvalidateCache();
                        LoadData();
                        ClearForm();
                        MessageBox.Show("Kamar dihapus.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Transaksi gagal: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan umum: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InvalidateCache();
            LoadData();

            // Debugging: Cek jumlah kolom dan baris
            MessageBox.Show(
                $"Jumlah Kolom: {dataGridViewKamar.ColumnCount}\nJumlah Baris: {dataGridViewKamar.RowCount}",
                "Debugging DataGridView",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void ClearForm()
        {
            txtIdKamar.Clear();
            txtHarga.Clear();
            cmbStatus.SelectedIndex = 0;
            cmbPenyewa.SelectedIndex = -1;
            dataGridViewKamar.ClearSelection();
        }

        private void dataGridViewKamar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewKamar.Rows[e.RowIndex];
                txtIdKamar.Text = row.Cells["id_kamar"].Value.ToString();
                txtHarga.Text = row.Cells["harga"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["status"].Value.ToString();
                cmbPenyewa.SelectedValue = row.Cells["NIK"].Value == DBNull.Value ? "" : row.Cells["NIK"].Value.ToString();
            }
        }

        private void dataGridViewKamar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewKamar.Columns[e.ColumnIndex].Name == "status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "disewa") e.CellStyle.BackColor = Color.Green;
                else if (status == "tersedia") e.CellStyle.BackColor = Color.Red;
            }
        }

        private void cmbPenyewa_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            AnalyzeQueryPerformance();
        }

        private void AnalyzeQueryPerformance()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.FireInfoMessageEventOnUserErrors = true;
                    conn.InfoMessage += (s, e) =>
                    {
                        MessageBox.Show("STATISTICS:\n" + e.Message, "Query Analysis");
                    };

                    string analyzeQuery = @"
                        SET NOCOUNT ON;
                        SET STATISTICS IO ON;
                        SET STATISTICS TIME ON;
                        SELECT COUNT(*) FROM kamar;
                    ";

                    using (SqlCommand cmd = new SqlCommand(analyzeQuery, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan saat menganalisis query: " + ex.Message);
            }
        }
    }
}
