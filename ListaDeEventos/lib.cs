using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ListaDeEventos
{
    public class User_
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public List<UserEvent> Events { get; set; } = new List<UserEvent>();
    }

    public class UserEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }

    public class lib
    {
        private readonly string connectionString = "server=localhost;database=lp2_cp2;uid=root;pwd=;";

        private bool CheckData(string email, string password, string turma, string nome)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(turma) ||
                string.IsNullOrWhiteSpace(nome))
                return false;

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
                return false;

            if (password.Length < 8)
                return false;

            return true;
        }

        private bool UserExists(string email, MySqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }

        public bool Register(string email, string password, string turma, string nome)
        {
            if (!CheckData(email, password, turma, nome))
                return false;

            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                if (UserExists(email, connection))
                    return false;

                string query = "INSERT INTO usuarios (email, senha, turma, nome) VALUES (@Email, @Password, @Turma, @Nome)";
                using var command = new MySqlCommand(query, connection);

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", passwordHash);
                command.Parameters.AddWithValue("@Turma", turma);
                command.Parameters.AddWithValue("@Nome", nome);

                return command.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
        }

        public (bool, User_) Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return (false, null);

            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                if (!UserExists(email, connection))
                    return (false, null);

                string query = "SELECT id, senha, email, turma, nome FROM usuarios WHERE email = @Email";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string storedPasswordHash = reader.GetString("senha");

                    if (!BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                        return (false, null);

                    var user = new User_
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Email = reader.GetString("email"),
                        Class = reader.GetString("turma"),
                        Name = reader.IsDBNull(reader.GetOrdinal("nome")) ? "" : reader.GetString("nome"),
                        Events = new List<UserEvent>()
                    };

                    reader.Close();
                    user = LoadUserEvents(user);

                    return (true, user);
                }

                return (false, null);
            }
            catch
            {
                return (false, null);
            }
        }

        public User_ LoadUserEvents(User_ user)
        {
            try
            {
                string query = "SELECT * FROM eventos WHERE usuario_id = @UsuarioID";

                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioID", user.Id);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var evento = new UserEvent
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["nome"].ToString(),
                        StartDate = Convert.ToDateTime(reader["data_inicio"]),
                        EndDate = Convert.ToDateTime(reader["data_fim"]),
                        StartTime = TimeOnly.Parse(reader["hora_inicio"].ToString()),
                        EndTime = TimeOnly.Parse(reader["hora_fim"].ToString()),
                        Description = reader["descricao"].ToString(),
                        UserId = Convert.ToInt32(reader["usuario_id"])
                    };
                    user.Events.Add(evento);
                }

                return user;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GetClasses()
        {
            var classes = new List<string>();
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "SELECT DISTINCT turma FROM usuarios";
                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                    classes.Add(reader.GetString("turma"));
            }
            catch
            {
                return classes;
            }

            return classes;
        }

        public List<UserEvent> GetClassEvents(string className)
        {
            var events = new List<UserEvent>();
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "SELECT * FROM eventos WHERE turma = @Turma";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Turma", className);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var evento = new UserEvent
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["nome"].ToString(),
                        StartDate = Convert.ToDateTime(reader["data_inicio"]),
                        EndDate = Convert.ToDateTime(reader["data_fim"]),
                        StartTime = TimeOnly.Parse(reader["hora_inicio"].ToString()),
                        EndTime = TimeOnly.Parse(reader["hora_fim"].ToString()),
                        Description = reader["descricao"].ToString(),
                        UserId = Convert.ToInt32(reader["usuario_id"])
                    };
                    events.Add(evento);
                }
            }
            catch
            {
                return events;
            }

            return events;
        }

        public void AddEvent(UserEvent event_, string turma)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO eventos (nome, data_inicio, data_fim, hora_inicio, hora_fim, descricao, usuario_id, turma) " +
                               "VALUES (@Nome, @DataInicio, @DataFim, @HoraInicio, @HoraFim, @Descricao, @UsuarioId, @Turma)";

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", event_.Name);
                command.Parameters.AddWithValue("@DataInicio", event_.StartDate);
                command.Parameters.AddWithValue("@DataFim", event_.EndDate);
                command.Parameters.AddWithValue("@HoraInicio", event_.StartTime.ToString());
                command.Parameters.AddWithValue("@HoraFim", event_.EndTime.ToString());
                command.Parameters.AddWithValue("@Descricao", event_.Description);
                command.Parameters.AddWithValue("@UsuarioId", event_.UserId);
                command.Parameters.AddWithValue("@Turma", turma);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar evento: {ex.Message}");
            }
        }

        public void DeleteEvent(int eventId)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "DELETE FROM eventos WHERE id = @EventId";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventId", eventId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao deletar evento: {ex.Message}");
            }

        }
    }
}
