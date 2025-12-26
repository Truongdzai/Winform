using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace WinFormsApp_Article
{
    public partial class Bai01 : Form
    {
        
        string path = "form.xml";

        public Bai01()
        {
            InitializeComponent();
        }

        // Hàm ghi file XML
        public void Write(InfoWindows iw)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                using (StreamWriter file = new StreamWriter(path))
                {
                    writer.Serialize(file, iw);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Bai01_Load(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
            this.Text = "Loaded: " + iw.Width + " - " + iw.Height;
        }

        private void Bai01_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
            this.Text = "Saved: " + iw.Width + " - " + iw.Height;
        }
    }
}