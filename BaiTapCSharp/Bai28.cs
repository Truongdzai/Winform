using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media; // <-- 1. Thêm thư viện âm thanh

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

        // --- KHAI BÁO NHẠC NỀN ---
        // Lưu ý: File wav phải nằm cùng thư mục với file .exe (bin/Debug/...)
        SoundPlayer bgMusic = new SoundPlayer("Nhacnengamehungtrung.wav");

        // Tọa độ và Tốc độ GIỎ
        int xBasket = 250;
        int yBasket = 500;
        int xDeltaBasketBase = 20;
        int xDeltaBasket = 20;

        // Tọa độ và Tốc độ GÀ
        int xChicken = 300;
        int yChicken = 10;
        int xDeltaChickenBase = 5;
        int xDeltaChicken = 5;

        // Tọa độ và Tốc độ TRỨNG
        int xEgg = 300;
        int yEgg = 10;
        int yDeltaEggBase = 5;
        int yDeltaEgg = 5;

        // Biến quản lý Game
        int score = 0;
        int level = 1;
        Label lblScore = new Label();

        public Bai28()
        {
            InitializeComponent();

            // --- CẤU HÌNH FORM ---
            this.ClientSize = new Size(600, 600);
            this.Text = "GAME HỨNG TRỨNG - NÔNG TRẠI VUI VẺ";
            this.DoubleBuffered = true;
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
            pbBasket.Size = new Size(100, 80);
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
            lblScore.Font = new Font("Arial", 14, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
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
                this.BackgroundImage = Image.FromFile("Images/background.png");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                pbBasket.BackColor = Color.Brown;
                pbEgg.BackColor = Color.Yellow;
                pbChicken.BackColor = Color.Orange;
                this.BackColor = Color.SkyBlue;
            }
        }

        void StartNewGame()
        {
            score = 0;
            level = 1;
            ResetSpeed();
            UpdateScoreBoard();

            // Reset vị trí
            xBasket = (this.ClientSize.Width - pbBasket.Width) / 2;
            yBasket = this.ClientSize.Height - pbBasket.Height - 20;
            pbBasket.Location = new Point(xBasket, yBasket);

            ResetEgg();

            tmEgg.Start();
            tmChicken.Start();

            // --- BẮT ĐẦU PHÁT NHẠC ---
            try
            {
                bgMusic.PlayLooping(); // Phát lặp lại liên tục
            }
            catch { } // Bỏ qua nếu lỗi file nhạc
        }

        void ResetSpeed()
        {
            xDeltaBasket = xDeltaBasketBase;
            if (xDeltaChicken > 0) xDeltaChicken = xDeltaChickenBase;
            else xDeltaChicken = -xDeltaChickenBase;
            yDeltaEgg = yDeltaEggBase;
        }

        void UpdateLevel()
        {
            int newLevel = 1 + (score / 5);

            if (newLevel > level)
            {
                level = newLevel;
                yDeltaEgg = yDeltaEggBase + (level - 1) * 3;

                int speedChicken = xDeltaChickenBase + (level - 1) * 2;
                if (xDeltaChicken > 0) xDeltaChicken = speedChicken;
                else xDeltaChicken = -speedChicken;

                xDeltaBasket = xDeltaBasketBase + (level - 1) * 5;
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

            // --- DỪNG NHẠC KHI CHẾT ---
            bgMusic.Stop();

            try { pbEgg.Image = Image.FromFile("Images/egg_gold_broken.png"); } catch { }

            DialogResult res = MessageBox.Show(
                "GÀ ĐẺ TRỨNG VÀNG!\nĐiểm của bạn: " + score + "\nBạn có muốn chơi lại không?",
                "Kết thúc",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try { pbEgg.Image = Image.FromFile("Images/egg_gold.png"); } catch { }
                StartNewGame(); // Hàm này sẽ gọi lại nhạc nền
            }
            else
            {
                this.Close();
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

            // A. Rơi xuống đất (Thua)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                GameOver();
                return;
            }

            // B. Hứng được (Cộng điểm)
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
            xEgg = pbChicken.Location.X + (pbChicken.Width / 2) - (pbEgg.Width / 2);
        }

        // --- LOGIC GIỎ (PHÍM BẤM) ---
        private void Bai28_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && (xBasket < this.ClientSize.Width - pbBasket.Width))
            {
                xBasket += xDeltaBasket;
            }

            if (e.KeyCode == Keys.Left && (xBasket > 0))
            {
                xBasket -= xDeltaBasket;
            }

            pbBasket.Location = new Point(xBasket, yBasket);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right)
            {
                Bai28_KeyDown(this, new KeyEventArgs(keyData));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}