using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai28 : Form
    {
        // --- KHAI BÁO BIẾN ---
        PictureBox pbBasket = new PictureBox();
        PictureBox pbEgg = new PictureBox();
        PictureBox pbChicken = new PictureBox();

        System.Windows.Forms.Timer tmEgg = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer tmChicken = new System.Windows.Forms.Timer();

        // Tọa độ và Tốc độ GIỎ
        int xBasket = 250;
        int yBasket = 500;
        int xDeltaBasketBase = 20; // Tốc độ gốc
        int xDeltaBasket = 20;     // Tốc độ hiện tại

        // Tọa độ và Tốc độ GÀ
        int xChicken = 300;
        int yChicken = 10;
        int xDeltaChickenBase = 5; // Tốc độ gốc
        int xDeltaChicken = 5;     // Tốc độ hiện tại (có thể âm/dương)

        // Tọa độ và Tốc độ TRỨNG
        int xEgg = 300;
        int yEgg = 10;
        int yDeltaEggBase = 5;     // Tốc độ gốc
        int yDeltaEgg = 5;         // Tốc độ hiện tại

        // Biến quản lý Game
        int score = 0;
        int level = 1;
        Label lblScore = new Label(); // Hiển thị điểm số

        public Bai28()
        {
            InitializeComponent();
        }

        private void Bai28_Load(object sender, EventArgs e)
        {
            // Thiết lập Timer
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;

            tmChicken.Interval = 10;
            tmChicken.Tick += tmChicken_Tick;

            // Setup GIỎ
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.Size = new Size(80, 80);
            pbBasket.BackColor = Color.Transparent;
            this.Controls.Add(pbBasket);

            // Setup TRỨNG
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(40, 50);
            pbEgg.BackColor = Color.Transparent;
            this.Controls.Add(pbEgg);

            // Setup GÀ
            pbChicken.SizeMode = PictureBoxSizeMode.StretchImage;
            pbChicken.Size = new Size(100, 100);
            pbChicken.BackColor = Color.Transparent;
            this.Controls.Add(pbChicken);

            // Setup Bảng Điểm
            lblScore.AutoSize = true;
            lblScore.Location = new Point(10, 10);
            lblScore.Font = new Font("Arial", 12, FontStyle.Bold);
            lblScore.ForeColor = Color.Red;
            this.Controls.Add(lblScore);

            // Load Ảnh
            LoadImages();

            // Bắt đầu game
            StartNewGame();
        }

        void LoadImages()
        {
            try
            {
                pbBasket.Image = Image.FromFile("Images/basket.png");
                pbEgg.Image = Image.FromFile("Images/egg_gold.png");
                pbChicken.Image = Image.FromFile("Images/chicken.png");
            }
            catch
            {
                pbBasket.BackColor = Color.Brown;
                pbEgg.BackColor = Color.Yellow;
                pbChicken.BackColor = Color.Orange;
            }
        }

        void StartNewGame()
        {
            score = 0;
            level = 1;
            ResetSpeed(); // Đặt lại tốc độ ban đầu
            UpdateScoreBoard();

            // Reset vị trí
            xBasket = (this.ClientSize.Width - pbBasket.Width) / 2;
            pbBasket.Location = new Point(xBasket, yBasket);

            ResetEgg();

            tmEgg.Start();
            tmChicken.Start();
        }

        void ResetSpeed()
        {
            // Reset về tốc độ cơ bản
            xDeltaBasket = xDeltaBasketBase;
            // Giữ chiều chuyển động của gà nhưng reset độ lớn vận tốc
            if (xDeltaChicken > 0) xDeltaChicken = xDeltaChickenBase;
            else xDeltaChicken = -xDeltaChickenBase;
            yDeltaEgg = yDeltaEggBase;
        }

        void UpdateLevel()
        {
            // Công thức: Level = 1 + (Điểm / 5)
            int newLevel = 1 + (score / 5);

            if (newLevel > level)
            {
                level = newLevel;
                // Tăng độ khó:
                // Tốc độ trứng tăng thêm 5 đơn vị mỗi cấp
                yDeltaEgg = yDeltaEggBase + (level - 1) * 5;

                // Tốc độ gà tăng thêm 2 đơn vị mỗi cấp
                int speedChicken = xDeltaChickenBase + (level - 1) * 2;
                if (xDeltaChicken > 0) xDeltaChicken = speedChicken;
                else xDeltaChicken = -speedChicken;

                // Tốc độ giỏ tăng thêm 10 đơn vị mỗi cấp để kịp bắt trứng
                xDeltaBasket = xDeltaBasketBase + (level - 1) * 10;
            }
        }

        void UpdateScoreBoard()
        {
            lblScore.Text = "Score: " + score + " | Level: " + level;
        }

        void GameOver()
        {
            tmEgg.Stop();
            tmChicken.Stop();

            // Đổi ảnh trứng vỡ
            try { pbEgg.Image = Image.FromFile("Images/egg_gold_broken.png"); } catch { }

            DialogResult res = MessageBox.Show(
                "GAME OVER!\nĐiểm của bạn: " + score + "\nBạn có muốn chơi lại không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                // Chơi lại -> Khôi phục ảnh trứng và reset game
                try { pbEgg.Image = Image.FromFile("Images/egg_gold.png"); } catch { }
                StartNewGame();
            }
            else
            {
                this.Close(); // Thoát Form
            }
        }

        // --- LOGIC GÀ ---
        void tmChicken_Tick(object sender, EventArgs e)
        {
            xChicken += xDeltaChicken;

            if (xChicken > this.ClientSize.Width - pbChicken.Width || xChicken <= 0)
            {
                xDeltaChicken = -xDeltaChicken;
            }
            pbChicken.Location = new Point(xChicken, yChicken);
        }

        // --- LOGIC TRỨNG ---
        void tmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;

            // A. Kiểm tra va chạm ĐẤY (Thua cuộc)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                GameOver();
                return; // Dừng xử lý tiếp
            }

            // B. Kiểm tra va chạm GIỎ (Hứng được)
            if (pbEgg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                score++;
                UpdateLevel();
                UpdateScoreBoard();
                ResetEgg();
            }

            pbEgg.Location = new Point(xEgg, yEgg);
        }

        void ResetEgg()
        {
            yEgg = yChicken + 50;
            xEgg = pbChicken.Location.X + 25;
        }

        // --- LOGIC GIỎ (PHÍM BẤM) ---
        private void Bai28_KeyDown(object sender, KeyEventArgs e)
        {
            // Phím Phải
            if (e.KeyValue == 39 && (xBasket < this.ClientSize.Width - pbBasket.Width))
            {
                xBasket += xDeltaBasket;
            }

            // Phím Trái
            if (e.KeyValue == 37 && (xBasket > 0))
            {
                xBasket -= xDeltaBasket;
            }

            pbBasket.Location = new Point(xBasket, yBasket);
        }
    }
}