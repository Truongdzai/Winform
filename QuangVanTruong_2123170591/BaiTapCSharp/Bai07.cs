using System;
using System.Windows.Forms;

namespace WinFormsApp_Article // Nhớ đổi tên namespace nếu của bạn khác
{
    public partial class Bai07 : Form
    {
        public Bai07()
        {
            InitializeComponent();

            // Gắn sự kiện thủ công nếu bên Designer chưa gắn, 
            // hoặc để đảm bảo logic hoạt động đúng với biến tbYear
            this.tbYear.KeyPress += new KeyPressEventHandler(tbYear_KeyPress);
        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra: Nếu không phải phím điều khiển VÀ không phải số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn không cho nhập
            }
        }
    }
}