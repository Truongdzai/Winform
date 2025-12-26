using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp_Article
{
    public partial class Bai14 : Form
    {
        public Bai14()
        {
            InitializeComponent();
        }

        // Sự kiện khi tích vào ô "Giảm giá" (CheckedChanged)
        private void ckDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDiscount.Checked == true)
            {
                tbDiscount.Enabled = true; // Cho phép nhập số %
            }
            else
            {
                tbDiscount.Enabled = false; // Khóa ô nhập
                tbDiscount.Text = "0";      // Reset về 0
            }
        }

        // Sự kiện nút Tính tiền
        private void btRun_Click(object sender, EventArgs e)
        {
            string msg = "";
            int disc = 0;

            // Kiểm tra giới tính
            if (rbMale.Checked == true)
                msg += "Ông ";
            if (rbFemale.Checked == true)
                msg += "Bà ";

            // Kiểm tra giảm giá
            if (ckDiscount.Checked == true)
            {
                // Slide 106 ghi cứng là 5, nhưng để hay hơn ta lấy từ TextBox
                // disc = 5; 
                if (int.TryParse(tbDiscount.Text, out int value))
                {
                    disc = value;
                }
            }

            // Hiển thị kết quả xuống ô to phía dưới
            tbResult.Text = msg + tbName.Text + " được giảm " + disc.ToString() + "%" + "\r\n";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}