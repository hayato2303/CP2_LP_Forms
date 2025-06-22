using ListaDeEventos.Forms;

namespace ListaDeEventos
{
    public partial class Interface : Form
    {
        public User_ activeUser = null;
        public string activeClass = null;

        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            var functions = new lib();

            // Carrega as turmas disponíveis
            List<string> classes = functions.GetClasses();

            string user = $"{activeUser.Email} | {activeUser.Name} | {activeUser.Class}";
            userData.Text = user;

            if (classes != null && classes.Count > 0)
            {
                foreach (string turma in classes)
                    class_list.Items.Add(turma);
            }
            else
            {
                MessageBox.Show(
                    "Nenhuma turma encontrada.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void class_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClass = class_list.SelectedItem.ToString();
            activeClass = selectedClass;

            var functions = new lib();

            // Carrega os eventos da turma selecionada
            List<UserEvent> events = functions.GetClassEvents(selectedClass);

            EventsTable.Rows.Clear();

            if (events != null && events.Count > 0)
            {
                foreach (var evento in events)
                {
                    EventsTable.Rows.Add(
                        evento.Name,
                        evento.StartDate.ToString("dd/MM/yyyy"),
                        evento.EndDate.ToString("dd/MM/yyyy"),
                        evento.StartTime.ToString("HH:mm"),
                        evento.EndTime.ToString("HH:mm"),
                        evento.Description,
                        evento.Id
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Nenhum evento encontrado para a turma selecionada.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void EventsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < EventsTable.Rows.Count)
            {
                var row = EventsTable.Rows[e.RowIndex];

                string nome = row.Cells[0].Value?.ToString();
                string dataInicio = row.Cells[1].Value?.ToString();
                string dataFim = row.Cells[2].Value?.ToString();
                string horaInicio = row.Cells[3].Value?.ToString();
                string horaFim = row.Cells[4].Value?.ToString();
                string descricao = row.Cells[5].Value?.ToString();

                string message =
                    $"Evento: {nome}\n" +
                    $"Data: {dataInicio} ate {dataFim}\n" +
                    $"Hora: {horaInicio} as {horaFim}\n" +
                    $"Descrição: {descricao}";

                DescriptionLabel.Text = message;
            }
        }

        private void Create_button_Click(object sender, EventArgs e)
        {
            if (activeUser == null)
            {
                MessageBox.Show(
                    "Nenhum usuário ativo. Por favor, faça login.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (activeUser.Class == class_list.SelectedItem?.ToString())
            {
                try
                {
                    var createEventForm = new CriarEvento_
                    {
                        userId = activeUser.Id
                    };

                    createEventForm.ShowDialog();
                    var createdEvent = createEventForm.createdUserEvent;

                    if (createdEvent != null)
                    {
                        var functions = new lib();
                        functions.AddEvent(createdEvent, activeClass);

                        class_list_SelectedIndexChanged(null, null);
                    }
                }
                catch
                {
                    MessageBox.Show(
                        "Erro ao criar evento. Verifique os dados inseridos.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "O usuário ativo não pertence à turma selecionada.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            string selectedClass = class_list.SelectedItem.ToString();

            if (EventsTable.SelectedRows.Count > 0 && activeUser.Class == class_list.SelectedItem?.ToString())
            {
                var selectedRow = EventsTable.SelectedRows[0];
                string eventId = selectedRow.Cells[6].Value.ToString();
                int eventUserId = Convert.ToInt32(eventId);

                lib lib = new lib();
                lib.DeleteEvent(eventUserId);

                class_list_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show(
                    "Nenhum evento selecionado ou o usuário ativo não pertence à turma selecionada.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

            }
        }
    }
}
