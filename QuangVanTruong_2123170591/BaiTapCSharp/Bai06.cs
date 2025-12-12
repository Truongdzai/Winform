using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Article // Nhớ đổi tên namespace nếu của bạn khác
{
    public partial class Bai06 : Form
    {
        public Bai06()
        {
            InitializeComponent();
            // Lưu ý: Không khai báo lại "Button bt_OK" ở đây nữa
            // Vì nó đã có bên Bai06.Designer.cs rồi
        }

        // Sự kiện Click đã được nối bên file Designer, 
        // nhưng ta viết hàm xử lý ở đây cho chắc chắn khớp tên.
        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.Text = "Article for Button";
            this.Size = new Size(500, 500);
        }
    }
}