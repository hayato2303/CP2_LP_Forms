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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e) { }

        private void R_email_TextChanged(object sender, EventArgs e) { }

        private void R_senha_TextChanged(object sender, EventArgs e) { }

        private void R_turma_TextChanged(object sender, EventArgs e) { }

        private void R_Nome_TextChanged(object sender, EventArgs e) { }

        private void Registrar_Click(object sender, EventArgs e)
        {
            var functions = new lib();

            bool result = functions.Register(
                R_email.Text.Trim(),
                R_senha.Text.Trim(),
                R_turma.Text.Trim(),
                R_Nome.Text.Trim()
            );

            if (result)
            {
                MessageBox.Show(
                    "Registro realizado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Erro ao registrar. Verifique os dados ou se o e-mail já está cadastrado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
