using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai00 : Form
    {
        public Bai00()
        {
            this.Text = "Bai 00";
            this.Load += (s, e) => UpdateTitle();
            this.ResizeEnd += (s, e) => UpdateTitle(); //
        }

        private void UpdateTitle()
        {
            this.Text = this.Width + " - " + this.Height;
        }
    }
}