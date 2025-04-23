using System;
using System.Windows.Forms;

namespace SistemKos1
{
    partial class PembayaranForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtIdPembayaran;
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
            this.txtIdPembayaran = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPembayaran)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdPembayaran
            // 
            this.txtIdPembayaran.Location = new System.Drawing.Point(250, 20);
            this.txtIdPembayaran.Name = "txtIdPembayaran";
            this.txtIdPembayaran.Size = new System.Drawing.Size(184, 20);
            this.txtIdPembayaran.TabIndex = 0;
            // 
            // cmbNIK
            // 
            this.cmbNIK.Location = new System.Drawing.Point(250, 53);
            this.cmbNIK.Name = "cmbNIK";
            this.cmbNIK.Size = new System.Drawing.Size(184, 21);
            this.cmbNIK.TabIndex = 1;
            // 
            // dtpTanggalPembayaran
            // 
            this.dtpTanggalPembayaran.Location = new System.Drawing.Point(250, 85);
            this.dtpTanggalPembayaran.Name = "dtpTanggalPembayaran";
            this.dtpTanggalPembayaran.Size = new System.Drawing.Size(184, 20);
            this.dtpTanggalPembayaran.TabIndex = 2;
            // 
            // numJumlah
            // 
            this.numJumlah.Location = new System.Drawing.Point(250, 118);
            this.numJumlah.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numJumlah.Name = "numJumlah";
            this.numJumlah.Size = new System.Drawing.Size(184, 20);
            this.numJumlah.TabIndex = 3;
            // 
            // cmbMetodePembayaran
            // 
            this.cmbMetodePembayaran.Location = new System.Drawing.Point(250, 158);
            this.cmbMetodePembayaran.Name = "cmbMetodePembayaran";
            this.cmbMetodePembayaran.Size = new System.Drawing.Size(184, 21);
            this.cmbMetodePembayaran.TabIndex = 4;
            // 
            // dataGridViewPembayaran
            // 
            this.dataGridViewPembayaran.Location = new System.Drawing.Point(93, 232);
            this.dataGridViewPembayaran.Name = "dataGridViewPembayaran";
            this.dataGridViewPembayaran.Size = new System.Drawing.Size(505, 168);
            this.dataGridViewPembayaran.TabIndex = 8;
            this.dataGridViewPembayaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPembayaran_CellClick);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(498, 20);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(56, 24);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = "Tambah";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(498, 79);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(56, 24);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(498, 134);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(56, 24);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ID_Pembayaran";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "NIK";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tanggal Pembayaran";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nominal Pembayaran";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Metode Pembayaran";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // PembayaranForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 412);
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
    }
}
