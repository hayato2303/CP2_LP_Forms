using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeEventos.Forms
{
    public partial class CriarEvento_ : Form
    {
        public UserEvent createdUserEvent = null;
        public int userId = 0;

        public CriarEvento_()
        {
            InitializeComponent();
        }

        private void Create_button_Click(object sender, EventArgs e)
        {
            var random = new Random();

            createdUserEvent = new UserEvent
            {
                Name = Name.Text,
                StartDate = start_date.Value.Date,
                EndDate = end_date.Value.Date,
                StartTime = new TimeOnly(Convert.ToInt32(start_date_h.Value), Convert.ToInt32(start_date_m.Value)),
                EndTime = new TimeOnly(Convert.ToInt32(end_date_h.Value), Convert.ToInt32(end_date_m.Value)),
                Description = Description.Text,
                UserId = userId
            };

            this.Close();
        }

        private void CriarEvento_Load(object sender, EventArgs e)
        {

        }
    }
}
