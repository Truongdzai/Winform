using System;
using System.Windows.Forms;

namespace Example01 // Tên Namespace dự án của em
{
    internal static class Program
    {
        /// <summary>
        ///  Điểm bắt đầu chính của ứng dụng (The main entry point).
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Cấu hình giao diện chuẩn cho .NET 8 (thay thế cho 2 dòng EnableVisualStyles cũ trong Slide)
            ApplicationConfiguration.Initialize();

            // Lệnh này mở Form1 lên. Đây là lúc chiếc xe bắt đầu lăn bánh.
            Application.Run(new Form1());
        }
    }
}