using System.Windows.Forms;
using System.Drawing; // Cần thêm cái này để dùng màu sắc (Color)

namespace Example01
{
    // "partial" nghĩa là class này chỉ là một phần, phần còn lại nằm ở file Designer bên dưới
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Hàm này BẮT BUỘC phải có đầu tiên để vẽ các nút bấm, ô nhập liệu...
            InitializeComponent();

            // --- Code của em viết thêm ở đây (giống Slide 13) ---

            // Dòng này sẽ chạy sau khi Form được thiết kế xong
            this.Text = "Calculator Code";

            // Thử đổi màu nền bằng code xem sao
            this.BackColor = Color.WhiteSmoke;
        }
    }
}