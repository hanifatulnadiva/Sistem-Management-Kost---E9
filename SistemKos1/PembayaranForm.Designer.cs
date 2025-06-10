using System;
using System.Windows.Forms;

namespace SistemKos1
{
    partial class PembayaranForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbNIK;
        private DateTimePicker dtpTanggalPembayaran;
        private NumericUpDown numJumlah;
        private ComboBox cmbMetodePembayaran;
        private DataGridView dataGridViewPembayaran;
        private Button btnSimpan;
        private Button btnUpdate;
        private Button btnHapus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbNIK = new System.Windows.Forms.ComboBox();
            this.dtpTanggalPembayaran = new System.Windows.Forms.DateTimePicker();
            this.numJumlah = new System.Windows.Forms.NumericUpDown();
            this.cmbMetodePembayaran = new System.Windows.Forms.ComboBox();
            this.dataGridViewPembayaran = new System.Windows.Forms.DataGridView();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.txtIdPembayaran = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPembayaran)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbNIK
            // 
            this.cmbNIK.Location = new System.Drawing.Point(333, 65);
            this.cmbNIK.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNIK.Name = "cmbNIK";
            this.cmbNIK.Size = new System.Drawing.Size(244, 24);
            this.cmbNIK.TabIndex = 1;
            // 
            // dtpTanggalPembayaran
            // 
            this.dtpTanggalPembayaran.Location = new System.Drawing.Point(333, 105);
            this.dtpTanggalPembayaran.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTanggalPembayaran.Name = "dtpTanggalPembayaran";
            this.dtpTanggalPembayaran.Size = new System.Drawing.Size(244, 22);
            this.dtpTanggalPembayaran.TabIndex = 2;
            // 
            // numJumlah
            // 
            this.numJumlah.Location = new System.Drawing.Point(333, 145);
            this.numJumlah.Margin = new System.Windows.Forms.Padding(4);
            this.numJumlah.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numJumlah.Name = "numJumlah";
            this.numJumlah.Size = new System.Drawing.Size(245, 22);
            this.numJumlah.TabIndex = 3;
            // 
            // cmbMetodePembayaran
            // 
            this.cmbMetodePembayaran.Location = new System.Drawing.Point(333, 194);
            this.cmbMetodePembayaran.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMetodePembayaran.Name = "cmbMetodePembayaran";
            this.cmbMetodePembayaran.Size = new System.Drawing.Size(244, 24);
            this.cmbMetodePembayaran.TabIndex = 4;
            // 
            // dataGridViewPembayaran
            // 
            this.dataGridViewPembayaran.ColumnHeadersHeight = 29;
            this.dataGridViewPembayaran.Location = new System.Drawing.Point(124, 286);
            this.dataGridViewPembayaran.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewPembayaran.Name = "dataGridViewPembayaran";
            this.dataGridViewPembayaran.RowHeadersWidth = 51;
            this.dataGridViewPembayaran.Size = new System.Drawing.Size(673, 207);
            this.dataGridViewPembayaran.TabIndex = 8;
            this.dataGridViewPembayaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPembayaran_CellClick);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(664, 25);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 30);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = "Tambah";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(664, 78);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(664, 131);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 30);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "ID_Pembayaran";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "NIK";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tanggal Pembayaran";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 145);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nominal Pembayaran";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Metode Pembayaran";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(664, 187);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 31);
            this.btnAnalyze.TabIndex = 14;
            this.btnAnalyze.Text = "Analisis";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.BtnAnalyze_Click);
            // 
            // txtIdPembayaran
            // 
            this.txtIdPembayaran.Location = new System.Drawing.Point(333, 25);
            this.txtIdPembayaran.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdPembayaran.Name = "txtIdPembayaran";
            this.txtIdPembayaran.Size = new System.Drawing.Size(244, 22);
            this.txtIdPembayaran.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(664, 242);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PembayaranForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 507);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdPembayaran);
            this.Controls.Add(this.cmbNIK);
            this.Controls.Add(this.dtpTanggalPembayaran);
            this.Controls.Add(this.numJumlah);
            this.Controls.Add(this.cmbMetodePembayaran);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.dataGridViewPembayaran);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PembayaranForm";
            this.Text = "Form Pembayaran";
            this.Load += new System.EventHandler(this.PembayaranForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPembayaran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAnalyze;
        private TextBox txtIdPembayaran;
        private Button btnRefresh;
    }
}