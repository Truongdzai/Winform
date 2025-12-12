using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormsApp_Article
{
    public partial class Bai01 : Form
    {
        string path = "config01.xml";

        public Bai01()
        {
            this.Text = "Bai 01 (Write XML)";
            this.ResizeEnd += Bai01_ResizeEnd;
            this.Load += Bai01_Load;
        }

        private void Bai01_Load(object sender, EventArgs e) => SaveXML();
        private void Bai01_ResizeEnd(object sender, EventArgs e) => SaveXML();

        private void SaveXML()
        {
            InfoWindows iw = new InfoWindows { Width = this.Width, Height = this.Height };
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                using (StreamWriter file = new StreamWriter(path)) { writer.Serialize(file, iw); }
            }
            catch { }
        }
    }
}