using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai27 : Form
    {
        // --- PHẦN 1: KHAI BÁO BIẾN (Slide 173) ---

        // Biến cho QUẢ TRỨNG
        PictureBox pbEgg = new PictureBox();
        System.Windows.Forms.Timer tmEgg = new System.Windows.Forms.Timer();
        int xEgg = 300;
        int yEgg = 0;
        int yDelta = 5; // Tốc độ rơi

        // Biến cho CÁI GIỎ (Mới thêm ở Bài 27)
        PictureBox pbBasket = new PictureBox();
        int xBasket = 250;
        int yBasket = 500; // Vị trí giỏ nằm ở dưới đáy
        int xDeltaBasket = 30; // Tốc độ di chuyển của giỏ

        public Bai27()
        {
            InitializeComponent();
        }

        // --- PHẦN 2: KHỞI TẠO GAME (Slide 174) ---
        private void Bai27_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình Timer cho trứng rơi
            tmEgg.Interval = 20;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            // 2. Cấu hình Quả trứng
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 65);
            pbEgg.BackColor = Color.Transparent;
            pbEgg.Location = new Point(xEgg, yEgg);
            this.Controls.Add(pbEgg);

            // 3. Cấu hình Cái Giỏ (Slide 174)
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.Size = new Size(100, 100);
            pbBasket.BackColor = Color.Transparent;
            pbBasket.Location = new Point(xBasket, yBasket);
            this.Controls.Add(pbBasket);

            // Load hình ảnh (Dùng try-catch để tránh lỗi)
            try
            {
                pbEgg.Image = Image.FromFile("Images/egg_gold.png");
                pbBasket.Image = Image.FromFile("Images/basket.png");
            }
            catch
            {
                pbEgg.BackColor = Color.Yellow; // Màu thay thế nếu thiếu ảnh
                pbBasket.BackColor = Color.Brown;
            }
        }

        // --- PHẦN 3: LOGIC TRỨNG RƠI ---
        void tmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDelta;

            // Nếu trứng chạm đáy (Vỡ)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                // Reset trứng lên trên để rơi tiếp (Tạo vòng lặp game)
                yEgg = 0;
                // Random vị trí rơi mới cho thú vị
                Random rnd = new Random();
                xEgg = rnd.Next(0, this.ClientSize.Width - pbEgg.Width);

                // Đổi lại ảnh trứng nguyên (nếu trước đó bị vỡ)
                try { pbEgg.Image = Image.FromFile("Images/egg_gold.png"); } catch { }
            }

            // Cập nhật vị trí
            pbEgg.Location = new Point(xEgg, yEgg);
        }

        // --- PHẦN 4: LOGIC DI CHUYỂN GIỎ (Slide 174) ---
        private void Bai27_KeyDown(object sender, KeyEventArgs e)
        {
            // Phím Mũi tên Phải (Right Arrow - KeyValue 39)
            // Và kiểm tra biên phải để giỏ không chạy ra ngoài
            if (e.KeyValue == 39 && (xBasket < this.ClientSize.Width - pbBasket.Width))
            {
                xBasket += xDeltaBasket;
            }

            // Phím Mũi tên Trái (Left Arrow - KeyValue 37)
            // Và kiểm tra biên trái
            if (e.KeyValue == 37 && (xBasket > 0))
            {
                xBasket -= xDeltaBasket;
            }

            // Cập nhật vị trí giỏ
            pbBasket.Location = new Point(xBasket, yBasket);
        }
    }
}