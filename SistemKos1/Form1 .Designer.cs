using System.Windows.Forms;

namespace SistemKos1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel sideMenuPanel;
        private Panel mainPanel;
        private Button penyewaButton;
        private Button kamarButton;
        private Button pembayaranButton;
        private Button pemeliharaanButton;
        private Button exitButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.sideMenuPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.pemeliharaanButton = new System.Windows.Forms.Button();
            this.pembayaranButton = new System.Windows.Forms.Button();
            this.kamarButton = new System.Windows.Forms.Button();
            this.penyewaButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sideMenuPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.Controls.Add(this.exitButton);
            this.sideMenuPanel.Controls.Add(this.pemeliharaanButton);
            this.sideMenuPanel.Controls.Add(this.pembayaranButton);
            this.sideMenuPanel.Controls.Add(this.kamarButton);
            this.sideMenuPanel.Controls.Add(this.penyewaButton);
            this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(200, 450);
            this.sideMenuPanel.TabIndex = 0;

            // 
            // penyewaButton
            // 
            this.penyewaButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.penyewaButton.Text = "Penyewa";
            this.penyewaButton.Height = 50;
            this.penyewaButton.Click += new System.EventHandler(this.penyewaButton_Click);

            // 
            // kamarButton
            // 
            this.kamarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.kamarButton.Text = "Kamar";
            this.kamarButton.Height = 50;
            this.kamarButton.Click += new System.EventHandler(this.kamarButton_Click);

            // 
            // pembayaranButton
            // 
            this.pembayaranButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pembayaranButton.Text = "Pembayaran";
            this.pembayaranButton.Height = 50;
            this.pembayaranButton.Click += new System.EventHandler(this.pembayaranButton_Click);

            // 
            // pemeliharaanButton
            // 
            this.pemeliharaanButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pemeliharaanButton.Text = "Pemeliharaan";
            this.pemeliharaanButton.Height = 50;
            this.pemeliharaanButton.Click += new System.EventHandler(this.pemeliharaanButton_Click);

            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitButton.Text = "Keluar";
            this.exitButton.Height = 50;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);

            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(600, 450);
            this.mainPanel.TabIndex = 1;

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sideMenuPanel);
            this.Name = "Form1";
            this.Text = "Sistem Manajemen Kost";
            this.sideMenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
