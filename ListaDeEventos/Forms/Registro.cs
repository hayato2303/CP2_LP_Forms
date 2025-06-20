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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void R_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void R_senha_TextChanged(object sender, EventArgs e)
        {

        }

        private void R_turma_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            Functions functions = new Functions();

            bool result = functions.Register(
                R_email.Text,
                R_senha.Text,
                R_turma.Text,
                R_Nome.Text
            );

            if (result)
            {
                MessageBox.Show("Registro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao registrar. Verifique os dados ou se o email já está cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void R_Nome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
