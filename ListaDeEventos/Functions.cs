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
        public string Turma { get; set; }
        public string Nome { get; set; }
        public List<UserEvent> Eventos { get; set; } = new List<UserEvent>();
    }

    public class UserEvent
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
    }

    public class Functions
    {
        private readonly string connectionString = "server=localhost;database=lp2_cp2;uid=root;pwd=;";

        public bool Register(string email, string password, string turma, string nome)
        {
            if (!CheckData(email, password, turma, nome))
                return false;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    if (UserExists(email, connection))
                        return false;

                    string query = "INSERT INTO usuarios (email, senha, turma, nome) VALUES (@Email, @Password, @Turma, @Nome)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", passwordHash);
                        command.Parameters.AddWithValue("@Turma", turma);
                        command.Parameters.AddWithValue("@Nome", nome);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
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
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    if (!UserExists(email, connection))
                        return (false, null);

                    string query = "SELECT id, senha, email, turma, nome FROM usuarios WHERE email = @Email";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPasswordHash = reader.GetString("senha");

                                if (!BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                                    return (false, null);

                                User_ user = new User_
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Email = reader.GetString("email"),
                                    Turma = reader.GetString("turma"),
                                    Nome = reader.IsDBNull(reader.GetOrdinal("nome")) ? "" : reader.GetString("nome"),
                                    Eventos = new List<UserEvent>()
                                };

                                reader.Close();
                                user = LoadUserEvents(user);

                                return (true, user);
                            }
                            return (false, null);
                        }
                    }
                }
            }
            catch
            {
                return (false, null);
            }
        }

        public bool UserExists(string email)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return UserExists(email, connection);
                }
            }
            catch
            {
                return false;
            }
        }

        private bool UserExists(string email, MySqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public int GetUserId(User_ user)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id FROM usuarios WHERE email = @Email AND turma = @Turma AND nome = @Nome";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Turma", user.Turma);
                        command.Parameters.AddWithValue("@Nome", user.Nome);

                        object result = command.ExecuteScalar();
                        return result != null && int.TryParse(result.ToString(), out int userId) ? userId : -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        public User_ LoadUserEvents(User_ user)
        {
            try
            {
                string query = "SELECT * FROM eventos WHERE usuario_id = @UsuarioID";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", user.Id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserEvent evento = new UserEvent
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nome = reader["nome"].ToString(),
                                    StartDate = Convert.ToDateTime(reader["data_inicio"]),
                                    EndDate = Convert.ToDateTime(reader["data_fim"]),
                                    StartTime = TimeOnly.Parse(reader["hora_inicio"].ToString()),
                                    EndTime = TimeOnly.Parse(reader["hora_fim"].ToString()),
                                    Descricao = reader["descricao"].ToString(),
                                    UsuarioId = Convert.ToInt32(reader["usuario_id"])
                                };

                                user.Eventos.Add(evento);
                            }
                        }
                    }
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
            List<string> classes = new List<string>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT turma FROM usuarios";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            classes.Add(reader.GetString("turma"));
                    }
                }
            }
            catch
            {
                return classes;
            }
            return classes;
        }

        public List<UserEvent> GetClassEvents(string className)
        {
            List<UserEvent> events = new List<UserEvent>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM eventos WHERE turma = @Turma";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Turma", className);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserEvent evento = new UserEvent
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nome = reader["nome"].ToString(),
                                    StartDate = Convert.ToDateTime(reader["data_inicio"]),
                                    EndDate = Convert.ToDateTime(reader["data_fim"]),
                                    StartTime = TimeOnly.Parse(reader["hora_inicio"].ToString()),
                                    EndTime = TimeOnly.Parse(reader["hora_fim"].ToString()),
                                    Descricao = reader["descricao"].ToString(),
                                    UsuarioId = Convert.ToInt32(reader["usuario_id"])
                                };
                                events.Add(evento);
                            }
                        }
                    }
                }
            }
            catch
            {
                return events;
            }
            return events;
        }

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
    }
}
