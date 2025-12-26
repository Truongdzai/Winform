using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai15 : Form
    {
        public Bai15()
        {
            InitializeComponent();
        }

        // Sự kiện khi thay đổi ngày trên lịch (ValueChanged)
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Cập nhật tiêu đề Form thành ngày ngắn (dạng dd/MM/yyyy)
            this.Text = "Short Date: " + dtpDate.Value.ToShortDateString();
        }

        // Sự kiện bấm nút OK
        private void btOK_Click(object sender, EventArgs e)
        {
            // Cập nhật tiêu đề Form thành ngày dài (dạng Thứ, Ngày, Tháng, Năm)
            this.Text = "Long Date: " + dtpDate.Value.ToLongDateString();
        }
    }
}