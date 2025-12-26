using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai25 : Form
    {
        // 1. Khai báo biến toàn cục
        PictureBox pb = new PictureBox();
        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();
        int xBall = 0;      // Tọa độ X
        int yBall = 0;      // Tọa độ Y
        int xDelta = 5;     // Tốc độ di chuyển ngang (mỗi lần 5px)
        int yDelta = 5;     // Tốc độ di chuyển dọc (mỗi lần 5px)

        public Bai25()
        {
            InitializeComponent();
        }

        // 2. Form Load: Thiết lập Game
        private void Bai25_Load(object sender, EventArgs e)
        {
            // Cấu hình Timer
            tmGame.Interval = 10; // Tốc độ game (càng nhỏ càng nhanh)
            tmGame.Tick += new EventHandler(tmGame_Tick); // Gán sự kiện Tick
            tmGame.Start();

            // Cấu hình Quả bóng
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new Size(50, 50); // Kích thước bóng
            pb.Location = new Point(xBall, yBall);

            // Xử lý ảnh (Dùng try-catch để tránh lỗi nếu không có file)
            try
            {
                // Bạn hãy sửa đường dẫn này trỏ đến file ảnh trên máy bạn
                pb.ImageLocation = @"D:\ball.png";
            }
            catch
            {
                pb.BackColor = Color.Red; // Nếu không thấy ảnh thì hiện hình vuông đỏ
            }

            this.Controls.Add(pb); // Đưa bóng vào sân
        }

        // 3. Sự kiện Game Loop (Chạy liên tục)
        void tmGame_Tick(object sender, EventArgs e)
        {
            // Thay đổi vị trí
            xBall += xDelta;
            yBall += yDelta;

            // Xử lý va chạm biên NGANG (Trái/Phải)
            // Nếu bóng chạm mép phải HOẶC chạm mép trái
            if (xBall > this.ClientSize.Width - pb.Width || xBall <= 0)
            {
                xDelta = -xDelta; // Đổi chiều chuyển động
            }

            // Xử lý va chạm biên DỌC (Trên/Dưới)
            // Nếu bóng chạm mép dưới HOẶC chạm mép trên
            if (yBall > this.ClientSize.Height - pb.Height || yBall <= 0)
            {
                yDelta = -yDelta; // Đổi chiều chuyển động
            }

            // Cập nhật vị trí mới cho bóng
            pb.Location = new Point(xBall, yBall);
        }
    }
}