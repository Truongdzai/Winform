using System;
using System.Drawing; // Để dùng Point
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace WinFormsApp_Article
{
    public partial class Bai03 : Form
    {
        string path = "form_bai03.xml";

        public Bai03()
        {
            InitializeComponent();
        }

        public void Write(InfoWindows iw)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                writer.Serialize(file, iw);
            }
        }

        public InfoWindows Read()
        {
            if (!File.Exists(path)) return null;
            using (StreamReader file = new StreamReader(path))
            {
                XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
                return (InfoWindows)reader.Deserialize(file);
            }
        }

        // Khi Form Load -> Khôi phục cả Kích thước và Vị trí
        private void Bai03_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null)
            {
                this.Width = iw.Width;
                this.Height = iw.Height;
                this.Location = iw.Location; // Khôi phục vị trí
                this.Text = "Restored: " + iw.Location.ToString();
            }
        }

        // Khi Form Đang đóng -> Lưu lại tất cả
        private void Bai03_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            iw.Location = this.Location; // Lưu vị trí

            Write(iw);
        }
    }
}