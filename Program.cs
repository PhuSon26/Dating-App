namespace LOGIN
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
            var authHelper = new FirebaseAuthHelper("AIzaSyDg9nNBc3h74QjNl2obv6pH1Y29RQQ8TjU");
            Application.Run(new FormDangNhap(authHelper));
        }
    }
}