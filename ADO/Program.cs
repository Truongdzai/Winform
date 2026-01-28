using System;
using System.Windows.Forms;

namespace ADO
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // 2. Các thiết lập chuẩn giao diện Windows
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 3. Chạy LoginForm đầu tiên
            Application.Run(new LoginForm());
        }
    }
}