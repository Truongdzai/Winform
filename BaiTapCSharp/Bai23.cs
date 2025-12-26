using System;
using System.Drawing; // Cần thiết để dùng Point, Size
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai23 : Form
    {
        // 1. Khai báo biến toàn cục
        // Tạo sẵn đối tượng PictureBox nhưng chưa hiện lên form
        PictureBox pb = new PictureBox();
        int x = 50; // Tọa độ ngang ban đầu
        int y = 50; // Tọa độ dọc ban đầu

        public Bai23()
        {
            InitializeComponent();
        }

        // 2. Nút File: Thiết lập và hiển thị ảnh
        private void btFile_Click(object sender, EventArgs e)
        {
            // Cấu hình PictureBox
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new Size(150, 150);
            pb.Location = new Point(x, y);

            // QUAN TRỌNG: Thêm PictureBox vào danh sách Controls của Form thì nó mới hiện ra
            this.Controls.Add(pb);

            // Mở hộp thoại chọn ảnh (Để code linh hoạt hơn việc fix cứng đường dẫn như slide)
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pb.ImageLocation = dlg.FileName;
            }
            else
            {
                // Nếu không chọn file thì thôi, hoặc load ảnh mặc định
                // pb.ImageLocation = @"d:\abc.jpg"; // Code theo slide
            }
        }

        // 3. Nút sang TRÁI
        private void btLeft_Click(object sender, EventArgs e)
        {
            x -= 10; // Giảm tọa độ X
            pb.Location = new Point(x, y);
        }

        // 4. Nút sang PHẢI
        private void btRight_Click(object sender, EventArgs e)
        {
            x += 10; // Tăng tọa độ X
            pb.Location = new Point(x, y);
        }
    }
}