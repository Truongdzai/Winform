using System;
using System.Windows.Forms;
using System.IO; // Cần thư viện này để lưu file

namespace WinFormsApp_Article
{
    public partial class Bai09 : Form
    {
        public Bai09()
        {
            InitializeComponent();
        }

        // Nút CỘNG: Cộng dồn chuỗi (Append)
        private void btCong_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x + y;

            // "\r\n" là xuống dòng. Dùng phép cộng chuỗi để giữ lại lịch sử cũ.
            tbKetQua.Text = tbKetQua.Text + x.ToString() + " + " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

        // Nút NHÂN
        private void btNhan_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x * y;

            tbKetQua.Text = tbKetQua.Text + x.ToString() + " * " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

        // Nút LƯU FILE
        private void btLuu_Click(object sender, EventArgs e)
        {
            // true nghĩa là Append (ghi nối tiếp vào file, không xóa nội dung cũ)
            using (StreamWriter sw = new StreamWriter("Caculator.txt", true))
            {
                sw.Write(tbKetQua.Text);
            }
            MessageBox.Show("Đã lưu thành công!");
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}