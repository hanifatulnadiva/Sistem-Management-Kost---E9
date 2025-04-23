using System.Windows.Forms;

namespace SistemKos1
{
    partial class PemeliharaanForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblIdPemeliharaan;
        private System.Windows.Forms.Label lblIdKamar;
        private System.Windows.Forms.Label lblDeskripsi;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblBiaya;
        private System.Windows.Forms.TextBox txtIdPemeliharaan;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.NumericUpDown numBiaya;
        private System.Windows.Forms.ComboBox cmbIdKamar;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvPemeliharaan;

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
            this.lblIdPemeliharaan = new System.Windows.Forms.Label();
            this.lblIdKamar = new System.Windows.Forms.Label();
            this.lblDeskripsi = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblBiaya = new System.Windows.Forms.Label();
            this.txtIdPemeliharaan = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.numBiaya = new System.Windows.Forms.NumericUpDown();
            this.cmbIdKamar = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvPemeliharaan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numBiaya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemeliharaan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdPemeliharaan
            // 
            this.lblIdPemeliharaan.AutoSize = true;
            this.lblIdPemeliharaan.Location = new System.Drawing.Point(20, 20);
            this.lblIdPemeliharaan.Name = "lblIdPemeliharaan";
            this.lblIdPemeliharaan.Size = new System.Drawing.Size(88, 13);
            this.lblIdPemeliharaan.TabIndex = 0;
            this.lblIdPemeliharaan.Text = "ID Pemeliharaan:";
            // 
            // lblIdKamar
            // 
            this.lblIdKamar.AutoSize = true;
            this.lblIdKamar.Location = new System.Drawing.Point(20, 60);
            this.lblIdKamar.Name = "lblIdKamar";
            this.lblIdKamar.Size = new System.Drawing.Size(54, 13);
            this.lblIdKamar.TabIndex = 1;
            this.lblIdKamar.Text = "ID Kamar:";
            // 
            // lblDeskripsi
            // 
            this.lblDeskripsi.AutoSize = true;
            this.lblDeskripsi.Location = new System.Drawing.Point(20, 100);
            this.lblDeskripsi.Name = "lblDeskripsi";
            this.lblDeskripsi.Size = new System.Drawing.Size(53, 13);
            this.lblDeskripsi.TabIndex = 2;
            this.lblDeskripsi.Text = "Deskripsi:";
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(20, 140);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(49, 13);
            this.lblTanggal.TabIndex = 3;
            this.lblTanggal.Text = "Tanggal:";
            // 
            // lblBiaya
            // 
            this.lblBiaya.AutoSize = true;
            this.lblBiaya.Location = new System.Drawing.Point(20, 180);
            this.lblBiaya.Name = "lblBiaya";
            this.lblBiaya.Size = new System.Drawing.Size(36, 13);
            this.lblBiaya.TabIndex = 4;
            this.lblBiaya.Text = "Biaya:";
            // 
            // txtIdPemeliharaan
            // 
            this.txtIdPemeliharaan.Location = new System.Drawing.Point(150, 20);
            this.txtIdPemeliharaan.Name = "txtIdPemeliharaan";
            this.txtIdPemeliharaan.Size = new System.Drawing.Size(200, 20);
            this.txtIdPemeliharaan.TabIndex = 5;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Location = new System.Drawing.Point(150, 100);
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(200, 20);
            this.txtDeskripsi.TabIndex = 6;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(150, 140);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggal.TabIndex = 7;
            // 
            // numBiaya
            // 
            this.numBiaya.DecimalPlaces = 2;
            this.numBiaya.Location = new System.Drawing.Point(150, 180);
            this.numBiaya.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBiaya.Name = "numBiaya";
            this.numBiaya.Size = new System.Drawing.Size(200, 20);
            this.numBiaya.TabIndex = 8;
            // 
            // cmbIdKamar
            // 
            this.cmbIdKamar.FormattingEnabled = true;
            this.cmbIdKamar.Location = new System.Drawing.Point(150, 60);
            this.cmbIdKamar.Name = "cmbIdKamar";
            this.cmbIdKamar.Size = new System.Drawing.Size(200, 21);
            this.cmbIdKamar.TabIndex = 9;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(20, 220);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(100, 30);
            this.btnSimpan.TabIndex = 10;
            this.btnSimpan.Text = "Add";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(250, 220);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(368, 220);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 30);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Delete";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(136, 220);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Read";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvPemeliharaan
            // 
            this.dgvPemeliharaan.Location = new System.Drawing.Point(20, 260);
            this.dgvPemeliharaan.MultiSelect = false;
            this.dgvPemeliharaan.Name = "dgvPemeliharaan";
            this.dgvPemeliharaan.ReadOnly = true;
            this.dgvPemeliharaan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPemeliharaan.Size = new System.Drawing.Size(430, 200);
            this.dgvPemeliharaan.TabIndex = 0;
            this.dgvPemeliharaan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPemeliharaan_CellClick);
            // 
            // PemeliharaanForm
            // 
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Controls.Add(this.dgvPemeliharaan);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.cmbIdKamar);
            this.Controls.Add(this.numBiaya);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.txtIdPemeliharaan);
            this.Controls.Add(this.lblBiaya);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.lblDeskripsi);
            this.Controls.Add(this.lblIdKamar);
            this.Controls.Add(this.lblIdPemeliharaan);
            this.Name = "PemeliharaanForm";
            this.Text = "Form Pemeliharaan";
            this.Load += new System.EventHandler(this.PemeliharaanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBiaya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemeliharaan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
