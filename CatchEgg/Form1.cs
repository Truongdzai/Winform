using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CatchEgg
{
    public partial class Form1 : Form
    {
        // --- PictureBox ---
        private PictureBox pbBasket;
        private PictureBox pbEgg;
        private PictureBox pbChicken;

        // --- Timer WinForms ---
        private System.Windows.Forms.Timer tmEgg;
        private System.Windows.Forms.Timer tmChicken;

        // --- Label Game Over ---
        private Label lblGameOver;

        // --- trạng thái game ---
        private bool isGameOver = false;

        // --- vị trí & tốc độ rổ ---
        private int xBasket = 300;
        private int yBasket = 550;
        private int xDeltaBasket = 30;

        // --- vị trí & tốc độ gà ---
        private int xChicken = 300;
        private int yChicken = 10;
        private int xDeltaChicken = 5;

        // --- vị trí & tốc độ trứng ---
        private int xEgg;
        private int yEgg;
        private int yDeltaEgg = 3;

        // Đường dẫn thư mục Images trong bin\Debug\net8.0-windows\Images
        private string ImagesPath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;   // vẽ mượt hơn
            this.KeyPreview = true;       // Form bắt phím trước control con

            this.KeyDown += Form1_KeyDown;

            InitializeGame();
        }

        // ================== KHỞI TẠO GAME ==================
        private void InitializeGame()
        {
            // ===== TIMER =====
            tmEgg = new System.Windows.Forms.Timer();
            tmChicken = new System.Windows.Forms.Timer();

            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            tmEgg.Start();

            tmChicken.Interval = 10;
            tmChicken.Tick += tmChicken_Tick;
            tmChicken.Start();

            // ===== RỔ =====
            pbBasket = new PictureBox();
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.Size = new Size(70, 70);
            pbBasket.Location = new Point(xBasket, yBasket);
            pbBasket.BackColor = Color.Transparent;
            this.Controls.Add(pbBasket);

            // ===== TRỨNG =====
            pbEgg = new PictureBox();
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 50);
            pbEgg.BackColor = Color.Transparent;
            this.Controls.Add(pbEgg);

            // ===== GÀ =====
            pbChicken = new PictureBox();
            pbChicken.SizeMode = PictureBoxSizeMode.StretchImage;
            pbChicken.Size = new Size(100, 100);
            pbChicken.Location = new Point(xChicken, yChicken);
            pbChicken.BackColor = Color.Transparent;
            this.Controls.Add(pbChicken);

            // ===== LABEL GAME OVER =====
            lblGameOver = new Label();
            lblGameOver.AutoSize = true;
            lblGameOver.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblGameOver.ForeColor = Color.Red;
            lblGameOver.Text = "GAME OVER - Nhấn Enter để thoát";
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Visible = false;
            this.Controls.Add(lblGameOver);

            // ===== LOAD ẢNH =====
            try
            {
                pbBasket.Image = Image.FromFile(Path.Combine(ImagesPath, "basket.jpg"));
                pbEgg.Image = Image.FromFile(Path.Combine(ImagesPath, "egg_gold.jpg"));
                pbChicken.Image = Image.FromFile(Path.Combine(ImagesPath, "chicken.jpg"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load ảnh: " + ex.Message);
            }

            // Đặt vị trí trứng ban đầu ngay dưới con gà
            ResetEgg();
            CenterGameOverLabel();
        }

        // ================== ĐẶT LẠI VỊ TRÍ TRỨNG ==================
        private void ResetEgg()
        {
            // trứng rơi từ dưới con gà, căn giữa theo chiều ngang
            yEgg = pbChicken.Bottom;
            xEgg = pbChicken.Left + (pbChicken.Width - pbEgg.Width) / 2;

            pbEgg.Location = new Point(xEgg, yEgg);
        }

        // ================== CANH GIỮA LABEL GAME OVER ==================
        private void CenterGameOverLabel()
        {
            if (lblGameOver == null) return;

            int x = (this.ClientSize.Width - lblGameOver.Width) / 2;
            int y = (this.ClientSize.Height - lblGameOver.Height) / 2;
            lblGameOver.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            lblGameOver.BringToFront();
        }

        // ================== TIMER TRỨNG ==================
        private void tmEgg_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            // Trứng rơi xuống
            yEgg += yDeltaEgg;

            // ====== GAME OVER: trứng chạm đất ======
            if (isGameOver) return;

            // Trứng rơi xuống
            yEgg += yDeltaEgg;

            // ====== GAME OVER: trứng chạm đất ======
            if (yEgg >= this.ClientSize.Height - pbEgg.Height)
            {
                try
                {
                    pbEgg.Image = Image.FromFile(
                        Path.Combine(ImagesPath, "egg_gold_broken.jpg"));
                }
                catch { }

                // DỪNG GAME
                tmEgg.Stop();
                tmChicken.Stop();
                isGameOver = true;

                // Hiện chữ GAME OVER
                lblGameOver.Visible = true;
                CenterGameOverLabel();

                return;  // RẤT QUAN TRỌNG — không xử lý tiếp
            }
            // ====== KIỂM TRA VA CHẠM VỚI RỔ ======
            Rectangle intersect = Rectangle.Intersect(pbEgg.Bounds, pbBasket.Bounds);

            if (!intersect.IsEmpty)
            {
                // Bắt được trứng
                try
                {
                    pbEgg.Image = Image.FromFile(
                        Path.Combine(ImagesPath, "egg_gold.jpg"));
                }
                catch { }

                // Reset trứng rơi từ vị trí gà
                ResetEgg();
            }

            // Cập nhật vị trí hiển thị trứng
            pbEgg.Location = new Point(xEgg, yEgg);
        }

        // ================== TIMER GÀ ==================
        private void tmChicken_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            xChicken += xDeltaChicken;

            // Đổi hướng khi chạm biên
            if (xChicken > this.ClientSize.Width - pbChicken.Width || xChicken <= 0)
            {
                xDeltaChicken = -xDeltaChicken;
            }

            pbChicken.Location = new Point(xChicken, yChicken);
        }

        // ================== BẮT PHÍM ĐIỀU KHIỂN RỔ / THOÁT GAME ==================
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameOver)
            {
                // Khi Game Over, nhấn Enter để thoát chương trình
                if (e.KeyCode == Keys.Enter)
                {
                    Application.Exit();
                }
                return;
            }

            if (e.KeyCode == Keys.Right &&
                xBasket < this.ClientSize.Width - pbBasket.Width)
            {
                xBasket += xDeltaBasket;
            }
            else if (e.KeyCode == Keys.Left && xBasket > 0)
            {
                xBasket -= xDeltaBasket;
            }

            pbBasket.Location = new Point(xBasket, yBasket);
        }

        // Nếu form resize thì canh lại label Game Over cho vào giữa (nếu bạn resize form)
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterGameOverLabel();
        }
    }
}
