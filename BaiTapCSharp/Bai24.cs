using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai24 : Form
    {
        int second = 0; // Biến đếm giây

        public Bai24()
        {
            InitializeComponent();
        }

        // Nút Start
        private void btStart_Click(object sender, EventArgs e)
        {
            tmStopwatch.Interval = 1000; // 1000ms = 1 giây chạy 1 lần
            tmStopwatch.Start();         // Bắt đầu đếm
        }

        // Nút Stop
        private void btStop_Click(object sender, EventArgs e)
        {
            tmStopwatch.Stop();          // Dừng đếm
        }

        // Sự kiện Tick: Chạy mỗi khi hết khoảng thời gian Interval (1 giây)
        private void tmStopwatch_Tick(object sender, EventArgs e)
        {
            second++; // Tăng giây lên 1

            // Format chuỗi dạng 00:00 (Phút:Giây) cho đẹp
            TimeSpan time = TimeSpan.FromSeconds(second);
            lblDisplay.Text = time.ToString(@"mm\:ss");

            // Hoặc dùng code đơn giản như slide:
            // lblDisplay.Text = second.ToString();
        }
    }
}