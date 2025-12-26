using System;
using System.Windows.Forms;
namespace WinFormsApp_Article
{
    public partial class Finish : UserControl
    {
        public Finish() { InitializeComponent(); }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát chương trình
        }
    }
}