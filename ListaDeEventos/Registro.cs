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
            try
            {
                Register register = new Register(R_email.Text, R_senha.Text, R_turma.Text, R_Nome.Text);
                MessageBox.Show("Registro realizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
