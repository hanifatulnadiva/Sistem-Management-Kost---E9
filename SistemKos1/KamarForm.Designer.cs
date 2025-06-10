namespace SistemKos1
{
    partial class KamarForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtIdKamar;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbPenyewa;
        private System.Windows.Forms.DataGridView dataGridViewKamar;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblIdKamar;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPenyewa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIdKamar = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbPenyewa = new System.Windows.Forms.ComboBox();
            this.dataGridViewKamar = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblIdKamar = new System.Windows.Forms.Label();
            this.lblHarga = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPenyewa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKamar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdKamar
            // 
            this.txtIdKamar.Location = new System.Drawing.Point(121, 20);
            this.txtIdKamar.Name = "txtIdKamar";
            this.txtIdKamar.Size = new System.Drawing.Size(100, 20);
            this.txtIdKamar.TabIndex = 1;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(121, 60);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(100, 20);
            this.txtHarga.TabIndex = 3;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(121, 100);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 5;
            // 
            // cmbPenyewa
            // 
            this.cmbPenyewa.Location = new System.Drawing.Point(126, 140);
            this.cmbPenyewa.Name = "cmbPenyewa";
            this.cmbPenyewa.Size = new System.Drawing.Size(121, 21);
            this.cmbPenyewa.TabIndex = 7;
            this.cmbPenyewa.SelectedIndexChanged += new System.EventHandler(this.cmbPenyewa_SelectedIndexChanged);
            // 
            // dataGridViewKamar
            // 
            this.dataGridViewKamar.Location = new System.Drawing.Point(20, 220);
            this.dataGridViewKamar.Name = "dataGridViewKamar";
            this.dataGridViewKamar.Size = new System.Drawing.Size(540, 200);
            this.dataGridViewKamar.TabIndex = 12;
            this.dataGridViewKamar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKamar_CellClick);
            this.dataGridViewKamar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewKamar_CellFormatting);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(20, 180);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(110, 180);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(200, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(290, 180);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(380, 180);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 13;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // lblIdKamar
            // 
            this.lblIdKamar.Location = new System.Drawing.Point(20, 20);
            this.lblIdKamar.Name = "lblIdKamar";
            this.lblIdKamar.Size = new System.Drawing.Size(100, 23);
            this.lblIdKamar.TabIndex = 0;
            this.lblIdKamar.Text = "ID Kamar:";
            // 
            // lblHarga
            // 
            this.lblHarga.Location = new System.Drawing.Point(20, 60);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(100, 23);
            this.lblHarga.TabIndex = 2;
            this.lblHarga.Text = "Harga:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 100);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            // 
            // lblPenyewa
            // 
            this.lblPenyewa.Location = new System.Drawing.Point(20, 140);
            this.lblPenyewa.Name = "lblPenyewa";
            this.lblPenyewa.Size = new System.Drawing.Size(100, 23);
            this.lblPenyewa.TabIndex = 6;
            this.lblPenyewa.Text = "Penyewa:";
            // 
            // KamarForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lblIdKamar);
            this.Controls.Add(this.txtIdKamar);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblPenyewa);
            this.Controls.Add(this.cmbPenyewa);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.dataGridViewKamar);
            this.Name = "KamarForm";
            this.Text = "Manajemen Kamar";
            this.Load += new System.EventHandler(this.KamarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKamar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
