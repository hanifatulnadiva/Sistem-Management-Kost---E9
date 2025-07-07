namespace SistemKos1
{
    partial class PenyewaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNIK;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblKontak;
        private System.Windows.Forms.TextBox txtKontak;
        private System.Windows.Forms.Label lblTanggalMasuk;
        private System.Windows.Forms.DateTimePicker dtpTanggalMasuk;  // DateTimePicker untuk tanggal masuk
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewPenyewa;

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
            this.lblNIK = new System.Windows.Forms.Label();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.lblNama = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.lblKontak = new System.Windows.Forms.Label();
            this.txtKontak = new System.Windows.Forms.TextBox();
            this.lblTanggalMasuk = new System.Windows.Forms.Label();
            this.dtpTanggalMasuk = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewPenyewa = new System.Windows.Forms.DataGridView();
            this.btnAnalisis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTanggalKeluar = new System.Windows.Forms.DateTimePicker();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPenyewa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNIK
            // 
            this.lblNIK.AutoSize = true;
            this.lblNIK.Location = new System.Drawing.Point(15, 27);
            this.lblNIK.Name = "lblNIK";
            this.lblNIK.Size = new System.Drawing.Size(39, 20);
            this.lblNIK.TabIndex = 0;
            this.lblNIK.Text = "NIK:";
            // 
            // txtNIK
            // 
            this.txtNIK.Location = new System.Drawing.Point(148, 21);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(200, 26);
            this.txtNIK.TabIndex = 1;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(15, 67);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(55, 20);
            this.lblNama.TabIndex = 2;
            this.lblNama.Text = "Nama:";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(148, 56);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(200, 26);
            this.txtNama.TabIndex = 3;
            // 
            // lblKontak
            // 
            this.lblKontak.AutoSize = true;
            this.lblKontak.Location = new System.Drawing.Point(15, 110);
            this.lblKontak.Name = "lblKontak";
            this.lblKontak.Size = new System.Drawing.Size(63, 20);
            this.lblKontak.TabIndex = 4;
            this.lblKontak.Text = "Kontak:";
            this.lblKontak.Click += new System.EventHandler(this.lblKontak_Click);
            // 
            // txtKontak
            // 
            this.txtKontak.Location = new System.Drawing.Point(148, 104);
            this.txtKontak.Name = "txtKontak";
            this.txtKontak.Size = new System.Drawing.Size(200, 26);
            this.txtKontak.TabIndex = 5;
            // 
            // lblTanggalMasuk
            // 
            this.lblTanggalMasuk.AutoSize = true;
            this.lblTanggalMasuk.Location = new System.Drawing.Point(15, 150);
            this.lblTanggalMasuk.Name = "lblTanggalMasuk";
            this.lblTanggalMasuk.Size = new System.Drawing.Size(121, 20);
            this.lblTanggalMasuk.TabIndex = 6;
            this.lblTanggalMasuk.Text = "Tanggal Masuk:";
            // 
            // dtpTanggalMasuk
            // 
            this.dtpTanggalMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalMasuk.Location = new System.Drawing.Point(148, 145);
            this.dtpTanggalMasuk.Name = "dtpTanggalMasuk";
            this.dtpTanggalMasuk.Size = new System.Drawing.Size(200, 26);
            this.dtpTanggalMasuk.TabIndex = 7;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(30, 244);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(136, 31);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Tambah";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(211, 244);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(137, 31);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(211, 302);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 31);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(30, 302);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(136, 31);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Hapus";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewPenyewa
            // 
            this.dataGridViewPenyewa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPenyewa.Location = new System.Drawing.Point(381, 12);
            this.dataGridViewPenyewa.Name = "dataGridViewPenyewa";
            this.dataGridViewPenyewa.RowHeadersWidth = 62;
            this.dataGridViewPenyewa.Size = new System.Drawing.Size(474, 411);
            this.dataGridViewPenyewa.TabIndex = 12;
            this.dataGridViewPenyewa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPenyewa_CellClick);
            // 
            // btnAnalisis
            // 
            this.btnAnalisis.Location = new System.Drawing.Point(77, 349);
            this.btnAnalisis.Name = "btnAnalisis";
            this.btnAnalisis.Size = new System.Drawing.Size(221, 47);
            this.btnAnalisis.TabIndex = 13;
            this.btnAnalisis.Text = "Analisis";
            this.btnAnalisis.UseVisualStyleBackColor = true;
            this.btnAnalisis.Click += new System.EventHandler(this.btnAnalisis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tanggal Keluar";
            // 
            // dtpTanggalKeluar
            // 
            this.dtpTanggalKeluar.Location = new System.Drawing.Point(148, 194);
            this.dtpTanggalKeluar.Name = "dtpTanggalKeluar";
            this.dtpTanggalKeluar.Size = new System.Drawing.Size(198, 26);
            this.dtpTanggalKeluar.TabIndex = 15;
            this.dtpTanggalKeluar.Value = new System.DateTime(2025, 6, 9, 17, 5, 23, 0);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(77, 417);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(221, 50);
            this.btnImport.TabIndex = 16;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // PenyewaForm
            // 
            this.ClientSize = new System.Drawing.Size(898, 479);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dtpTanggalKeluar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnalisis);
            this.Controls.Add(this.dataGridViewPenyewa);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dtpTanggalMasuk);
            this.Controls.Add(this.lblTanggalMasuk);
            this.Controls.Add(this.txtKontak);
            this.Controls.Add(this.lblKontak);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.lblNIK);
            this.Name = "PenyewaForm";
            this.Text = "Sistem Manajemen Kost";
            this.Load += new System.EventHandler(this.PenyewaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPenyewa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnAnalisis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTanggalKeluar;
        private System.Windows.Forms.Button btnImport;
    }
}