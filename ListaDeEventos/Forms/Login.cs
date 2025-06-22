using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeEventos
{
    public partial class Login : Form
    {
        public bool isLoggedIn = false;
        public User_ loggedInUser = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e) { }

        private void login_button_Click(object sender, EventArgs e)
        {
            var functions = new lib();

            (bool result, User_ loginUser) = functions.Login(
                Email.Text.Trim(),
                Password.Text.Trim()
            );

            if (result)
            {
                loggedInUser = loginUser;
                isLoggedIn = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "E-mail ou senha incorretos. Tente novamente.",
                    "Erro de Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isLoggedIn = false;
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e)
        {
            // Abre o formulário de registro
            var registroForm = new Register();
            registroForm.ShowDialog();

            // Após fechar o formulário de registro
            MessageBox.Show(
                "Se o registro foi concluído, você já pode fazer login.",
                "Informação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
