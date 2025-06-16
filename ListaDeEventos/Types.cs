using MySql.Data.MySqlClient;

namespace ListaDeEventos
{
    public enum Status
    {
        InvalidEmail,
        InvalidPassword,
        InvalidClass,
        UserExists,
        UserNotFound,
        IncorrectPassword,
        Success,
        Failed,
        Pass
    }

    public class Usuario
    {
        public string Email { get; set; }
        public string Turma { get; set; }
        public string Nome { get; set; }
    }

    public class UserLogin
    {
        public string email;
        public string password;
        public Status LoginStatus;
        public Usuario UsuarioLogado { get; private set; } = null;

        private readonly string connectionString = "server=localhost;database=test;uid=root;pwd=;";

        public UserLogin(string email_, string password_)
        {
            email = email_;
            password = password_;

            Status status = CheckData();
            if (status != Status.Success)
            {
                LoginStatus = status;
                return;
            }

            LoginStatus = LoginUser();
        }

        private Status LoginUser()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    if (UserExists(connection) != Status.UserExists)
                        return Status.UserNotFound;

                    string query = "SELECT senha, email, turma, nome FROM usuarios WHERE email = @Email";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPasswordHash = reader.GetString("senha");

                                if (!BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                                    return Status.IncorrectPassword;

                                UsuarioLogado = new Usuario
                                {
                                    Email = reader.GetString("email"),
                                    Turma = reader.GetString("turma"),
                                    Nome = reader.IsDBNull(reader.GetOrdinal("nome")) ? "" : reader.GetString("nome")
                                };

                                return Status.Success;
                            }
                            return Status.Failed;
                        }
                    }
                }
            }
            catch
            {
                return Status.Failed;
            }
        }

        private Status UserExists(MySqlConnection connection)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0 ? Status.UserExists : Status.UserNotFound;
                }
            }
            catch
            {
                return Status.Failed;
            }
        }

        private Status CheckData()
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return Status.InvalidEmail;

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
                return Status.InvalidEmail;

            if (password.Length < 8)
                return Status.InvalidPassword;

            return Status.Success;
        }
    }

    public class Register
    {
        public string email;
        public string password;
        public string className;
        public string nome;

        private readonly string connectionString = "server=localhost;database=test;uid=root;pwd=;";

        public Register(string email_, string password_, string className_, string nome_)
        {
            email = email_;
            password = password_;
            className = className_;
            nome = nome_;

            Status status = CheckData();
            if (status != Status.Success)
                throw new Exception("Dados inválidos: " + status.ToString());

            Status registrationStatus = RegisterUser();
            if (registrationStatus != Status.Success)
                throw new Exception("Erro ao registrar usuário: " + registrationStatus.ToString());
        }

        private Status RegisterUser()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                if (UserExists(connection) == Status.UserExists)
                    return Status.UserExists;

                string query = "INSERT INTO usuarios (email, senha, turma, nome) VALUES (@Email, @Password, @Class, @Nome)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", passwordHash);
                    command.Parameters.AddWithValue("@Class", className);
                    command.Parameters.AddWithValue("@Nome", nome);

                    int rows = command.ExecuteNonQuery();
                    return rows > 0 ? Status.Success : Status.Failed;
                }
            }
        }

        private Status UserExists(MySqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0 ? Status.UserExists : Status.Pass;
            }
        }

        private Status CheckData()
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(className) ||
                string.IsNullOrWhiteSpace(nome))
            {
                return Status.InvalidClass;
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                return Status.InvalidEmail;
            }

            if (password.Length < 8)
            {
                return Status.InvalidPassword;
            }

            return Status.Success;
        }
    }
}
