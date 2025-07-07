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
            this.dgvPreviewPenyewa = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewPenyewa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreviewPenyewa
            // 
            this.dgvPreviewPenyewa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviewPenyewa.Location = new System.Drawing.Point(34, 25);
            this.dgvPreviewPenyewa.Name = "dgvPreviewPenyewa";
            this.dgvPreviewPenyewa.RowHeadersWidth = 62;
            this.dgvPreviewPenyewa.RowTemplate.Height = 28;
            this.dgvPreviewPenyewa.Size = new System.Drawing.Size(738, 357);
            this.dgvPreviewPenyewa.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(684, 412);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvPreviewPenyewa);
            this.Name = "preview";
            this.Text = "preview";
            this.Load += new System.EventHandler(this.preview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewPenyewa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreviewPenyewa;
        private System.Windows.Forms.Button btnOK;
    }
}