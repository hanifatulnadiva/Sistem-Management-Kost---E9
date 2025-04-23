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
        private System.Windows.Forms.Button btnRead;
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
            this.btnRead = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewPenyewa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPenyewa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNIK
            // 
            this.lblNIK.AutoSize = true;
            this.lblNIK.Location = new System.Drawing.Point(15, 27);
            this.lblNIK.Name = "lblNIK";
            this.lblNIK.Size = new System.Drawing.Size(28, 13);
            this.lblNIK.TabIndex = 0;
            this.lblNIK.Text = "NIK:";
            // 
            // txtNIK
            // 
            this.txtNIK.Location = new System.Drawing.Point(100, 27);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(200, 20);
            this.txtNIK.TabIndex = 1;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(15, 67);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(38, 13);
            this.lblNama.TabIndex = 2;
            this.lblNama.Text = "Nama:";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(100, 67);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(200, 20);
            this.txtNama.TabIndex = 3;
            // 
            // lblKontak
            // 
            this.lblKontak.AutoSize = true;
            this.lblKontak.Location = new System.Drawing.Point(15, 110);
            this.lblKontak.Name = "lblKontak";
            this.lblKontak.Size = new System.Drawing.Size(44, 13);
            this.lblKontak.TabIndex = 4;
            this.lblKontak.Text = "Kontak:";
            this.lblKontak.Click += new System.EventHandler(this.lblKontak_Click);
            // 
            // txtKontak
            // 
            this.txtKontak.Location = new System.Drawing.Point(100, 107);
            this.txtKontak.Name = "txtKontak";
            this.txtKontak.Size = new System.Drawing.Size(200, 20);
            this.txtKontak.TabIndex = 5;
            // 
            // lblTanggalMasuk
            // 
            this.lblTanggalMasuk.AutoSize = true;
            this.lblTanggalMasuk.Location = new System.Drawing.Point(15, 150);
            this.lblTanggalMasuk.Name = "lblTanggalMasuk";
            this.lblTanggalMasuk.Size = new System.Drawing.Size(84, 13);
            this.lblTanggalMasuk.TabIndex = 6;
            this.lblTanggalMasuk.Text = "Tanggal Masuk:";
            // 
            // dtpTanggalMasuk
            // 
            this.dtpTanggalMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalMasuk.Location = new System.Drawing.Point(100, 147);
            this.dtpTanggalMasuk.Name = "dtpTanggalMasuk";
            this.dtpTanggalMasuk.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalMasuk.TabIndex = 7;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(30, 190);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Add";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(120, 190);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 9;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(210, 190);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(300, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewPenyewa
            // 
            this.dataGridViewPenyewa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPenyewa.Location = new System.Drawing.Point(30, 230);
            this.dataGridViewPenyewa.Name = "dataGridViewPenyewa";
            this.dataGridViewPenyewa.Size = new System.Drawing.Size(600, 200);
            this.dataGridViewPenyewa.TabIndex = 12;
            // 
            // PenyewaForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.dataGridViewPenyewa);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRead);
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
    }
}