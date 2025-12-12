using System;
using System.ComponentModel; // Cần thư viện này cho CancelEventArgs
using System.Windows.Forms;

namespace WinFormsApp_Article // Nhớ đổi tên namespace nếu của bạn khác
{
    public partial class Bai08 : Form
    {
        public Bai08()
        {
            InitializeComponent();

            // Gắn sự kiện Validating cho tbYear
            this.tbYear.Validating += new CancelEventHandler(tbYear_Validating);
        }

        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            // Nếu ô trống thì bỏ qua không kiểm tra
            if (string.IsNullOrEmpty(tbYear.Text)) return;

            int year;
            // Thử ép kiểu text sang số nguyên
            // Nếu ép kiểu thành công (biến year) VÀ year > 2000
            if (int.TryParse(tbYear.Text, out year) && year > 2000)
            {
                MessageBox.Show("Năm phải nhỏ hơn hoặc bằng 2000!");
                e.Cancel = true; // Giữ chuột lại ô này, không cho thoát ra
            }
        }
    }
}