namespace WinFormsApp_Article
{
    partial class Menu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Cấu hình Form Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650); // Mở rộng chiều cao
            this.Name = "Menu";
            this.Text = "MENU TỔNG HỢP BÀI TẬP (00 - 32)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // --- TẠO DANH SÁCH TÊN BÀI TẬP ---
            string[] buttons = {
                "Bài 00: Resize", "Bài 01: Save XML", "Bài 02: Read XML", "Bài 03: Location", "Bài 04: MsgBox",
                "Bài 05: KeyLogger", "Bài 06: Button", "Bài 07: Validate", "Bài 08: Calc Basic", "Bài 09: Calc Adv",
                "Bài 10: Pocket Calc", "Bài 11: Full Calc", "Bài 12: ComboBox", "Bài 13: Cbo Class", "Bài 14: Checkbox",
                "Bài 15: DateTime", "Bài 16: Listview SV", "Bài 17: ListBox", "Bài 18: Object List", "Bài 19: PictureBox",
                "Bài 20: DataGrid", "Bài 21: Grid List", "Bài 22: Binding", "Bài 23: Dynamic", "Bài 24: Timer",
                "Bài 25: Ball Game", "Bài 26: Egg Drop", "Bài 27: Basket", "Bài 28: Game Hứng Trứng", "Bài 29: UserControl",
                "Bài 30: Project QLSV", "Bài 31: TOO EASY", "Bài 32: Chim không nhỏ"
            };

            // --- CẤU HÌNH VỊ TRÍ NÚT ---   
            int xStart = 30, yStart = 30; // Điểm bắt đầu
            int w = 150, h = 60;          // Kích thước nút
            int gapX = 20, gapY = 20;     // Khoảng cách giữa các nút
            int cols = 5;                 // 5 cột mỗi hàng

            // --- VÒNG LẶP TẠO NÚT ---
            for (int i = 0; i < buttons.Length; i++)
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                btn.Name = "btnBai" + i.ToString("D2"); // Tên nút: btnBai00, btnBai01...
                btn.Text = buttons[i];
                btn.Size = new System.Drawing.Size(w, h);

                // Tính toán tọa độ (Dòng và Cột)
                int c = i % cols;
                int r = i / cols;
                btn.Location = new System.Drawing.Point(xStart + c * (w + gapX), yStart + r * (h + gapY));

                btn.UseVisualStyleBackColor = true;

                // Gán sự kiện Click thủ công
                // (Mẹo: Dùng tag để lưu số thứ tự bài, xử lý 1 hàm chung hoặc switch case)
                switch (i)
                {
                    case 0: btn.Click += new System.EventHandler(this.btnBai00_Click); break;
                    case 1: btn.Click += new System.EventHandler(this.btnBai01_Click); break;
                    case 2: btn.Click += new System.EventHandler(this.btnBai02_Click); break;
                    case 3: btn.Click += new System.EventHandler(this.btnBai03_Click); break;
                    case 4: btn.Click += new System.EventHandler(this.btnBai04_Click); break;
                    case 5: btn.Click += new System.EventHandler(this.btnBai05_Click); break;
                    case 6: btn.Click += new System.EventHandler(this.btnBai06_Click); break;
                    case 7: btn.Click += new System.EventHandler(this.btnBai07_Click); break;
                    case 8: btn.Click += new System.EventHandler(this.btnBai08_Click); break;
                    case 9: btn.Click += new System.EventHandler(this.btnBai09_Click); break;
                    case 10: btn.Click += new System.EventHandler(this.btnBai10_Click); break;
                    case 11: btn.Click += new System.EventHandler(this.btnBai11_Click); break;
                    case 12: btn.Click += new System.EventHandler(this.btnBai12_Click); break;
                    case 13: btn.Click += new System.EventHandler(this.btnBai13_Click); break;
                    case 14: btn.Click += new System.EventHandler(this.btnBai14_Click); break;
                    case 15: btn.Click += new System.EventHandler(this.btnBai15_Click); break;
                    case 16: btn.Click += new System.EventHandler(this.btnBai16_Click); break;
                    case 17: btn.Click += new System.EventHandler(this.btnBai17_Click); break;
                    case 18: btn.Click += new System.EventHandler(this.btnBai18_Click); break;
                    case 19: btn.Click += new System.EventHandler(this.btnBai19_Click); break;
                    case 20: btn.Click += new System.EventHandler(this.btnBai20_Click); break;
                    case 21: btn.Click += new System.EventHandler(this.btnBai21_Click); break;
                    case 22: btn.Click += new System.EventHandler(this.btnBai22_Click); break;
                    case 23: btn.Click += new System.EventHandler(this.btnBai23_Click); break;
                    case 24: btn.Click += new System.EventHandler(this.btnBai24_Click); break;
                    case 25: btn.Click += new System.EventHandler(this.btnBai25_Click); break;
                    case 26: btn.Click += new System.EventHandler(this.btnBai26_Click); break;
                    case 27: btn.Click += new System.EventHandler(this.btnBai27_Click); break;
                    case 28: btn.Click += new System.EventHandler(this.btnBai28_Click); break;
                    case 29: btn.Click += new System.EventHandler(this.btnBai29_Click); break;
                    case 30: btn.Click += new System.EventHandler(this.btnBai30_Click); break;
                    case 31: btn.Click += new System.EventHandler(this.btnBai31_Click); break; // Game TOO EASY
                    case 32: btn.Click += new System.EventHandler(this.btnBai32_Click); break; // Game LEVEL DEVIL
                }

                this.Controls.Add(btn);
            }

            this.ResumeLayout(false);
        }

        #endregion
    }
}