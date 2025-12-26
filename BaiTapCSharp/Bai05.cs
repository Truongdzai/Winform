using System;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp_Article
{
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            InitializeComponent();
            // Đảm bảo KeyPreview luôn bật (dù đã chỉnh bên Designer thì viết đây cho chắc)
            this.KeyPreview = true;
        }

        private void Bai05_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // Lưu ý: Đổi đường dẫn nếu máy bạn không có ổ D
                // Ví dụ lưu ngay tại thư mục chạy phần mềm: "Key_Logger.txt"
                string path = @"D:\Key_Logger.txt";

                // true nghĩa là ghi nối tiếp (append), không xóa nội dung cũ
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.Write(e.KeyCode + " ");
                }
            } 
            catch (Exception ex)
            {
                // Có thể tắt dòng này nếu thấy phiền khi gõ phím liên tục mà lỗi file
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }
    }
}