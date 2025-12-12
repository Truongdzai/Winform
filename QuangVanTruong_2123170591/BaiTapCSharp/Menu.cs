using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            SetupMenu();
        }

        private void SetupMenu() {
        {
            this.Text = "Menu Bài Tập";
            this.Size = new Size(350, 550);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo các nút bấm
            AddButton("Bài 00: Show Size", 20, (s, e) => new Bai00().Show());
            AddButton("Bài 01: Save XML", 70, (s, e) => new Bai01().Show());
            AddButton("Bài 02: Read XML", 120, (s, e) => new Bai02().Show());
            AddButton("Bài 03: Location + Closing", 170, (s, e) => new Bai03().Show());
            AddButton("Bài 04: (Trống)", 220, (s, e) => MessageBox.Show("Bài 04 chưa có nội dung trong slide."));
            AddButton("Bài 05: KeyLogger (Ẩn)", 270, (s, e) => {
                MessageBox.Show("Đang chạy ẩn! Gõ phím rồi kiểm tra file Key_Logger.txt");
                new Bai05().Show();
            });
            AddButton("Bài 06: Button", 320, (s, e) => new Bai06().Show());
            AddButton("Bài 07: TextBox (KeyPress)", 370, (s, e) => new Bai07().Show());
            AddButton("Bài 08: TextBox (Validating)", 420, (s, e) => new Bai08().Show());
            AddButton("Bài 10: Simple Calculator", 470, (s, e) => new Bai10().Show());
            }

        // Hàm hỗ trợ tạo nút nhanh
        private void AddButton(string text, int y, EventHandler clickEvent)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new Point(50, y);
            btn.Size = new Size(240, 40);
            btn.Click += clickEvent;
            this.Controls.Add(btn);
        }
    }
}