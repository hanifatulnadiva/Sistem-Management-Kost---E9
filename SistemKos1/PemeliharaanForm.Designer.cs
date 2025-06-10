
using System.Windows.Forms;

namespace SistemKos1
{
    partial class PemeliharaanForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPemeliharaan;
        private System.Windows.Forms.TextBox txtIdPemeliharaan;
        private System.Windows.Forms.ComboBox cmbIdKamar;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.NumericUpDown numBiaya;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblIdPemeliharaan;
        private System.Windows.Forms.Label lblIdKamar;
        private System.Windows.Forms.Label lblDeskripsi;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblBiaya;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPemeliharaan = new System.Windows.Forms.DataGridView();
            this.txtIdPemeliharaan = new System.Windows.Forms.TextBox();
            this.cmbIdKamar = new System.Windows.Forms.ComboBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.numBiaya = new System.Windows.Forms.NumericUpDown();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();

            this.lblIdPemeliharaan = new System.Windows.Forms.Label();
            this.lblIdKamar = new System.Windows.Forms.Label();
            this.lblDeskripsi = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblBiaya = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPemeliharaan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBiaya)).BeginInit();
            this.SuspendLayout();

            // Label & Input Field
            this.lblIdPemeliharaan.Text = "ID Pemeliharaan:";
            this.lblIdPemeliharaan.Location = new System.Drawing.Point(20, 20);
            this.txtIdPemeliharaan.Location = new System.Drawing.Point(150, 20);
            this.txtIdPemeliharaan.Width = 150;

            this.lblIdKamar.Text = "ID Kamar:";
            this.lblIdKamar.Location = new System.Drawing.Point(20, 60);
            this.cmbIdKamar.Location = new System.Drawing.Point(150, 60);
            this.cmbIdKamar.Width = 150;

            this.lblDeskripsi.Text = "Deskripsi:";
            this.lblDeskripsi.Location = new System.Drawing.Point(20, 100);
            this.txtDeskripsi.Location = new System.Drawing.Point(150, 100);
            this.txtDeskripsi.Width = 300;

            this.lblTanggal.Text = "Tanggal:";
            this.lblTanggal.Location = new System.Drawing.Point(20, 140);
            this.dtpTanggal.Location = new System.Drawing.Point(150, 140);

            this.lblBiaya.Text = "Biaya:";
            this.lblBiaya.Location = new System.Drawing.Point(20, 180);
            this.numBiaya.Location = new System.Drawing.Point(150, 180);
            this.numBiaya.Maximum = 10000000;

            // Buttons
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Location = new System.Drawing.Point(20, 220);
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);

            this.btnUpdate.Text = "Update";
            this.btnUpdate.Location = new System.Drawing.Point(120, 220);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnHapus.Text = "Hapus";
            this.btnHapus.Location = new System.Drawing.Point(220, 220);
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(320, 220);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.Location = new System.Drawing.Point(420, 220);
            this.btnAnalyze.Click += new System.EventHandler(this.BtnAnalyze_Click);

            // DataGridView
            this.dgvPemeliharaan.Location = new System.Drawing.Point(20, 260);
            this.dgvPemeliharaan.Size = new System.Drawing.Size(600, 200);
            this.dgvPemeliharaan.ReadOnly = true;
            this.dgvPemeliharaan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            // Form
            this.ClientSize = new System.Drawing.Size(650, 480);
            this.Controls.Add(this.lblIdPemeliharaan);
            this.Controls.Add(this.txtIdPemeliharaan);
            this.Controls.Add(this.lblIdKamar);
            this.Controls.Add(this.cmbIdKamar);
            this.Controls.Add(this.lblDeskripsi);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.lblBiaya);
            this.Controls.Add(this.numBiaya);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.dgvPemeliharaan);
            this.Text = "Form Pemeliharaan";
            this.Load += new System.EventHandler(this.PemeliharaanForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPemeliharaan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBiaya)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

