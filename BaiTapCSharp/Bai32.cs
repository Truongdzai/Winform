using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Media; // Thư viện âm thanh

namespace WinFormsApp_Article
{
    public partial class Bai32 : Form
    {
        // --- CẤU HÌNH ---
        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();
        Random rnd = new Random();

        // --- KHAI BÁO ÂM THANH ---
        SoundPlayer soundJump = new SoundPlayer("jump.wav");
        SoundPlayer soundScore = new SoundPlayer("score.wav");

        // --- TRẠNG THÁI GAME ---
        bool isGameOver = false;
        bool isPlaying = false; // Kiểm tra đã bắt đầu chơi chưa
        int score = 0;
        int highScore = 0;
        int gameSpeed = 6;
        float hoverY = 0; // Biến dùng cho hiệu ứng bay dập dìu lúc chờ

        // --- ĐỐI TƯỢNG ---
        Bird bird;
        List<Pipe> pipes = new List<Pipe>();
        int pipeSpawnTimer = 0;

        public Bai32()
        {
            InitializeComponent();

            // Cấu hình Form để game mượt
            this.DoubleBuffered = true;
            this.BackColor = Color.SkyBlue;
            this.KeyPreview = true; // Quan trọng để nhận phím Space

            // --- NẠP ÂM THANH (PRE-LOAD) ---
            // Giúp âm thanh phát ngay lập tức không bị trễ
            try
            {
                soundJump.Load();
                soundScore.Load();
            }
            catch
            {
                // Nếu không tìm thấy file nhạc thì bỏ qua, không báo lỗi
            }

            // Cấu hình Timer (60 FPS)
            tmGame.Interval = 15;
            tmGame.Tick += GameLoop;

            // Đăng ký sự kiện
            this.KeyDown += Bai32_KeyDown;
            this.Paint += OnDraw;

            // Khởi tạo game
            StartGame();
        }

        void StartGame()
        {
            isGameOver = false;
            isPlaying = false; // Vào game ở chế độ chờ
            score = 0;
            gameSpeed = 6;
            pipes.Clear();
            pipeSpawnTimer = 0;
            hoverY = 0;

            bird = new Bird(100, 250); // Vị trí xuất phát

            tmGame.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // --- 1. CHẾ ĐỘ CHỜ (LƠ LỬNG) ---
            if (!isPlaying)
            {
                // Hiệu ứng bay lên xuống nhẹ nhàng
                hoverY += 0.1f;
                bird.Y = 250 + (float)Math.Sin(hoverY) * 10;

                this.Invalidate(); // Vẽ lại rồi thoát, không tính toán tiếp
                return;
            }

            // --- 2. CHẾ ĐỘ CHƠI (GAME ĐANG CHẠY) ---

            // Cập nhật Chim
            bird.Update();

            // Sinh Ống mới
            pipeSpawnTimer++;
            if (pipeSpawnTimer > 70) // 70 nhịp sinh 1 ống
            {
                SpawnPipe();
                pipeSpawnTimer = 0;
            }

            // Di chuyển và kiểm tra Ống
            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                pipes[i].X -= gameSpeed; // Trôi sang trái

                // Kiểm tra ăn điểm
                if (!pipes[i].Passed && pipes[i].X + pipes[i].W < bird.X)
                {
                    score++;
                    pipes[i].Passed = true;

                    // Phát tiếng ăn điểm
                    PlaySoundSafe(soundScore);

                    // Logic tăng độ khó & lưu điểm cao
                    if (score > highScore) highScore = score;
                    if (score % 5 == 0) gameSpeed++;
                }

                // Xóa ống khi ra khỏi màn hình
                if (pipes[i].X < -100) pipes.RemoveAt(i);
            }

            // Kiểm tra va chạm (Chết)
            CheckCollision();

            // Vẽ lại màn hình
            this.Invalidate();
        }

        // Hàm phát nhạc an toàn
        void PlaySoundSafe(SoundPlayer sound)
        {
            try { sound.Play(); } catch { }
        }

        void SpawnPipe()
        {
            int gap = 140; // Độ rộng khe hở
            int height = rnd.Next(100, 350); // Chiều cao ngẫu nhiên
            pipes.Add(new Pipe(this.ClientSize.Width, height, gap));
        }

        void CheckCollision()
        {
            // Chạm đất hoặc bay quá cao
            if (bird.Y > this.ClientSize.Height - bird.Size || bird.Y < 0)
                GameOver();

            // Chạm ống
            Rectangle birdRect = bird.Bounds;
            foreach (var p in pipes)
            {
                if (birdRect.IntersectsWith(p.TopRect)) GameOver();
                if (birdRect.IntersectsWith(p.BottomRect)) GameOver();
            }
        }

