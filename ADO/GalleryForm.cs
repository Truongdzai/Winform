using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ADO
{
    public partial class GalleryForm : Form
    {
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";

        public GalleryForm()
        {
            InitializeComponent();
        }

        private void GalleryForm_Load(object sender, EventArgs e)
        {
            LoadGallery();
        }

        private void LoadGallery(string search = "")
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa các thẻ cũ

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    string sql = "SELECT * FROM product WHERE name LIKE @k OR id LIKE @k";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@k", "%" + search + "%");
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                // Tạo thẻ sản phẩm (Card)
                                Panel card = CreateProductCard(
                                    rd["id"].ToString(),
                                    rd["name"].ToString(),
                                    Convert.ToDecimal(rd["price"]),
                                    rd["ImagePath"]?.ToString()
                                );
                                flowLayoutPanel1.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thư viện: " + ex.Message);
            }
        }

        // Hàm tạo giao diện từng thẻ sản phẩm thủ công
        private Panel CreateProductCard(string id, string name, decimal price, string imgPath)
        {
            // 1. Panel chính (Cái khung)
            Panel p = new Panel();
            p.Width = 200;
            p.Height = 280;
            p.Margin = new Padding(15);
            p.BackColor = Color.White;
            p.Padding = new Padding(10);

            // Hiệu ứng viền đơn giản (Dùng Padding của Form mẹ hoặc BackColor khác để giả lập nếu cần)
            // Ở đây ta dùng màu nền trắng nổi bật trên nền xám của Form

            // 2. Hình ảnh (PictureBox)
            PictureBox pb = new PictureBox();
            pb.Width = 180;
            pb.Height = 180;
            pb.Dock = DockStyle.Top;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BackColor = Color.FromArgb(248, 250, 252); // Xám rất nhạt

            // Tải ảnh an toàn
            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
            {
                try
                {
                    using (FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                    {
                        pb.Image = Image.FromStream(fs);
                    }
                }
                catch { pb.Image = null; } // Nếu lỗi file ảnh thì để trống
            }

            // 3. Tên sản phẩm (Label)
            Label lblName = new Label();
            lblName.Text = name;
            lblName.Dock = DockStyle.Top;
            lblName.Height = 40;
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(64, 64, 64);
            // Đẩy tên xuống dưới ảnh một chút
            Panel spacer = new Panel { Height = 5, Dock = DockStyle.Top };

            // 4. Giá tiền (Label)
            Label lblPrice = new Label();
            lblPrice.Text = price.ToString("N0") + " đ";
            lblPrice.Dock = DockStyle.Bottom;
            lblPrice.Height = 30;
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            lblPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(234, 88, 12); // Màu Cam nổi bật

            // 5. Thêm các control vào Panel (Thứ tự thêm quan trọng với Dock)
            p.Controls.Add(lblPrice);
            p.Controls.Add(lblName);
            p.Controls.Add(spacer);
            p.Controls.Add(pb);

            // Sự kiện Click (Tùy chọn: Click vào thẻ để xem chi tiết hoặc sửa)
            p.Click += (s, e) => MessageBox.Show($"Bạn chọn: {name}\nMã: {id}");
            // Gán sự kiện click cho cả các con bên trong để trải nghiệm tốt hơn
            foreach (Control c in p.Controls)
                c.Click += (s, e) => MessageBox.Show($"Bạn chọn: {name}\nMã: {id}");

            return p;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // Tìm kiếm ngay khi gõ
            LoadGallery(tbSearch.Text.Trim());
        }
    }
}