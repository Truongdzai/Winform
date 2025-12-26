using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai19 : Form
    {
        public Bai19()
        {
            InitializeComponent();
        }

        // Sự kiện nút "Chọn ảnh..."
        private void btFile_Click(object sender, EventArgs e)
        {
            // 1. Chế độ hiển thị: StretchImage (Co giãn ảnh cho vừa khung)
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

            // 2. Mở hộp thoại chọn file
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";

            // Chỉ lọc hiển thị các file ảnh jpg, bmp, png...
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            // 3. Nếu người dùng chọn file và bấm OK
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Gán đường dẫn file ảnh vào PictureBox
                pbImage.ImageLocation = dlg.FileName;
            }
        }
    }
}