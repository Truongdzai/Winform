using Microsoft.Data.SqlClient; 
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ADO
{
    public partial class LoginForm : Form
    {
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUser.Text) || string.IsNullOrWhiteSpace(tbPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    // Truy vấn kiểm tra tài khoản
                    string sql = "SELECT COUNT(*) FROM users WHERE username = @u AND password = @p";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", tbUser.Text);
                        cmd.Parameters.AddWithValue("@p", tbPass.Text); // Lưu ý: Thực tế nên mã hóa mật khẩu (MD5/SHA)

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Ẩn form đăng nhập
                            this.Hide();

                            MainForm mainForm = new MainForm();
                            mainForm.ShowDialog(); // Dùng ShowDialog để khi tắt Form1 thì code sẽ chạy tiếp dòng dưới

                            // Khi Form1 đóng lại thì đóng luôn ứng dụng
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}