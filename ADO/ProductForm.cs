using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions; // Cần thiết cho Regex
using System.Windows.Forms;

namespace ADO
{
    public partial class ProductForm : Form
    {
        // Chuỗi kết nối
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";
        private string originalId = "";
        private string currentImagePath = "";

        // CẤU HÌNH PHÂN TRANG
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // --- HÀM KIỂM TRA DỮ LIỆU ĐẦU VÀO (VALIDATION) ---
        private bool ValidateInput()
        {
            // 1. Kiểm tra Mã Sản Phẩm
            string id = tbId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Vui lòng nhập Mã sản phẩm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (id.Length > 50)
            {
                MessageBox.Show("Mã sản phẩm không được vượt quá 50 ký tự!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Regex: Chỉ chấp nhận chữ cái (a-z, A-Z) và số (0-9), không chấp nhận ký tự đặc biệt
            if (!Regex.IsMatch(id, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã sản phẩm không được chứa ký tự đặc biệt!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Kiểm tra Tên Sản Phẩm
            string name = tbName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (name.Length > 100)
            {
                MessageBox.Show("Tên sản phẩm không được vượt quá 100 ký tự!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Regex: Kiểm tra nếu chuỗi chỉ toàn là số (\d+) thì báo lỗi
            if (Regex.IsMatch(name, @"^\d+$"))
            {
                MessageBox.Show("Tên sản phẩm không được chỉ chứa mỗi số (phải có chữ)!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. Kiểm tra Đơn Giá
            // Loại bỏ dấu phân cách ngàn (,) hoặc (.) trước khi kiểm tra
            string priceRaw = tbPrice.Text.Trim().Replace(",", "").Replace(".", "");
            if (string.IsNullOrWhiteSpace(priceRaw))
            {
                MessageBox.Show("Vui lòng nhập Đơn giá!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // TryParse sẽ trả về false nếu chuỗi chứa ký tự đặc biệt hoặc chữ
            if (!decimal.TryParse(priceRaw, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số và không âm!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 4. Kiểm tra Đơn Vị
            string unit = tbUnit.Text.Trim();
            if (string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show("Vui lòng nhập Đơn vị tính!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Regex: \p{L} là chữ cái unicode (bao gồm tiếng Việt), \s là khoảng trắng. 
            // ^[\p{L}\s]+$ nghĩa là chỉ được chứa chữ và khoảng trắng.
            if (!Regex.IsMatch(unit, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Đơn vị tính không được chứa số hoặc ký tự đặc biệt!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // --- CÁC SỰ KIỆN NÚT BẤM (BUTTONS) ---

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Gọi hàm kiểm tra trước khi xử lý
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    if (IsIdExists(tbId.Text.Trim(), conn))
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = "INSERT INTO product (id, name, price, unit, ImagePath) VALUES (@id, @name, @price, @unit, @img)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", tbId.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", tbName.Text.Trim());
                        // Parse lại giá tiền chính xác sau khi đã validate
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(tbPrice.Text.Trim().Replace(",", "").Replace(".", "")));
                        cmd.Parameters.AddWithValue("@unit", tbUnit.Text.Trim());
                        cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                ClearInputs();
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa từ danh sách!", "Thông báo");
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    // Nếu đổi mã ID, kiểm tra mã mới có trùng không
                    if (tbId.Text.Trim() != originalId && IsIdExists(tbId.Text.Trim(), conn))
                    {
                        MessageBox.Show("Mã sản phẩm mới đã tồn tại!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = "UPDATE product SET id=@newId, name=@name, price=@price, unit=@unit, ImagePath=@img WHERE id=@oldId";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@newId", tbId.Text.Trim());
                        cmd.Parameters.AddWithValue("@oldId", originalId);
                        cmd.Parameters.AddWithValue("@name", tbName.Text.Trim());
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(tbPrice.Text.Trim().Replace(",", "").Replace(".", "")));
                        cmd.Parameters.AddWithValue("@unit", tbUnit.Text.Trim());
                        cmd.Parameters.AddWithValue("@img", (object?)currentImagePath ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                ClearInputs();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        // --- CÁC HÀM CŨ GIỮ NGUYÊN (LOAD DATA, DELETE, SEARCH, EXCEL...) ---

        private void LoadData()
        {
            dgvProduct.Rows.Clear();
            string searchTerm = tbSearch.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    string sqlCount = "SELECT COUNT(*) FROM product WHERE name LIKE @k OR id LIKE @k";
                    using (SqlCommand cmdCount = new SqlCommand(sqlCount, conn))
                    {
                        cmdCount.Parameters.AddWithValue("@k", "%" + searchTerm + "%");
                        totalRecords = (int)cmdCount.ExecuteScalar();
                    }

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    string sqlData = @"
                        SELECT * FROM product 
                        WHERE name LIKE @k OR id LIKE @k
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
                UpdatePaginationUI();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalId)) { MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!"); return; }
            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

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
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

        private bool IsIdExists(string id, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM product WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private void UpdatePaginationUI()
        {
            lblPageInfo.Text = $"Trang {currentPage} / {totalPages}";
            btFirst.Enabled = (currentPage > 1);
            btPrev.Enabled = (currentPage > 1);
            btNext.Enabled = (currentPage < totalPages);
            btLast.Enabled = (currentPage < totalPages);
        }

        private void btFirst_Click(object sender, EventArgs e) { currentPage = 1; LoadData(); }
        private void btPrev_Click(object sender, EventArgs e) { if (currentPage > 1) { currentPage--; LoadData(); } }
        private void btNext_Click(object sender, EventArgs e) { if (currentPage < totalPages) { currentPage++; LoadData(); } }
        private void btLast_Click(object sender, EventArgs e) { currentPage = totalPages; LoadData(); }
        private void btSearch_Click(object sender, EventArgs e) { currentPage = 1; LoadData(); }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                tbId.Text = row.Cells[0].Value?.ToString();
                originalId = tbId.Text;
                tbName.Text = row.Cells[1].Value?.ToString();
                string priceStr = row.Cells[2].Value?.ToString().Replace(".", "").Replace(",", "");
                tbPrice.Text = priceStr;
                tbUnit.Text = row.Cells[3].Value?.ToString();
                LoadImageSafely(row.Tag?.ToString());
            }
        }

        private void ClearInputs()
        {
            tbId.Clear(); tbName.Clear(); tbPrice.Text = "0"; tbUnit.Clear();
            originalId = ""; currentImagePath = ""; pbProduct.Image = null;
            tbId.Focus();
        }

        private void LoadImageSafely(string? path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try { using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) { pbProduct.Image = Image.FromStream(fs); currentImagePath = path; } }
                catch { pbProduct.Image = null; }
            }
            else pbProduct.Image = null;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog { Filter = "Images|*.jpg;*.png;*.bmp" })
            {
                if (d.ShowDialog() == DialogResult.OK) LoadImageSafely(d.FileName);
            }
        }

        private void btClose_Click(object sender, EventArgs e) => this.Close();

        private void btExport_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Rows.Count == 0) return;
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "DanhSachSanPham.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Mã SP,Tên Sản Phẩm,Đơn Giá,Đơn Vị");
                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] cells = {
                                row.Cells[0].Value?.ToString() ?? "",
                                "\"" + (row.Cells[1].Value?.ToString() ?? "") + "\"",
                                row.Cells[2].Value?.ToString().Replace(",", "").Replace(".", "") ?? "0",
                                row.Cells[3].Value?.ToString() ?? ""
                            };
                            sb.AppendLine(string.Join(",", cells));
                        }
                    }
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xuất file: " + ex.Message); }
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV Files|*.csv", Title = "Chọn file CSV Sản phẩm" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int success = 0, errors = 0;
                try
                {
                    string[] lines = File.ReadAllLines(ofd.FileName);
                    using (SqlConnection conn = new SqlConnection(strCon))
                    {
                        conn.Open();
                        for (int i = 1; i < lines.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(lines[i])) continue;
                            string[] data = lines[i].Split(',');
                            if (data.Length < 4) { errors++; continue; }

                            try
                            {
                                string sql = "INSERT INTO product (id, name, price, unit) VALUES (@id, @name, @price, @unit)";
                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", data[0].Trim());
                                    cmd.Parameters.AddWithValue("@name", data[1].Trim().Trim('"'));
                                    cmd.Parameters.AddWithValue("@price", decimal.Parse(data[2].Trim()));
                                    cmd.Parameters.AddWithValue("@unit", data[3].Trim());
                                    cmd.ExecuteNonQuery();
                                    success++;
                                }
                            }
                            catch { errors++; }
                        }
                    }
                    LoadData();
                    MessageBox.Show($"Nhập xong!\n- Thành công: {success}\n- Lỗi/Trùng: {errors}");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi đọc file: " + ex.Message); }
            }
        }
    }
}