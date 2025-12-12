using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormsApp_Article
{
    public partial class Bai02 : Form
    {
        string path = "config01.xml"; // Đọc lại file của bài 01

        public Bai02()
        {
            this.Text = "Bai 02 (Read XML)";
            this.Load += Bai02_Load;
            this.ResizeEnd += (s, e) => { /* Code lưu nếu muốn */ };
        }

        private void Bai02_Load(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                try
                {
                    XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
                    using (StreamReader file = new StreamReader(path))
                    {
                        InfoWindows iw = (InfoWindows)reader.Deserialize(file);
                        this.Width = iw.Width;
                        this.Height = iw.Height;
                    }
                }
                catch { }
            }
        }
    }
}