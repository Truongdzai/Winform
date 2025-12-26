using System;
using System.Drawing; // Cần để dùng Point, Size, Image
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai26 : Form
    {
        // 1. Khai báo biến toàn cục
        PictureBox pbEgg = new PictureBox();
        System.Windows.Forms.Timer tmEgg = new System.Windows.Forms.Timer();
        int xEgg = 300; // Vị trí ngang cố định
        int yEgg = 0;   // Vị trí dọc (bắt đầu từ trên cùng)
        int xDelta = 3; // (Slide có khai báo nhưng bài này chưa dùng tới di chuyển ngang)
        int yDelta = 3; // Tốc độ rơi

        public Bai26()
        {
            InitializeComponent();
        }

        // 2. Form Load: Cấu hình trứng và Timer
        private void Form1_Load(object sender, EventArgs e)
        {
            // Cấu hình Timer
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            // Cấu hình Quả trứng
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(100, 100);
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;

            // Thêm vào Form
            this.Controls.Add(pbEgg);

            // Load ảnh trứng nguyên
            // Dùng try-catch để tránh lỗi nếu bạn quên copy ảnh
            try
            {
                pbEgg.Image = Image.FromFile("Images/egg_gold.png");
            }
            catch
            {
                MessageBox.Show("Chưa tìm thấy ảnh trong thư mục Images!");
                pbEgg.BackColor = Color.Yellow; // Màu vàng thay thế nếu thiếu ảnh
            }
        }

        // 3. Sự kiện Timer: Xử lý rơi và vỡ
        void tmEgg_Tick(object sender, EventArgs e)
        {
            // Tăng tọa độ Y để trứng rơi xuống
            yEgg += yDelta;

            // Kiểm tra va chạm đáy (Khi trứng chạm mép dưới cửa sổ)
            if (yEgg > this.ClientSize.Height - pbEgg.Height || yEgg <= 0)
            {
                // Đổi sang ảnh trứng vỡ
                try
                {
                    pbEgg.Image = Image.FromFile("Images/egg_gold_broken.png");
                }
                catch
                {
                    pbEgg.BackColor = Color.Red; // Màu đỏ nếu thiếu ảnh
                }

                // (Mở rộng): Thường game sẽ dừng lại hoặc reset trứng ở đây
                // tmEgg.Stop(); 
            }

            // Cập nhật vị trí mới
            pbEgg.Location = new Point(xEgg, yEgg);
        }
    }
}