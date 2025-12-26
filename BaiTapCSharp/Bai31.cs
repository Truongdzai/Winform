using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D; // Cần thư viện này để vẽ đẹp
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai31 : Form
    {
        // --- CẤU HÌNH HỆ THỐNG ---
        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();
        HashSet<Keys> pressedKeys = new HashSet<Keys>(); // Lưu các phím đang giữ

        // --- DỮ LIỆU GAME ---
        int deaths = 0;
        int currentLevel = 1;
        bool levelCompleted = false;

        // --- ĐỐI TƯỢNG ---
        Player player;
        List<Enemy> enemies = new List<Enemy>();
        List<Coin> coins = new List<Coin>();
        Rectangle startZone;
        Rectangle endZone;

        public Bai31()
        {
            InitializeComponent();

            // Cấu hình đồ họa mượt (Double Buffer)
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(180, 181, 254); // Màu nền tím nhạt chuyên nghiệp

            // Sự kiện Input
            this.KeyDown += (s, e) => { if (!pressedKeys.Contains(e.KeyCode)) pressedKeys.Add(e.KeyCode); };
            this.KeyUp += (s, e) => { if (pressedKeys.Contains(e.KeyCode)) pressedKeys.Remove(e.KeyCode); };

            // Game Loop (60 FPS)
            tmGame.Interval = 16;
            tmGame.Tick += GameLoop;
            tmGame.Start();

            // Vẽ màn hình
            this.Paint += OnDraw;

            LoadLevel(1);
        }

        // --- HỆ THỐNG LEVEL ---
        void LoadLevel(int level)
        {
            currentLevel = level;
            enemies.Clear();
            coins.Clear();
            pressedKeys.Clear();
            levelCompleted = false;

            // Khởi tạo người chơi (Màu đỏ)
            player = new Player(50, 200);

            if (level == 1)
            {
                startZone = new Rectangle(0, 0, 100, 400);
                endZone = new Rectangle(500, 0, 100, 400);

                // Tạo 4 chấm xanh di chuyển dọc (Đơn giản nhưng nhanh)
                enemies.Add(new Enemy(200, 50, 0, 6, 200, 50, 200, 350));
                enemies.Add(new Enemy(280, 350, 0, -6, 280, 50, 280, 350));
                enemies.Add(new Enemy(360, 50, 0, 6, 360, 50, 360, 350));
                enemies.Add(new Enemy(440, 350, 0, -6, 440, 50, 440, 350));

                // Tạo coin vàng cần ăn
                coins.Add(new Coin(320, 200));
            }
            else if (level == 2)
            {
                startZone = new Rectangle(0, 0, 80, 400);
                endZone = new Rectangle(520, 0, 80, 400);

                // Tạo "Cối xay gió" - Ma trận chấm xanh
                for (int i = 0; i < 5; i++)
                {
                    int speed = (i % 2 == 0) ? 8 : -8; // So le tốc độ
                    enemies.Add(new Enemy(120 + i * 70, 200, 0, speed, 0, 0, 0, 0)); // Loại này chỉ chạy dọc tự do
                }

                coins.Add(new Coin(260, 50));
                coins.Add(new Coin(260, 350));
            }
            else
            {
                tmGame.Stop();
                MessageBox.Show($"YOU WIN!\nTotal Deaths: {deaths}");
                this.Close();
            }
        }

        // --- VÒNG LẶP CHÍNH (UPDATE) ---
        private void GameLoop(object sender, EventArgs e)
        {
            // 1. Di chuyển Player (Hỗ trợ đi chéo)
            float speed = 3.5f;
            float dx = 0, dy = 0;
            if (pressedKeys.Contains(Keys.Left)) dx -= speed;
            if (pressedKeys.Contains(Keys.Right)) dx += speed;
            if (pressedKeys.Contains(Keys.Up)) dy -= speed;
            if (pressedKeys.Contains(Keys.Down)) dy += speed;

            player.Move(dx, dy, this.ClientSize.Width, this.ClientSize.Height);

            // 2. Di chuyển Enemies
            foreach (var enemy in enemies)
            {
                enemy.Update(this.ClientSize.Height);
                // Kiểm tra va chạm (Chết)
                if (player.Bounds.IntersectsWith(enemy.Bounds))
                {
                    PlayerDie();
                    return;
                }
            }

            // 3. Ăn Coin
            for (int i = coins.Count - 1; i >= 0; i--)
            {
                if (player.Bounds.IntersectsWith(coins[i].Bounds))
                {
                    coins.RemoveAt(i);
                }
            }

            // 4. Kiểm tra Thắng (Về đích và hết coin)
            if (coins.Count == 0 && player.Bounds.IntersectsWith(endZone))
            {
                if (!levelCompleted)
                {
                    levelCompleted = true;
                    LoadLevel(currentLevel + 1);
                }
            }

            this.Invalidate(); // Vẽ lại
        }

        void PlayerDie()
        {
            deaths++;
            this.BackColor = Color.Red; // Nháy màn hình đỏ
            this.Update(); // Ép vẽ ngay lập tức
            System.Threading.Thread.Sleep(50); // Khựng lại 1 chút tạo cảm giác đau
            this.BackColor = Color.FromArgb(180, 181, 254);

            // Reset vị trí
            player.X = 50;
            player.Y = 200;

            // Reset coins của màn đó (Rage game phải ăn lại từ đầu)
            if (currentLevel == 1 && coins.Count < 1) coins.Add(new Coin(320, 200));
            if (currentLevel == 2 && coins.Count < 2) { coins.Clear(); coins.Add(new Coin(260, 50)); coins.Add(new Coin(260, 350)); }
        }

        // --- VẼ ĐỒ HỌA (RENDER) ---
        private void OnDraw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Khử răng cưa -> Nhìn rất mượt

            // Vẽ vùng xuất phát / về đích
            g.FillRectangle(new SolidBrush(Color.FromArgb(181, 254, 180)), startZone); // Xanh nhạt
            g.FillRectangle(new SolidBrush(Color.FromArgb(181, 254, 180)), endZone);   // Xanh nhạt

            // Vẽ thông tin
            g.DrawString($"DEATHS: {deaths}", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 10, 10);
            g.DrawString($"LEVEL: {currentLevel}/2", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 500, 10);

            // Vẽ Coins
            foreach (var coin in coins)
            {
                g.FillEllipse(Brushes.Gold, coin.Bounds);
                g.DrawEllipse(Pens.Orange, coin.Bounds); // Viền cho đẹp
            }

            // Vẽ Enemies (Chấm xanh dương)
            Brush enemyBrush = Brushes.Blue;
            foreach (var enemy in enemies)
            {
                g.FillEllipse(enemyBrush, enemy.Bounds);
            }

            // Vẽ Player (Vuông đỏ - Viền đen)
            g.FillRectangle(Brushes.Red, player.Bounds);
            g.DrawRectangle(Pens.Black, player.Bounds.X, player.Bounds.Y, player.Bounds.Width, player.Bounds.Height);
        }

        // --- INNER CLASSES (CẤU TRÚC GAME) ---

        // Lớp Người chơi
        class Player
        {
            public float X, Y;
            public float Size = 25; // Hình vuông 25x25
            public RectangleF Bounds => new RectangleF(X, Y, Size, Size);

            public Player(float x, float y) { X = x; Y = y; }

            public void Move(float dx, float dy, int w, int h)
            {
                X += dx;
                Y += dy;
                // Chặn biên không cho chạy ra ngoài
                if (X < 0) X = 0;
                if (Y < 0) Y = 0;
                if (X > w - Size) X = w - Size;
                if (Y > h - Size) Y = h - Size;
            }
        }

        // Lớp Đồng xu
        class Coin
        {
            public float X, Y;
            public float Size = 18;
            public RectangleF Bounds => new RectangleF(X, Y, Size, Size);
            public Coin(float x, float y) { X = x; Y = y; }
        }

        // Lớp Kẻ địch
        class Enemy
        {
            public float X, Y;
            public float Size = 22;
            public float SpeedX, SpeedY;

            // Giới hạn vùng đi tuần tra (Patrol)
            float minX, minY, maxX, maxY;
            bool usePatrol; // Có dùng giới hạn hay chạy tự do va tường?

            public RectangleF Bounds => new RectangleF(X, Y, Size, Size);

            public Enemy(float x, float y, float sx, float sy, float minx, float miny, float maxx, float maxy)
            {
                X = x; Y = y; SpeedX = sx; SpeedY = sy;
                minX = minx; minY = miny; maxX = maxx; maxY = maxy;
                usePatrol = (maxx > 0 || maxy > 0);
            }

            public void Update(int screenHeight)
            {
                X += SpeedX;
                Y += SpeedY;

                if (usePatrol)
                {
                    // Logic đi tuần tra theo điểm định sẵn
                    if (SpeedY > 0 && Y >= maxY) SpeedY = -SpeedY;
                    if (SpeedY < 0 && Y <= minY) SpeedY = -SpeedY;
                }
                else
                {
                    // Logic đập tường nảy lại (Cho Level 2)
                    if (Y > screenHeight - Size || Y < 0) SpeedY = -SpeedY;
                }
            }
        }
    }
}