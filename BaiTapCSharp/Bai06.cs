using System;
using System.Drawing; 
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai06 : Form
    {
        public Bai06()
        {
            InitializeComponent();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.Text = "Article for Button";

            this.Size = new Size(500, 500);
        }
    }
}