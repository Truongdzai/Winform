using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Form1 : Form
    {
        // Khai báo 3 màn hình
        Login l = new Login();
        Question q = new Question();
        Finish f = new Finish();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Đặt vị trí cho các UserControl trùng khớp nhau
            l.Location = new Point(0, 0);
            q.Location = new Point(0, 0);
            f.Location = new Point(0, 0);

            // Mặc định thêm màn hình Login vào trước
            this.Controls.Add(l);

            // --- Đăng ký sự kiện Click cho các nút trong UserControl ---
            // (Vì chúng ta đã set Modifiers = Public trong Designer nên mới gọi được l.btLogin)
            l.btLogin.Click += new EventHandler(btLogin_Click);
            q.btFinish.Click += new EventHandler(btFinish_Click);
            q.btPrev.Click += new EventHandler(btPrev_Click);
        }

        // Sự kiện: Từ Login -> Question
        private void btLogin_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(l); // Gỡ màn hình đăng nhập
            this.Controls.Add(q);    // Hiện màn hình câu hỏi
        }

        // Sự kiện: Từ Question -> Login (Quay lại)
        private void btPrev_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(q); // Gỡ màn hình câu hỏi
            this.Controls.Add(l);    // Hiện lại màn hình đăng nhập
        }

        // Sự kiện: Từ Question -> Finish (Nộp bài)
        private void btFinish_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(q); // Gỡ màn hình câu hỏi
            this.Controls.Add(f);    // Hiện màn hình kết quả
        }
    }
}