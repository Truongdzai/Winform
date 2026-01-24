using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ADO
{
    public partial class Form1 : Form
    {
        // --- CẤU HÌNH KẾT NỐI ---
        string strCon = @"Data Source=localhost; Initial Catalog=sale; User Id=sa; Password=sa; TrustServerCertificate=True";
        SqlConnection conn = null;
        string currentImagePath = "";

        // [QUAN TRỌNG] Biến lưu ID gốc để dùng khi sửa
        string originalId = "";

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(strCon);
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "dd/MM/yyyy";
        }

        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
        }

        // --- 1. ĐỌC DỮ LIỆU ---
        private void btRead_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM customer", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                dgvCustomer.Rows.Clear();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string imgPath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? "" : reader["ImagePath"].ToString();
                    DateTime? dob = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                    string phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? "" : reader["Phone"].ToString();

                    int index = dgvCustomer.Rows.Add(id, name, dob.HasValue ? dob.Value.ToString("dd/MM/yyyy") : "", phone);
                    dgvCustomer.Rows[index].Tag = imgPath;
                }
                reader.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi đọc: " + ex.Message); }
            finally { conn.Close(); }
        }

        // --- 2. CLICK VÀO LƯỚI (LƯU ID GỐC) ---
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];

                // Đổ dữ liệu lên Control
                tbId.Text = row.Cells[0].Value?.ToString();

                // [QUAN TRỌNG] Lưu lại ID cũ ngay khi click
                originalId = tbId.Text;

                tbName.Text = row.Cells[1].Value?.ToString();

                if (DateTime.TryParseExact(row.Cells[2].Value?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob))
                    dtpDob.Value = dob;

                tbPhone.Text = row.Cells[3].Value?.ToString();

                string imgPath = row.Tag?.ToString();
                if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    pbAvatar.Image = Image.FromFile(imgPath);
                    currentImagePath = imgPath;
                }
                else
                {
                    pbAvatar.Image = null;
                    currentImagePath = "";
                }
            }
        }

        // --- 3. CHỌN ẢNH ---
        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentImagePath = dlg.FileName;
                pbAvatar.Image = Image.FromFile(currentImagePath);
            }
        }

        // --- 4. THÊM ---
        private void btNew_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                string sql = "INSERT INTO customer(id, name, DateOfBirth, Phone, ImagePath) VALUES(@id, @name, @dob, @phone, @img)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", tbId.Text);
                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@phone", tbPhone.Text);
                cmd.Parameters.AddWithValue("@img", currentImagePath);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
                btRead_Click(null, null);
                ResetInput();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm (Có thể trùng ID): " + ex.Message); }
            finally { conn.Close(); }
        }

        // --- 5. SỬA (CHO PHÉP SỬA ID) ---
        private void btEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào chưa
            if (string.IsNullOrEmpty(originalId))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa trong bảng trước!");
                return;
            }

            try
            {
                OpenConnection();
                // SQL Logic: Update ID mới WHERE ID cũ
                string sql = "UPDATE customer SET id=@newId, name=@name, DateOfBirth=@dob, Phone=@phone, ImagePath=@img WHERE id=@oldId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@newId", tbId.Text); // ID Mới (từ TextBox)
                cmd.Parameters.AddWithValue("@oldId", originalId); // ID Cũ (từ biến lưu trữ)

                cmd.Parameters.AddWithValue("@name", tbName.Text);
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@phone", tbPhone.Text);
                cmd.Parameters.AddWithValue("@img", currentImagePath);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công (Đã đổi ID)!");
                    btRead_Click(null, null);
                    ResetInput();
                }
                else MessageBox.Show("Không tìm thấy dữ liệu cũ để sửa!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật (ID mới có thể đã tồn tại): " + ex.Message);
            }
            finally { conn.Close(); }
        }

        // --- 6. XÓA ---
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    OpenConnection();
                    // Khi xóa cũng nên dùng ID cũ để an toàn, hoặc dùng ID từ TextBox nếu chưa sửa
                    string idToDelete = string.IsNullOrEmpty(originalId) ? tbId.Text : originalId;

                    string sql = "DELETE FROM customer WHERE id=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idToDelete);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        btRead_Click(null, null);
                        ResetInput();
                    }
                    else MessageBox.Show("Không tìm thấy ID!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
                finally { conn.Close(); }
            }
        }

        private void ResetInput()
        {
            tbId.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            pbAvatar.Image = null;
            currentImagePath = "";
            dtpDob.Value = DateTime.Now;
            originalId = ""; // Reset ID gốc
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}