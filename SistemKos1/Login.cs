using System;
using System.Windows.Forms;

namespace SistemKos1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Fungsi untuk memeriksa login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Cek login (misalnya username = "admin" dan password = "admin")
            if (username == "admin" && password == "admin")
            {
                this.Hide(); // Sembunyikan form login
                Form1 form1 = new Form1();
                form1.Show(); // Tampilkan form utama setelah login berhasil
            }
            else
            {
                MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
