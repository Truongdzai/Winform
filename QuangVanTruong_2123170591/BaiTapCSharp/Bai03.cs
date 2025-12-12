using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormsApp_Article
{
    public partial class Bai03 : Form
    {
        string path = "config03.xml";

        public Bai03()
        {
            this.Text = "Bai 03 (Location + Closing)";
            this.Load += Bai03_Load;
            this.FormClosing += Bai03_FormClosing; //
        }

        private void Bai03_Load(object sender, EventArgs e)
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
                        if (!iw.Location.IsEmpty)
                        {
                            this.StartPosition = FormStartPosition.Manual;
                            this.Location = iw.Location;
                        }
                    }
                }
                catch { }
            }
        }

        private void Bai03_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoWindows iw = new InfoWindows
            {
                Width = this.Width,
                Height = this.Height,
                Location = this.Location
            };
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                using (StreamWriter file = new StreamWriter(path)) { writer.Serialize(file, iw); }
            }
            catch { }
        }
    }
}