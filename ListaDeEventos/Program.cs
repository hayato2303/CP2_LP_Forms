namespace ListaDeEventos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Interface do login
            var loginForm = new Login();
            Application.Run(loginForm);
            if (!loginForm.isLoggedIn)
                return;

            // inicia a interface principal com os dados do usuario logado
            var mainInterface = new Interface();
            mainInterface.activeUser = loginForm.loggedInUser;
            mainInterface.activeClass = loginForm.loggedInUser.Class;

            Application.Run(mainInterface);
        }
    }
}