using System;
using System.Data;
using Microsoft.Data.SqlClient; // Thư viện truy cập SQL Server hiện đại
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ADO
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối (Vui lòng thay đổi thông số phù hợp với database của bạn)
        private readonly string strCon = @"Data Source=localhost;Initial Catalog=sale;User Id=sa;Password=sa;TrustServerCertificate=True";
        private string? currentImagePath = "";
        private string originalId = string.Empty;

        public Form1()
        {
            InitializeComponent();
            // Thiết lập định dạng ngày tháng hiển thị
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "dd/MM/yyyy";
        }

        #region Phương thức hỗ trợ (Helpers)

        // Kiểm tra mã ID đã tồn tại chưa để tránh lỗi Primary Key
        private bool IsIdExists(string id)
        {
            using SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            string sql = "SELECT COUNT(*) FROM customer WHERE id = @id";
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            object? result = cmd.ExecuteScalar();
            return result != null && Convert.ToInt32(result) > 0;
        }

        // Xóa sạch thông tin trên các ô nhập liệu
        private void ClearInputs()
        {
            tbId.Clear();
            tbName.Clear();
            tbPhone.Clear();
            tbSearch.Clear();
            dtpDob.Value = DateTime.Now;
            pbAvatar.Image = null;
            currentImagePath = "";
            originalId = string.Empty;
            tbId.Focus();
        }

        // Tải ảnh vào PictureBox mà không làm khóa file trên ổ cứng
        private void LoadImageSafely(string? path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    pbAvatar.Image = Image.FromStream(fs);
                    currentImagePath = path;
                }
                catch { pbAvatar.Image = null; }
            }
            else { pbAvatar.Image = null; }
        }

        // Kiểm tra tính hợp lệ của dữ liệu đầu vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(tbId.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(tbId.Text, out _))
            {
                MessageBox.Show("Mã khách hàng phải là định dạng số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Họ tên không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(tbPhone.Text, @"^\d{9,11}$"))
            {
                MessageBox.Show("Số điện thoại phải từ 9-11 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Xử lý Sự kiện

        // Nút "Làm mới" - Tải lại danh sách từ Database
        private void btRead_Click(object? sender, EventArgs? e)
        {
            dgvCustomer.Rows.Clear();
            try
            {
                using SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                using SqlCommand cmd = new SqlCommand("SELECT * FROM customer", conn);
                using SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int r = dgvCustomer.Rows.Add(
                        rd["id"]?.ToString(),
                        rd["name"]?.ToString(),
                        rd["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(rd["DateOfBirth"]).ToString("dd/MM/yyyy") : "",
                        rd["Phone"]?.ToString()
                    );
                    // Lưu đường dẫn ảnh vào Tag để truy xuất khi click dòng
                    dgvCustomer.Rows[r].Tag = rd["ImagePath"]?.ToString();
                }
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút "Thêm mới"
        private void btNew_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (IsIdExists(tbId.Text))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                string sql = "INSERT INTO customer (id, name, DateOfBirth, Phone, ImagePath) VALUES (@id, @name, @dob, @phone, @img)";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", tbId.Text);
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@phone", tbPhone.Text);
                cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btRead_Click(this, EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Nút "Cập nhật"
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId))
            {
                MessageBox.Show("Vui lòng chọn khách hàng từ danh sách!", "Thông báo");
                return;
            }
            if (!ValidateInput()) return;
            if (tbId.Text != originalId && IsIdExists(tbId.Text))
            {
                MessageBox.Show("Mã ID mới đã bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                string sql = "UPDATE customer SET id=@newId, name=@name, DateOfBirth=@dob, Phone=@phone, ImagePath=@img WHERE id=@oldId";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@newId", tbId.Text);
                cmd.Parameters.AddWithValue("@oldId", originalId);
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@phone", tbPhone.Text);
                cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btRead_Click(this, EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Nút "Xóa"
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId)) return;
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng {tbName.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                using SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                using SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", originalId);
                cmd.ExecuteNonQuery();
                btRead_Click(this, EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

        // Nút "Tìm kiếm"
        private void btSearch_Click(object sender, EventArgs e)
        {
            dgvCustomer.Rows.Clear();
            try
            {
                using SqlConnection conn = new SqlConnection(strCon);
                conn.Open();
                string sql = "SELECT * FROM customer WHERE name LIKE @k OR id LIKE @k OR Phone LIKE @k";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@k", "%" + tbSearch.Text.Trim() + "%");
                using SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int r = dgvCustomer.Rows.Add(
                        rd["id"]?.ToString(),
                        rd["name"]?.ToString(),
                        rd["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(rd["DateOfBirth"]).ToString("dd/MM/yyyy") : "",
                        rd["Phone"]?.ToString()
                    );
                    dgvCustomer.Rows[r].Tag = rd["ImagePath"]?.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Chọn ảnh từ máy tính
        private void btBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog d = new OpenFileDialog { Filter = "Image Files|*.jpg;*.png;*.bmp" };
            if (d.ShowDialog() == DialogResult.OK) LoadImageSafely(d.FileName);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        // Khi click vào một dòng trong bảng
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvCustomer.Rows[e.RowIndex];
            tbId.Text = r.Cells[0].Value?.ToString() ?? "";
            originalId = tbId.Text; // Lưu lại ID để phục vụ UPDATE/DELETE
            tbName.Text = r.Cells[1].Value?.ToString() ?? "";

            string? dobStr = r.Cells[2].Value?.ToString();
            if (!string.IsNullOrEmpty(dobStr) && DateTime.TryParseExact(dobStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob))
                dtpDob.Value = dob;

            tbPhone.Text = r.Cells[3].Value?.ToString() ?? "";
            LoadImageSafely(r.Tag?.ToString());
        }

        // Giữ lại để tránh lỗi thiết kế (Designer)
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) => btRead_Click(this, EventArgs.Empty);

        #endregion
    }
}