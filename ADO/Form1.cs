using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ADO
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối (Windows Authentication - Không cần User/Pass)
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";

        private string? currentImagePath = "";
        private string originalId = string.Empty;

        // CẤU HÌNH PHÂN TRANG
        private int currentPage = 1;
        private int pageSize = 10; // Số dòng trên mỗi trang
        private int totalRecords = 0;
        private int totalPages = 0;

        public Form1()
        {
            InitializeComponent();
            // Định dạng ngày tháng
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "dd/MM/yyyy";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu khi mở form
        }

        // --- 1. NHÓM HÀM KIỂM TRA DỮ LIỆU (VALIDATION) ---
        private bool ValidateInput()
        {
            // Kiểm tra Mã Khách Hàng
            if (string.IsNullOrWhiteSpace(tbId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(tbId.Text.Trim(), out _))
            {
                MessageBox.Show("Mã khách hàng phải là số nguyên (Ví dụ: 1, 2, 100)!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Tên Khách Hàng
            string name = tbName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập Tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (name.Length > 100)
            {
                MessageBox.Show("Tên khách hàng quá dài (không được vượt quá 100 ký tự)!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Chỉ cho phép chữ cái và khoảng trắng (Hỗ trợ tiếng Việt)
            if (!Regex.IsMatch(name, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên khách hàng không được chứa số hoặc ký tự đặc biệt!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Giới Tính
            if (cbGender.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Ngày Sinh
            if (dtpDob.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không hợp lệ (không được lớn hơn ngày hiện tại)!", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Số Điện Thoại
            string phone = tbPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(phone, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa các chữ số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (phone.Length < 9 || phone.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải từ 9 đến 11 chữ số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsIdExists(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM customer WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch { return false; }
        }

        // --- 2. NHÓM HÀM TẢI DỮ LIỆU & PHÂN TRANG ---
        private void LoadData()
        {
            dgvCustomer.Rows.Clear();
            string searchTerm = tbSearch.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    // Đếm tổng số bản ghi
                    string sqlCount = "SELECT COUNT(*) FROM customer WHERE name LIKE @k OR Phone LIKE @k";
                    using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                    {
                        cmd.Parameters.AddWithValue("@k", "%" + searchTerm + "%");
                        totalRecords = (int)cmd.ExecuteScalar();
                    }

                    // Tính toán số trang
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    // Lấy dữ liệu phân trang (bao gồm cột Gender)
                    string sqlData = @"
                        SELECT * FROM customer 
                        WHERE name LIKE @k OR Phone LIKE @k
                        ORDER BY id 
                        OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@k", "%" + searchTerm + "%");
                        cmd.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@Size", pageSize);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                int r = dgvCustomer.Rows.Add(
                                    rd["id"],
                                    rd["name"],
                                    rd["Gender"]?.ToString(), // Hiển thị Giới tính
                                    Convert.ToDateTime(rd["DateOfBirth"]).ToString("dd/MM/yyyy"),
                                    rd["Phone"]
                                );
                                dgvCustomer.Rows[r].Tag = rd["ImagePath"]?.ToString();
                            }
                        }
                    }
                }
                UpdatePaginationUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaginationUI()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {totalPages}";
            btFirst.Enabled = (currentPage > 1);
            btPrev.Enabled = (currentPage > 1);
            btNext.Enabled = (currentPage < totalPages);
            btLast.Enabled = (currentPage < totalPages);
        }

        // --- 3. CÁC SỰ KIỆN NÚT BẤM (CRUD) ---

        private void btNew_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (IsIdExists(tbId.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    string sql = "INSERT INTO customer (id, name, Gender, DateOfBirth, Phone, ImagePath) VALUES (@id, @name, @gender, @dob, @phone, @img)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", tbId.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", tbName.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", cbGender.Text); // Lưu giới tính
                        cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                        cmd.Parameters.AddWithValue("@phone", tbPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách!", "Thông báo");
                return;
            }
            if (!ValidateInput()) return;

            // Nếu đổi ID, kiểm tra ID mới có trùng không
            if (tbId.Text.Trim() != originalId && IsIdExists(tbId.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng mới đã bị trùng!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    string sql = "UPDATE customer SET id=@newId, name=@name, Gender=@gender, DateOfBirth=@dob, Phone=@phone, ImagePath=@img WHERE id=@oldId";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@newId", tbId.Text.Trim());
                        cmd.Parameters.AddWithValue("@oldId", originalId);
                        cmd.Parameters.AddWithValue("@name", tbName.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", cbGender.Text); // Cập nhật giới tính
                        cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                        cmd.Parameters.AddWithValue("@phone", tbPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng [{tbName.Text}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE id=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", originalId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Đã xóa khách hàng.", "Thông báo");
                LoadData();
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
            ClearInputs();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        // --- 4. TÍNH NĂNG XUẤT EXCEL ---
        private void btExport_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "DanhSachKhachHang.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ID,Họ Tên,Giới Tính,Ngày Sinh,SĐT"); // Header

                    foreach (DataGridViewRow row in dgvCustomer.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] cells = {
                                row.Cells[0].Value?.ToString() ?? "",
                                "\"" + (row.Cells[1].Value?.ToString() ?? "") + "\"",
                                row.Cells[2].Value?.ToString() ?? "",
                                row.Cells[3].Value?.ToString() ?? "",
                                row.Cells[4].Value?.ToString() ?? ""
                            };
                            sb.AppendLine(string.Join(",", cells));
                        }
                    }
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xuất file: " + ex.Message); }
            }
        }

        // --- 5. CÁC HÀM BỔ TRỢ KHÁC ---
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvCustomer.Rows[e.RowIndex];
                tbId.Text = r.Cells[0].Value?.ToString();
                originalId = tbId.Text; // Lưu ID gốc
                tbName.Text = r.Cells[1].Value?.ToString();

                // Hiển thị Giới tính lên ComboBox
                string gender = r.Cells[2].Value?.ToString();
                if (!string.IsNullOrEmpty(gender)) cbGender.Text = gender;
                else cbGender.SelectedIndex = -1;

                if (DateTime.TryParseExact(r.Cells[3].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob))
                    dtpDob.Value = dob;

                tbPhone.Text = r.Cells[4].Value?.ToString();

                // Hiển thị ảnh
                LoadImageSafely(r.Tag?.ToString());
            }
        }

        private void ClearInputs()
        {
            tbId.Clear(); tbName.Clear(); tbPhone.Clear(); tbSearch.Clear();
            dtpDob.Value = DateTime.Now; pbAvatar.Image = null;
            cbGender.SelectedIndex = -1; // Reset giới tính
            currentImagePath = ""; originalId = ""; tbId.Focus();
        }

        private void LoadImageSafely(string? path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        pbAvatar.Image = Image.FromStream(fs);
                    }
                    currentImagePath = path;
                }
                catch { pbAvatar.Image = null; }
            }
            else { pbAvatar.Image = null; }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog { Filter = "Images|*.jpg;*.png;*.bmp" })
            {
                if (d.ShowDialog() == DialogResult.OK) LoadImageSafely(d.FileName);
            }
        }

        // Các nút điều hướng trang
        private void btFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadData(); }
        private void btPrev_Click(object sender, EventArgs e) { if (currentPage > 1) { currentPage--; LoadData(); } }
        private void btNext_Click(object sender, EventArgs e) { if (currentPage < totalPages) { currentPage++; LoadData(); } }
        private void btLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadData(); }

        private void btExit_Click(object sender, EventArgs e) => this.Close();
    }
}