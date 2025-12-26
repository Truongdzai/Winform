using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai10 : Form
    {
        // --- 1. KHAI BÁO BIẾN TOÀN CỤC (Để lưu trạng thái) ---
        decimal workingMemory = 0; // Lưu số đầu tiên (Ví dụ: bấm 10 + ... thì lưu số 10 vào đây)
        string opr = "";           // Lưu phép toán (Ví dụ: lưu dấu "+")

        public Bai10()
        {
            InitializeComponent();
        }

        // --- 2. XỬ LÝ CÁC NÚT SỐ (0, 1, 2, 3...) ---
        // Khi bấm số, ta nối chuỗi số đó vào màn hình
        private void bt0_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += "0";
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += "1";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += "2";
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += "3";
        }

        private void btDot_Click(object sender, EventArgs e)
        {
            // Kiểm tra để tránh nhập 2 dấu chấm (ví dụ 12..5)
            if (!tbDisplay.Text.Contains("."))
            {
                tbDisplay.Text += ".";
            }
        }

        // --- 3. XỬ LÝ PHÉP TÍNH (+, *) ---
        private void btPlus_Click(object sender, EventArgs e)
        {
            opr = "+"; // Ghi nhớ là đang muốn Cộng
            workingMemory = decimal.Parse(tbDisplay.Text); // Lưu con số hiện tại vào bộ nhớ
            tbDisplay.Clear(); // Xóa màn hình để nhập số thứ 2
        }

        private void btMul_Click(object sender, EventArgs e)
        {
            opr = "*"; // Ghi nhớ là đang muốn Nhân
            workingMemory = decimal.Parse(tbDisplay.Text);
            tbDisplay.Clear();
        }

        // --- 4. XỬ LÝ NÚT BẰNG (=) ---
        private void btEquals_Click(object sender, EventArgs e)
        {
            // Lấy số thứ 2 đang nằm trên màn hình
            decimal secondValue = decimal.Parse(tbDisplay.Text);

            // Kiểm tra xem hồi nãy bấm dấu gì để tính
            if (opr == "+")
            {
                tbDisplay.Text = (workingMemory + secondValue).ToString();
            }

            if (opr == "*")
            {
                tbDisplay.Text = (workingMemory * secondValue).ToString();
            }
        }
    }
}