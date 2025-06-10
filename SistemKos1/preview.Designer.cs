namespace SistemKos1
{
    partial class preview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvPreviewPenyewa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewPenyewa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(692, 395);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 43);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // dgvPreviewPenyewa
            // 
            this.dgvPreviewPenyewa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviewPenyewa.Location = new System.Drawing.Point(27, 26);
            this.dgvPreviewPenyewa.Name = "dgvPreviewPenyewa";
            this.dgvPreviewPenyewa.RowHeadersWidth = 62;
            this.dgvPreviewPenyewa.RowTemplate.Height = 28;
            this.dgvPreviewPenyewa.Size = new System.Drawing.Size(749, 352);
            this.dgvPreviewPenyewa.TabIndex = 1;
            this.dgvPreviewPenyewa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPreviewPenyewa);
            // 
            // preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPreviewPenyewa);
            this.Controls.Add(this.btnOK);
            this.Name = "preview";
            this.Text = "preview";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewPenyewa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvPreviewPenyewa;
    }
}