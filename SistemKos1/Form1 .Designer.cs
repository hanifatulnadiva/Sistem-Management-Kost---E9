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
            this.report = new System.Windows.Forms.Button();
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
            this.sideMenuPanel.Controls.Add(this.report);
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
            // report
            // 
            this.report.BackColor = System.Drawing.SystemColors.GrayText;
            this.report.Dock = System.Windows.Forms.DockStyle.Top;
            this.report.Location = new System.Drawing.Point(0, 200);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(200, 47);
            this.report.TabIndex = 5;
            this.report.Text = "Report";
            this.report.UseVisualStyleBackColor = false;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitButton.Location = new System.Drawing.Point(0, 400);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 50);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Keluar";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // pemeliharaanButton
            // 
            this.pemeliharaanButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pemeliharaanButton.Location = new System.Drawing.Point(0, 150);
            this.pemeliharaanButton.Name = "pemeliharaanButton";
            this.pemeliharaanButton.Size = new System.Drawing.Size(200, 50);
            this.pemeliharaanButton.TabIndex = 1;
            this.pemeliharaanButton.Text = "Pemeliharaan";
            this.pemeliharaanButton.Click += new System.EventHandler(this.pemeliharaanButton_Click);
            // 
            // pembayaranButton
            // 
            this.pembayaranButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pembayaranButton.Location = new System.Drawing.Point(0, 100);
            this.pembayaranButton.Name = "pembayaranButton";
            this.pembayaranButton.Size = new System.Drawing.Size(200, 50);
            this.pembayaranButton.TabIndex = 2;
            this.pembayaranButton.Text = "Pembayaran";
            this.pembayaranButton.Click += new System.EventHandler(this.pembayaranButton_Click);
            // 
            // kamarButton
            // 
            this.kamarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.kamarButton.Location = new System.Drawing.Point(0, 50);
            this.kamarButton.Name = "kamarButton";
            this.kamarButton.Size = new System.Drawing.Size(200, 50);
            this.kamarButton.TabIndex = 3;
            this.kamarButton.Text = "Kamar";
            this.kamarButton.Click += new System.EventHandler(this.kamarButton_Click);
            // 
            // penyewaButton
            // 
            this.penyewaButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.penyewaButton.Location = new System.Drawing.Point(0, 0);
            this.penyewaButton.Name = "penyewaButton";
            this.penyewaButton.Size = new System.Drawing.Size(200, 50);
            this.penyewaButton.TabIndex = 4;
            this.penyewaButton.Text = "Penyewa";
            this.penyewaButton.Click += new System.EventHandler(this.penyewaButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(600, 450);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
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

        private Button report;
    }
}
