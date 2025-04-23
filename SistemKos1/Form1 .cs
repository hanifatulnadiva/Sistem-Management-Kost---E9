using System;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sideMenuPanel.Dock = DockStyle.Left;
            sideMenuPanel.BackColor = System.Drawing.Color.Gray;
        }

        private void ShowFormInPanel(Form form)
        {
            mainPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void penyewaButton_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new PenyewaForm());
        }

        private void kamarButton_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new KamarForm());
        }

        private void pembayaranButton_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new PembayaranForm());
        }

        private void pemeliharaanButton_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new PemeliharaanForm());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
