using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            this.Text = "Key Logger";
            this.KeyPreview = true;       //
            this.ShowInTaskbar = false;   //
            this.KeyUp += Bai05_KeyUp;
        }

        private void Bai05_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //
                StreamWriter sw = new StreamWriter("Key_Logger.txt", true);
                sw.Write(e.KeyCode + " ");
                sw.Close();
            }
            catch { }
        }
    }
}