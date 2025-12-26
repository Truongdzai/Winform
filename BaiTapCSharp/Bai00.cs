using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai00 : Form
    {
        public Bai00()
        {
            InitializeComponent();
        }

        // Sự kiện Form Load: Hiện size ngay khi mở lên
        private void Bai00_Load(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        // Sự kiện Resize: Chạy liên tục KHI ĐANG KÉO giãn form
        private void Bai00_Resize(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        // Viết hàm riêng để tránh lặp code
        private void UpdateTitle()
        {
            this.Text = this.Size.Width.ToString() + " - " + this.Size.Height.ToString();
        }
    }
}