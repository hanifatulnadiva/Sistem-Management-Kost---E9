using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Cms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace SistemKos1
{
    public partial class PenyewaForm : Form
    {
        Koneksi kn = new Koneksi();
        string strKonek = "";

        //string connectionString = "Server=HANIFATUL-NADIV\\HANIFA; Database=SistemManagementKost;Trusted_Connection=True;";
        ObjectCache _cache = MemoryCache.Default;
        string CacheKey = "PenyewaData";
        CacheItemPolicy _policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };

        private StringBuilder analysisLog = new StringBuilder();

        public PenyewaForm()
        {
            InitializeComponent();
            strKonek = kn.connectionString();
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
            SqlConnection conn = new SqlConnection(kn.connectionString());
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
                   // using (var conn = new SqlConnection(kn.connectionString))
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
            DateTime tanggalMasuk = dtpTanggalMasuk.Value.Date;
            DateTime tanggalKeluar = dtpTanggalKeluar.Value.Date;
            int totalBulan = ((tanggalKeluar.Year - tanggalMasuk.Year) * 12) + (tanggalKeluar.Month - tanggalMasuk.Month);

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

            if ((tanggalKeluar - tanggalMasuk).TotalDays < 30 ||
            ((tanggalKeluar - tanggalMasuk).TotalDays % 30 != 0))
            {
                double totalHari = (tanggalKeluar - tanggalMasuk).TotalDays;
                int sisaHari = 30 - ((int)totalHari % 30);
                DateTime tanggalBenar = tanggalMasuk.AddDays(((int)(totalHari / 30) + 1) * 30);

                error = $"Tanggal keluar harus kelipatan 30 hari (1 bulan) setelah tanggal masuk.\n" +
                        $"seharusnya tanggal keluar pada: {tanggalBenar:dd MMMM yyyy}";
                return false;
            }


            return true;
        }

        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(kn.connectionString()))
            {
                conn.Open();
                var indexScript = @"
                    IF OBJECT_ID('dbo.penyewa', 'U') IS NOT NULL
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
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError info in e.Errors)
            {
                analysisLog.AppendLine(info.Message);
            }
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            analysisLog.Clear(); 
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            try
            {
                using (var conn = new SqlConnection(kn.connectionString()))
                {
                    conn.FireInfoMessageEventOnUserErrors = true;
                    conn.InfoMessage += Conn_InfoMessage;
                    conn.Open();

                    string wrappedQuery = $@"
                SET STATISTICS IO ON;
                SET STATISTICS TIME ON;
                {sqlQuery};
                SET STATISTICS IO OFF;
                SET STATISTICS TIME OFF;
            ";

                    using (var cmd = new SqlCommand(wrappedQuery, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) { }
                        while (reader.NextResult()) { }
                    }
                }

                stopwatch.Stop();
                double elapsedMs = stopwatch.Elapsed.TotalMilliseconds;

                analysisLog.AppendLine($"\nTotal waktu aplikasi: {elapsedMs:0.00} ms");

                if (elapsedMs > 3000)
                    analysisLog.AppendLine("⚠️ Waktu eksekusi melebihi batas ideal (3 detik)");
                else
                    analysisLog.AppendLine("✅ Waktu eksekusi dalam batas ideal");

                MessageBox.Show(analysisLog.ToString(), "Hasil Analisis Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menganalisis query: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput(out string error))
            {
                MessageBox.Show(error);
                return;
            }
            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
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
                catch (Exception )
                {
                    transaction?.Rollback();
                    MessageBox.Show(
                        "Terjadi duplikasi data saat menyimpan data. Silakan cek kembali input Anda atau hubungi admin jika masalah terus terjadi.",
                        "Gagal Menyimpan Data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewPenyewa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidasiInput(out string error))
            {
                MessageBox.Show(error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); 

                try
                {
                    using (SqlCommand cmd = new SqlCommand("UpdatePenyewa", conn, transaction))
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
                            transaction.Commit(); 
                            _cache.Remove(CacheKey);
                            MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearForm();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Data tidak ditemukan atau gagal diperbarui!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback(); 
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show("Rollback error: " + rollbackEx.Message, "Kesalahan Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPenyewa.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(kn.connectionString()))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction(); 

                        try
                        {
                            string NIK = dataGridViewPenyewa.SelectedRows[0].Cells["NIK"].Value.ToString();

                            using (SqlCommand cmd = new SqlCommand("DeletePenyewa", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@NIK", NIK);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    transaction.Commit(); 
                                    _cache.Remove(CacheKey);
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                    ClearForm();
                                }
                                else
                                {
                                    transaction.Rollback(); 
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                transaction.Rollback(); 
                            }
                            catch (Exception rollbackEx)
                            {
                                MessageBox.Show("Rollback error: " + rollbackEx.Message, "Kesalahan Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(CacheKey);
            LoadData();

    
                MessageBox.Show(
                $"Jumlah Kolom: {dataGridViewPenyewa.ColumnCount}\nJumlah Baris: {dataGridViewPenyewa.RowCount}",
                "Debugging DataGridView",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }



        private void PreviewData(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs); 
                    ISheet sheet = workbook.GetSheetAt(0); 
                    DataTable dt = new DataTable();

                    
                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }
                 
                    for (int i = 1; i <= sheet.LastRowNum; i++) 
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
                    
                    preview previewForm = new preview(dt);
                    previewForm.ShowDialog(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files|*.xlsx; *.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                PreviewData(filePath);
            }
        }
    }
}