        void GameOver()
        {
            tmGame.Stop();
            isGameOver = true;
            this.Invalidate();
        }

        // --- XỬ LÝ PHÍM BẤM ---
        private void Bai32_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (isGameOver)
                {
                    // Chết rồi -> Bấm Space để Reset
                    StartGame();
                }
                else if (!isPlaying)
                {
                    // Đang chờ -> Bấm Space để Bắt đầu
                    isPlaying = true;
                    bird.Jump();
                    PlaySoundSafe(soundJump);
                }
                else
                {
                    // Đang chơi -> Bấm Space để Nhảy
                    bird.Jump();
                    PlaySoundSafe(soundJump);
                }
            }
        }

        // --- VẼ ĐỒ HỌA (GDI+) ---
        private void OnDraw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. Vẽ Ống
            foreach (var p in pipes)
            {
                g.FillRectangle(Brushes.Green, p.TopRect);
                g.FillRectangle(Brushes.Green, p.BottomRect);
                g.DrawRectangle(Pens.Black, p.TopRect);
                g.DrawRectangle(Pens.Black, p.BottomRect);
            }

            // 2. Vẽ Chim
            g.FillRectangle(Brushes.Yellow, bird.Bounds);
            g.DrawRectangle(Pens.Black, bird.Bounds);
            // Trang trí mắt mỏ
            g.FillRectangle(Brushes.White, bird.X + 20, bird.Y + 5, 10, 10);
            g.FillRectangle(Brushes.Black, bird.X + 25, bird.Y + 8, 3, 3);
            g.FillRectangle(Brushes.OrangeRed, bird.X + 25, bird.Y + 20, 10, 8);

            // 3. Vẽ Sàn đất
            int floorHeight = 20;
            g.FillRectangle(Brushes.SandyBrown, 0, this.ClientSize.Height - floorHeight, this.ClientSize.Width, floorHeight);
            g.DrawLine(Pens.Black, 0, this.ClientSize.Height - floorHeight, this.ClientSize.Width, this.ClientSize.Height - floorHeight);

            // 4. Vẽ UI (Chữ trên màn hình)
            if (!isPlaying && !isGameOver)
            {
                // Màn hình chờ
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.DrawString("FLAPPY SQUARE", new Font("Arial", 24, FontStyle.Bold), Brushes.White, this.ClientSize.Width / 2, 150, sf);
                g.DrawString("Press SPACE to Start", new Font("Arial", 16, FontStyle.Bold), Brushes.DarkBlue, this.ClientSize.Width / 2, 200, sf);
            }
            else
            {
                // Màn hình chơi (Hiện điểm)
                g.DrawString("Score: " + score, new Font("Arial", 16, FontStyle.Bold), Brushes.White, 10, 10);
                g.DrawString("Best: " + highScore, new Font("Arial", 12), Brushes.White, 10, 35);
            }

            // 5. Màn hình Game Over
            if (isGameOver)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                // Lớp phủ mờ màu đen
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 0, 0)), this.ClientRectangle);

                g.DrawString("GAME OVER", new Font("Arial", 30, FontStyle.Bold), Brushes.Red, this.ClientRectangle, sf);
                g.DrawString("\n\nPress SPACE to Restart", new Font("Arial", 16, FontStyle.Bold), Brushes.White, this.ClientRectangle, sf);
            }
        }

        // --- CÁC CLASS CON ---
        class Bird
        {
            public float Y;
            public float VelocityY = 0;
            public float Gravity = 0.6f;  // Trọng lực
            public float JumpForce = -9f; // Lực nhảy
            public int X;
            public int Size = 35;

            public Rectangle Bounds => new Rectangle(X, (int)Y, Size, Size);
            public Bird(int x, int y) { X = x; Y = y; }

            public void Update()
            {
                VelocityY += Gravity;
                Y += VelocityY;
            }

            public void Jump()
            {
                VelocityY = JumpForce;
            }
        }

        class Pipe
        {
            public int X, TopH, Gap, W = 60;
            public bool Passed = false;

            public Rectangle TopRect => new Rectangle(X, 0, W, TopH);
            public Rectangle BottomRect => new Rectangle(X, TopH + Gap, W, 800);

            public Pipe(int startX, int topH, int gap)
            {
                X = startX; TopH = topH; Gap = gap;
            }
        }
    }
}