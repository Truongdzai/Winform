using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai10 : Form
    {
        // Biến lưu giá trị tạm thời (workingMemory) và phép toán (opr)
        decimal workingMemory = 0;
        string opr = "";

        public Bai10()
        {
            InitializeComponent();

            // Gắn sự kiện Click cho các nút số
            // Slide 77 dùng cách gán từng cái, ta có thể gán nhanh hoặc dùng vòng lặp
            // Ở đây tôi gán thủ công cho giống slide
            bt0.Click += Number_Click;
            bt1.Click += Number_Click;
            bt2.Click += Number_Click;
            bt3.Click += Number_Click;
            btDot.Click += Number_Click; // Dấu chấm cũng coi như nhập số

            // Gắn sự kiện cho các nút phép tính
            btPlus.Click += btPlus_Click;
            btMul.Click += btPlus_Click; // Dùng chung logic lưu phép tính

            // Nút Bằng
            btEquals.Click += btEquals_Click;
        }

        // Xử lý khi bấm số (0, 1, 2, 3...)
        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Lấy nút vừa bấm
            tbDisplay.Text += btn.Text;  // Cộng chuỗi số vào màn hình
        }

        // Xử lý khi bấm phép cộng (+) hoặc nhân (*)
        private void btPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            opr = btn.Text; // Lưu phép tính (+ hoặc *)

            // Lưu giá trị hiện tại vào bộ nhớ tạm
            if (decimal.TryParse(tbDisplay.Text, out workingMemory))
            {
                tbDisplay.Clear(); // Xóa màn hình để nhập số thứ 2
            }
        }

        // Xử lý khi bấm dấu bằng (=)
        private void btEquals_Click(object sender, EventArgs e)
        {
            decimal secondValue = 0;
            // Lấy số thứ 2 từ màn hình
            if (decimal.TryParse(tbDisplay.Text, out secondValue))
            {
                // Tính toán dựa trên phép tính đã lưu (opr)
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
}