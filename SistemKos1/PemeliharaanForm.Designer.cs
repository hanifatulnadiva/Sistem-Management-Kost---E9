
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
            // 
            // dgvPemeliharaan
            // 
            this.dgvPemeliharaan.ColumnHeadersHeight = 34;
            this.dgvPemeliharaan.Location = new System.Drawing.Point(20, 260);
            this.dgvPemeliharaan.Name = "dgvPemeliharaan";
            this.dgvPemeliharaan.ReadOnly = true;
            this.dgvPemeliharaan.RowHeadersWidth = 62;
            this.dgvPemeliharaan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPemeliharaan.Size = new System.Drawing.Size(600, 200);
            this.dgvPemeliharaan.TabIndex = 15;
            // 
            // txtIdPemeliharaan
            // 
            this.txtIdPemeliharaan.Location = new System.Drawing.Point(150, 20);
            this.txtIdPemeliharaan.Name = "txtIdPemeliharaan";
            this.txtIdPemeliharaan.Size = new System.Drawing.Size(300, 26);
            this.txtIdPemeliharaan.TabIndex = 1;
            // 
            // cmbIdKamar
            // 
            this.cmbIdKamar.Location = new System.Drawing.Point(150, 60);
            this.cmbIdKamar.Name = "cmbIdKamar";
            this.cmbIdKamar.Size = new System.Drawing.Size(300, 28);
            this.cmbIdKamar.TabIndex = 3;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Location = new System.Drawing.Point(150, 100);
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(300, 26);
            this.txtDeskripsi.TabIndex = 5;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(150, 140);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(300, 26);
            this.dtpTanggal.TabIndex = 7;
            // 
            // numBiaya
            // 
            this.numBiaya.Location = new System.Drawing.Point(150, 180);
            this.numBiaya.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numBiaya.Name = "numBiaya";
            this.numBiaya.Size = new System.Drawing.Size(300, 26);
            this.numBiaya.TabIndex = 9;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(20, 220);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 10;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(120, 220);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(220, 220);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(320, 220);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(420, 220);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 14;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.Click += new System.EventHandler(this.BtnAnalyze_Click);
            // 
            // lblIdPemeliharaan
            // 
            this.lblIdPemeliharaan.Location = new System.Drawing.Point(20, 20);
            this.lblIdPemeliharaan.Name = "lblIdPemeliharaan";
            this.lblIdPemeliharaan.Size = new System.Drawing.Size(100, 23);
            this.lblIdPemeliharaan.TabIndex = 0;
            this.lblIdPemeliharaan.Text = "ID Pemeliharaan:";
            // 
            // lblIdKamar
            // 
            this.lblIdKamar.Location = new System.Drawing.Point(20, 60);
            this.lblIdKamar.Name = "lblIdKamar";
            this.lblIdKamar.Size = new System.Drawing.Size(100, 23);
            this.lblIdKamar.TabIndex = 2;
            this.lblIdKamar.Text = "ID Kamar:";
            // 
            // lblDeskripsi
            // 
            this.lblDeskripsi.Location = new System.Drawing.Point(20, 100);
            this.lblDeskripsi.Name = "lblDeskripsi";
            this.lblDeskripsi.Size = new System.Drawing.Size(100, 23);
            this.lblDeskripsi.TabIndex = 4;
            this.lblDeskripsi.Text = "Deskripsi:";
            // 
            // lblTanggal
            // 
            this.lblTanggal.Location = new System.Drawing.Point(20, 140);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(100, 23);
            this.lblTanggal.TabIndex = 6;
            this.lblTanggal.Text = "Tanggal:";
            // 
            // lblBiaya
            // 
            this.lblBiaya.Location = new System.Drawing.Point(20, 180);
            this.lblBiaya.Name = "lblBiaya";
            this.lblBiaya.Size = new System.Drawing.Size(100, 23);
            this.lblBiaya.TabIndex = 8;
            this.lblBiaya.Text = "Biaya:";
            // 
            // PemeliharaanForm
            // 
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
            this.Name = "PemeliharaanForm";
            this.Text = "Form Pemeliharaan";
            this.Load += new System.EventHandler(this.PemeliharaanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemeliharaan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBiaya)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

