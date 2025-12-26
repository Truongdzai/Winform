using System;
using System.Windows.Forms;

namespace WinFormsApp_Article // Nhớ đổi tên namespace nếu của bạn khác
{
    public partial class Bai07 : Form
    {
        public Bai07()
        {
            InitializeComponent();

            this.tbYear.KeyPress += new KeyPressEventHandler(tbYear_KeyPress);
        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}