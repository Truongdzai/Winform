using System;
using System.Windows.Forms;

namespace WinFormsApp_Article // Đổi tên này nếu namespace của bạn khác
{
    public partial class Bai11 : Form
    {
        // --- 1. KHAI BÁO BIẾN (Slide 83) ---
        decimal memory = 0;        // Biến nhớ (M)
        decimal workingMemory = 0; // Biến lưu số thứ nhất
        string opr = "";           // Biến lưu dấu phép tính (+ - * /)

        public Bai11()
        {
            InitializeComponent();

            // --- 2. GÁN SỰ KIỆN TỰ ĐỘNG (Slide 82) ---
            // Thay vì click đúp vào từng nút, ta chạy vòng lặp tìm hết các nút và gán chung 1 hàm
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.Click += new EventHandler(Button_Click);
                }
            }
        }

        // --- 3. HÀM XỬ LÝ CHUNG CHO TẤT CẢ NÚT (Slide 84 -> 90) ---
        private void Button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender; // Lấy cái nút vừa bị bấm

            // --- NHÓM SỐ & DẤU CHẤM (Slide 84) ---
            // Nếu là Số HOẶC dấu chấm
            if ((char.IsDigit(bt.Text, 0) && bt.Text.Length == 1) || bt.Text == ".")
            {
                // Chặn nhập nhiều dấu chấm
                if (bt.Text == "." && txtDisplay.Text.Contains(".")) return;

                txtDisplay.Text += bt.Text;
            }

            // --- NHÓM PHÉP TÍNH CƠ BẢN (Slide 86) ---
            else if (bt.Text == "+" || bt.Text == "-" || bt.Text == "*" || bt.Text == "/")
            {
                opr = bt.Text;
                workingMemory = decimal.Parse(txtDisplay.Text);
                txtDisplay.Clear();
            }

            // --- NHÓM KẾT QUẢ = (Slide 87) ---
            else if (bt.Text == "=")
            {
                decimal secondValue = decimal.Parse(txtDisplay.Text);
                switch (opr)
                {
                    case "+": txtDisplay.Text = (workingMemory + secondValue).ToString(); break;
                    case "-": txtDisplay.Text = (workingMemory - secondValue).ToString(); break;
                    case "*": txtDisplay.Text = (workingMemory * secondValue).ToString(); break;
                    case "/":
                        if (secondValue != 0) txtDisplay.Text = (workingMemory / secondValue).ToString();
                        else MessageBox.Show("Không thể chia cho 0");
                        break;
                }
            }

            // --- NHÓM TOÁN CAO CẤP (Slide 88) ---
            else if (bt.Text == "±") { txtDisplay.Text = (-decimal.Parse(txtDisplay.Text)).ToString(); }
            else if (bt.Text == "√") { txtDisplay.Text = Math.Sqrt((double)decimal.Parse(txtDisplay.Text)).ToString(); }
            else if (bt.Text == "%") { txtDisplay.Text = (decimal.Parse(txtDisplay.Text) / 100).ToString(); }
            else if (bt.Text == "1/x") { txtDisplay.Text = (1 / decimal.Parse(txtDisplay.Text)).ToString(); }

            // --- NHÓM XÓA & BỘ NHỚ (Slide 89, 90) ---
            else if (bt.Text == "←") // Backspace
            {
                if (txtDisplay.TextLength > 0)
                    txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.TextLength - 1);
            }
            else if (bt.Text == "C") // Clear All
            {
                workingMemory = 0; opr = ""; txtDisplay.Clear();
            }
            else if (bt.Text == "CE") // Clear Entry
            {
                txtDisplay.Clear();
            }
            // Memory Buttons
            else if (bt.Text == "MC") memory = 0;
            else if (bt.Text == "MR") txtDisplay.Text = memory.ToString();
            else if (bt.Text == "MS") { memory = decimal.Parse(txtDisplay.Text); txtDisplay.Clear(); }
            else if (bt.Text == "M+") memory += decimal.Parse(txtDisplay.Text);
            else if (bt.Text == "M-") memory -= decimal.Parse(txtDisplay.Text);
        }
    }
}