using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            SetupReportViewer();
        }

        private void SetupReportViewer()
        {
            // Koneksi ke database
            string connectionString = "Data Source=HANIFATUL-NADIV\\HANIFA; Initial Catalog=SistemManagementKost; Integrated Security=True";

            // Query SQL gabungan
            string query = @"
                SELECT 
                    p.NIK,
                    p.nama,
                    p.kontak,
                    p.tanggal_masuk,
                    p.tanggal_keluar,
                    k.id_kamar,
                    k.harga AS harga_kamar,
                    k.status AS status_kamar,
                    pb.id_pembayaran,
                    pb.tanggal_pembayaran,
                    pb.jumlah AS jumlah_pembayaran,
                    pb.metode_pembayaran
                FROM 
                    pembayaran pb
                JOIN 
                    penyewa p ON pb.NIK = p.NIK
                LEFT JOIN 
                    kamar k ON p.NIK = k.NIK
                ORDER BY 
                    pb.tanggal_pembayaran DESC";

            // Ambil data dan tampilkan ke report
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                // Set data source untuk report
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Path ke file .rdlc (pastikan sesuai)
                reportViewer1.LocalReport.ReportPath = @"D:\Basis Data\PABD\ucp1\Sistem-Management-Kost---E9-master\Sistem-Management-Kost---E9-master\SistemKos1\kostreport.rdlc";

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load report: " + ex.Message);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // Tidak perlu isi jika tidak digunakan
        }
    }
}
