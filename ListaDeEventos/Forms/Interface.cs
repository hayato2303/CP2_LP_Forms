namespace ListaDeEventos
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            Functions functions = new Functions();

            List<string> classes = functions.GetClasses();
            if (classes != null && classes.Count > 0)
            {
                foreach (string class_ in classes)
                {
                    class_list.Items.Add(class_);
                }
            }
            else
            {
                MessageBox.Show("Nenhuma turma encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void class_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClass = class_list.SelectedItem.ToString();
            Functions functions = new Functions();

            List<UserEvent> events = functions.GetClassEvents(selectedClass);

            if (events != null && events.Count > 0)
            {
                EventsTable.Rows.Clear();

                foreach (UserEvent event_ in events)
                {
                    EventsTable.Rows.Add(
                        event_.Nome,
                        event_.StartDate.ToString("dd/MM/yyyy"),
                        event_.EndDate.ToString("dd/MM/yyyy"),
                        event_.StartTime.ToString("HH:mm"),
                        event_.EndTime.ToString("HH:mm"),
                        event_.Descricao.ToString()
                    );
                }
            }
            else
            {
                EventsTable.Rows.Clear();
                MessageBox.Show("Nenhum evento encontrado para a turma selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EventsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < EventsTable.Rows.Count)
            {
                DataGridViewRow row = EventsTable.Rows[e.RowIndex];

                string name = row.Cells[0].Value?.ToString();
                string DI = row.Cells[1].Value?.ToString();
                string DF = row.Cells[2].Value?.ToString();
                string HI = row.Cells[3].Value?.ToString();
                string HF = row.Cells[4].Value?.ToString();
                string description = row.Cells[5].Value?.ToString();

                string Message =    $"Evento: {name}\n" +
                                    $"Data: {DI} {HI} até {DF} {HF}\n" +
                                    $"Descrição: {description}";

               DescriptionLabel.Text = Message;
            }
        }
    }
}
