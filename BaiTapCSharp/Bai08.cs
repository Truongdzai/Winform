using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai08 : Form
    {
        public Bai08()
        {
            InitializeComponent();
        }

        // Xử lý nút CỘNG
        private void btCong_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x + y;
            tbKetQua.Text = kq.ToString(); // Ghi đè kết quả mới vào
        }

        // Xử lý nút NHÂN
        private void btNhan_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x * y;
            tbKetQua.Text = kq.ToString();
        }

        // Xử lý nút THOÁT
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai08_Load(object sender, EventArgs e)
        {

        }
    }
}