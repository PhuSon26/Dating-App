using Main_Interface;

namespace LOGIN
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var authHelper = new FirebaseAuthHelper("AIzaSyDg9nNBc3h74QjNl2obv6pH1Y29RQQ8TjU");
            Application.Run(new FormDangNhap(authHelper));
        }
    }
}
