using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing; // Cần thêm để xử lý Image
using System.IO;      // Cần thêm để xử lý File
using System.Windows.Forms;

namespace ADO
{
    public partial class ProductForm : Form
    {
        // Chuỗi kết nối
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";

        // Biến lưu ID gốc để dùng khi sửa/xóa
        private string originalId = "";

        // Biến lưu đường dẫn ảnh hiện tại
        private string currentImagePath = "";

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Tải hình ảnh an toàn (tránh khóa file)
        private void LoadImageSafely(string? path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        pbProduct.Image = Image.FromStream(fs); // Giả sử PictureBox tên là pbProduct
                    }
                    currentImagePath = path;
                }
                catch { pbProduct.Image = null; }
            }   
            else
            {
                pbProduct.Image = null;
            }
        }

        // Làm sạch các ô nhập liệu
        private void ClearInputs()
        {
            tbId.Clear();
            tbName.Clear();
            tbPrice.Text = "0";
            tbUnit.Clear();
            originalId = "";
            currentImagePath = "";
            pbProduct.Image = null;
            tbId.Focus();
        }

        private void LoadData()
        {
            dgvProduct.Rows.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    // Đổi sang dùng DataReader để linh hoạt hơn trong việc gán Tag (lưu đường dẫn ảnh)
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM product", conn))
                    {
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                int r = dgvProduct.Rows.Add(
                                    rd["id"],
                                    rd["name"],
                                    Convert.ToDecimal(rd["price"]).ToString("N0"), // Format số tiền
                                    rd["unit"]
                                );
                                // Lưu đường dẫn ảnh vào Tag của dòng
                                dgvProduct.Rows[r].Tag = rd["ImagePath"]?.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // Kiểm tra trùng ID (Dùng khi sửa ID)
        private bool IsIdExists(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM product WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbId.Text) || string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên sản phẩm!"); return;
            }

            if (IsIdExists(tbId.Text))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    string sql = "INSERT INTO product (id, name, price, unit, ImagePath) VALUES (@id, @name, @price, @unit, @img)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", tbId.Text);
                        cmd.Parameters.AddWithValue("@name", tbName.Text);
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(tbPrice.Text));
                        cmd.Parameters.AddWithValue("@unit", tbUnit.Text);
                        cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value); // Lưu ảnh
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                ClearInputs();
                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nhập liệu: " + ex.Message); }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            if (tbId.Text != originalId && IsIdExists(tbId.Text))
            {
                MessageBox.Show("Mã sản phẩm mới đã tồn tại!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    string sql = "UPDATE product SET id=@newId, name=@name, price=@price, unit=@unit, ImagePath=@img WHERE id=@oldId";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@newId", tbId.Text);
                        cmd.Parameters.AddWithValue("@oldId", originalId);
                        cmd.Parameters.AddWithValue("@name", tbName.Text);
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(tbPrice.Text));
                        cmd.Parameters.AddWithValue("@unit", tbUnit.Text);
                        cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value); // Cập nhật ảnh

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Sửa thành công!");
                            LoadData();
                            ClearInputs();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM product WHERE id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", originalId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // TÍNH NĂNG MỚI: TÌM KIẾM
        private void btSearch_Click(object sender, EventArgs e)
        {
            dgvProduct.Rows.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    // Tìm theo Tên hoặc ID
                    string sql = "SELECT * FROM product WHERE name LIKE @k OR id LIKE @k";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@k", "%" + tbSearch.Text.Trim() + "%"); // Giả sử TextBox tìm kiếm tên tbSearch
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                int r = dgvProduct.Rows.Add(
                                    rd["id"],
                                    rd["name"],
                                    Convert.ToDecimal(rd["price"]).ToString("N0"),
                                    rd["unit"]
                                );
                                dgvProduct.Rows[r].Tag = rd["ImagePath"]?.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }

        // TÍNH NĂNG MỚI: CHỌN ẢNH
        private void btBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                d.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    LoadImageSafely(d.FileName);
                }
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                tbId.Text = row.Cells[0].Value?.ToString();
                tbName.Text = row.Cells[1].Value?.ToString();
                // Xử lý chuỗi tiền tệ để đưa lại vào textbox (bỏ dấu phẩy phân cách ngàn nếu có)
                string priceStr = row.Cells[2].Value?.ToString().Replace(".", "").Replace(",", "");
                tbPrice.Text = priceStr;
                tbUnit.Text = row.Cells[3].Value?.ToString();

                originalId = tbId.Text;

                // Hiển thị ảnh từ Tag
                string? imgPath = row.Tag?.ToString();
                LoadImageSafely(imgPath);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}