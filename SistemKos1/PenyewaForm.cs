using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Cms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Windows.Forms;


namespace SistemKos1
{
    public partial class PenyewaForm : Form
    {

        string connectionString = "Server=HANIFATUL-NADIV\\HANIFA; Database=SistemManagementKost;Trusted_Connection=True;";
        ObjectCache _cache = MemoryCache.Default;
        string CacheKey = "PenyewaData";
        CacheItemPolicy _policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };

        public PenyewaForm()
        {
            InitializeComponent();
            dataGridViewPenyewa.CellClick += dataGridViewPenyewa_CellClick;
        }

        private void PenyewaForm_Load(object sender, EventArgs e)
        {
            dtpTanggalMasuk.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTanggalMasuk.MaxDate = DateTime.Now.AddYears(1);
            dtpTanggalKeluar.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTanggalKeluar.MaxDate = DateTime.Now.AddYears(1);
            LoadData();
            EnsureIndexes();
        }

        private void LoadData()
        {
            DataTable dt;

            if (_cache.Contains(CacheKey))
            {
                dt = _cache.Get(CacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                try
                {
                    using (var conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        var query = "SELECT * FROM penyewa";
                        var da = new SqlDataAdapter(query, conn);
                        da.Fill(dt);
                        _cache.Add(CacheKey, dt, _policy);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dataGridViewPenyewa.AutoGenerateColumns = true;
            dataGridViewPenyewa.DataSource = dt;
        }



        private bool ValidasiInput(out string error)
        {
            error = "";
            string NIK = txtNIK.Text.Trim();
            string nama = txtNama.Text.Trim();
            string kontak = txtKontak.Text.Trim();

            if (string.IsNullOrWhiteSpace(NIK) || string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(kontak))
            {
                error = "Semua field harus diisi.";
                return false;
            }

            if (NIK.Any(c => !char.IsDigit(c)))
            {
                error = "NIK hanya boleh berisi angka.";
                return false;
            }


            if (NIK.Length != 16 || !NIK.All(char.IsDigit))
            {
                error = "NIK harus terdiri dari 16 digit angka.";
                return false;
            }

            if (NIK.Any(c => !char.IsDigit(c)))
            {
                error = "NIK hanya boleh berisi angka.";
                return false;
            }

            if (!char.IsLetter(nama[0])) // Memastikan nama diawali dengan huruf
            {
                error = "Nama harus diawali dengan huruf.";
                return false;
            }

            if (!nama.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '\'' || c == '-'))
            {
                error = "Nama hanya boleh berisi huruf, spasi, apostrof ('), dan strip (-).";
                return false;
            }

            if (!kontak.All(char.IsDigit) || kontak.Length < 12 || kontak.Length > 13)
            {
                error = "Kontak harus berupa angka dan terdiri dari 12 hingga 13 digit.";
                return false;
            }
            if (!kontak.StartsWith("08"))
            {
                error = "Kontak harus diawali dengan 08.";
                return false;
            }

            return true;
        }

        private void ClearCache()
        {
            if (_cache.Contains(CacheKey))
                _cache.Remove(CacheKey);
        }

        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                    IF OBJECT_ID('dbo.Penyewa', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_penyewa_nama')
                            CREATE NONCLUSTERED INDEX idx_penyewa_nama ON dbo.penyewa(nama);
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_penyewa_kontak')
                            CREATE NONCLUSTERED INDEX idx_penyewa_kontak ON dbo.penyewa(kontak);
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_penyewa_tanggal_masuk')
                            CREATE NONCLUSTERED INDEX idx_penyewa_tanggal_masuk ON dbo.penyewa(tanggal_masuk);
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_penyewa_tanggal_keluar')
                            CREATE NONCLUSTERED INDEX idx_penyewa_tanggal_keluar ON dbo.penyewa(tanggal_keluar)   
                    END";
                using(var cmd=new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.FireInfoMessageEventOnUserErrors = true;

                conn.InfoMessage += Conn_InfoMessage;

                conn.Open();

                var wrapped = $@"
            SET STATISTICS IO ON;
            SET STATISTICS TIME ON;
            {sqlQuery};
            SET STATISTICS IO OFF;
            SET STATISTICS TIME OFF;
        ";

                using (var cmd = new SqlCommand(wrapped, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    {
                        while (reader.Read())
                        {
                            // Bisa proses data jika ingin
                        }
                    } while (reader.NextResult());
                }
            }
        }

        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError info in e.Errors)
            {
                MessageBox.Show(info.Message, "STATISTICS INFO");
            }
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
                SqlTransaction transaction = null;

                try
                {

                    conn.Open();
                    transaction = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand("AddPenyewa", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@kontak", txtKontak.Text.Trim());
                        cmd.Parameters.Add("@tanggal_masuk", SqlDbType.Date).Value = dtpTanggalMasuk.Value.Date;
                        cmd.Parameters.Add("@tanggal_keluar", SqlDbType.Date).Value = dtpTanggalKeluar.Value.Date;

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    _cache.Remove(CacheKey);

                    MessageBox.Show("Data berhasil ditambahkan.");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Terjadi kesalahan:" + ex.Message);
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewPenyewa.SelectedRows.Count == 0)
            {
                MessageBox.Show("pilih data yng ingin diubah!", "peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidasiInput(out string error))
            {
                MessageBox.Show(error);
                return;
            }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdatePenyewa", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                            cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                            cmd.Parameters.AddWithValue("@kontak", txtKontak.Text.Trim());
                            cmd.Parameters.Add("@tanggal_masuk", SqlDbType.Date).Value = dtpTanggalMasuk.Value.Date;
                            cmd.Parameters.Add("@tanggal_keluar", SqlDbType.Date).Value = dtpTanggalKeluar.Value.Date;

                        int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                             _cache.Remove(CacheKey);
                             MessageBox.Show("data berhasil diperbarui!", "sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                                ClearForm();
                            }
                            else
                            {
                                MessageBox.Show("data tidak ditemukan atau gagal diperbarui!", "kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error:" + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridViewPenyewa.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("yakin ingin meghapus data ini?","konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string NIK = dataGridViewPenyewa.SelectedRows[0].Cells["NIK"].Value.ToString();
                            conn.Open();
                            // Panggil stored procedure untuk hapus data
                            using (SqlCommand cmd = new SqlCommand("DeletePenyewa", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@NIK", NIK);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    _cache.Remove(CacheKey);
                                    MessageBox.Show("data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                    ClearForm();
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                dtpTanggalKeluar.Value = Convert.ToDateTime(row.Cells["tanggal_keluar"].Value);
            }
        }



        private void lblKontak_Click(object sender, EventArgs e)
        {
            // Kosong, jika tidak digunakan
        }

        private void ClearForm()
        {
            txtNIK.Clear();
            txtNama.Clear();
            txtKontak.Clear();
            dataGridViewPenyewa.ClearSelection();

        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT * FROM penyewa";
            AnalyzeQuery(sqlQuery);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files|*.xlsx; *.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                PreviewData(filePath);//display privie before importing
            }
        }
        private void PreviewData(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs); //membuka workbook excel
                    ISheet sheet = workbook.GetSheetAt(0); //mendapatkan worksheet pertama
                    DataTable dt = new DataTable();

                    //membaca header kolom
                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }
                    //membaca sisa data 
                    for (int i = 1; i <= sheet.LastRowNum; i++) //lewati baris header
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                        {
                            newRow[cellIndex] = cell.ToString();
                            cellIndex++;
                        }
                        dt.Rows.Add(newRow);
                    }
                    //membuka priviewdata  dan mengirimkan datatable ke form yang tersebut
                    preview previewForm = new preview(dt);
                    previewForm.ShowDialog(); //tampilkan preview data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
                
                LoadData();

                // Debugging: Cek jumlah kolom dan baris
                MessageBox.Show(
                    $"Jumlah Kolom: {dataGridViewPenyewa.ColumnCount}\nJumlah Baris: {dataGridViewPenyewa.RowCount}",
                    "Debugging DataGridView",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            
        }
    }
}