using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai12 : Form
    {
        public Bai12()
        {
            InitializeComponent();
        }

        // Sự kiện Form Load: Chọn mặc định phần tử thứ 3 (index 2)
        private void Bai12_Load(object sender, EventArgs e)
        {
            cb_Faculty.SelectedIndex = 2;
        }

        // Sự kiện khi người dùng chọn mục khác
        private void cb_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_Faculty.SelectedIndex;
            tbDisplay.Text = "Bạn đã chọn khoa thứ: " + index.ToString();
        }

        // Sự kiện bấm nút OK: Lấy nội dung chữ
        private void bt_OK_Click(object sender, EventArgs e)
        {
            string item = cb_Faculty.SelectedItem.ToString();
            tbDisplay.Text = "Bạn là sinh viên khoa: " + item;
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form hiện tại
        }
    }
}