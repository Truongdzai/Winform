using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace WinFormsApp_Article
{
    public partial class Bai02 : Form
    {
        string path = "form_bai02.xml"; // Đặt tên file khác nhau để tránh đụng độ các bài

        public Bai02()
        {
            InitializeComponent();
        }

        // Hàm Ghi (Write)
        public void Write(InfoWindows iw)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                writer.Serialize(file, iw);
            }
        }

        // Hàm Đọc (Read) - Mới xuất hiện ở bài này
        public InfoWindows Read()
        {
            if (!File.Exists(path)) return null; // Kiểm tra nếu file chưa tồn tại thì thôi

            using (StreamReader file = new StreamReader(path))
            {
                XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
                return (InfoWindows)reader.Deserialize(file);
            }
        }

        // Khi co giãn xong -> Lưu lại
        private void Bai02_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
            this.Text = "Saved Size: " + iw.Width + "x" + iw.Height;
        }

        // Khi mở Form -> Đọc file và khôi phục kích thước cũ
        private void Bai02_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null)
            {
                this.Width = iw.Width;
                this.Height = iw.Height;
                this.Text = "Restored Size: " + iw.Width + "x" + iw.Height;
            }
        }
    }
}