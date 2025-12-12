using System;
using System.Windows.Forms;

// Lưu ý: Đảm bảo namespace này giống với các file Form khác của bạn
// Dựa trên ảnh bạn gửi, namespace của bạn có thể là "QuangVanTruong_2123170591"
// Tuy nhiên, để code chạy được với các file tôi gửi, hãy giữ nguyên hoặc đổi tất cả về cùng 1 tên.
namespace WinFormsApp_Article
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // --- SỬA LỖI ApplicationConfiguration ---
            // Thay vì dùng ApplicationConfiguration.Initialize(); (dễ gây lỗi namespace)
            // Chúng ta dùng 3 dòng lệnh chuẩn này:

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ----------------------------------------

            // Chạy Form Menu đầu tiên
            try
            {
                Application.Run(new Menu());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chạy chương trình: " + ex.Message);
            }
        }
    }
}