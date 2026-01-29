using System;
using System.IO;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADO
{
    public partial class MainForm : Form
    {
        // Chuỗi kết nối Windows Auth
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";

        public MainForm()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN CÁC NÚT TRÊN DASHBOARD ---

        private void btCustomer_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void btProduct_Click(object sender, EventArgs e)
        {
            ProductForm f = new ProductForm();
            f.ShowDialog();
        }

        private void btInvoice_Click(object sender, EventArgs e)
        {
            InvoiceForm f = new InvoiceForm();
            f.ShowDialog();
        }

        private void btStats_Click(object sender, EventArgs e)
        {
            StatsForm f = new StatsForm();
            f.ShowDialog();
        }

        // SỰ KIỆN MỚI: Mở Thư viện từ nút trên Dashboard
        private void btGallery_Click(object sender, EventArgs e)
        {
            GalleryForm f = new GalleryForm();
            f.ShowDialog();
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Dashboard -> Quay về Login
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Xử lý khi đóng form (nếu cần)
        }

        // --- SỰ KIỆN MENU ---

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Sự kiện mở Thư viện Hình ảnh từ Menu (Giữ lại)
        private void menuGallery_Click(object sender, EventArgs e)
        {
            GalleryForm f = new GalleryForm();
            f.ShowDialog();
        }

        private void menuImportProduct_Click(object sender, EventArgs e)
        {
            ImportData("product");
        }

        private void menuImportCustomer_Click(object sender, EventArgs e)
        {
            ImportData("customer");
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm Quản lý Bán hàng\nPhiên bản 1.0\nDeveloped by Truong", "Giới thiệu");
        }

        // --- LOGIC NHẬP DỮ LIỆU TỪ EXCEL (CSV) ---

        private void ImportData(string tableName)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV Files|*.csv",
                Title = $"Chọn file CSV để nhập {tableName}"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int successCount = 0;
                int errorCount = 0;

                try
                {
                    string[] lines = File.ReadAllLines(ofd.FileName);

                    // Bỏ qua dòng tiêu đề (i=1)
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i])) continue;

                        string[] parts = lines[i].Split(',');

                        if (tableName == "product" && parts.Length < 4) continue;
                        if (tableName == "customer" && parts.Length < 4) continue;

                        if (InsertRecord(tableName, parts))
                            successCount++;
                        else
                            errorCount++;
                    }

                    MessageBox.Show($"Nhập xong!\n- Thành công: {successCount}\n- Lỗi/Trùng: {errorCount}", "Kết quả Import");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file: " + ex.Message);
                }
            }
        }

        private bool InsertRecord(string tableName, string[] data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    string sql = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (tableName == "product")
                    {
                        sql = "INSERT INTO product (id, name, price, unit) VALUES (@id, @name, @price, @unit)";
                        cmd.Parameters.AddWithValue("@id", data[0].Trim());
                        cmd.Parameters.AddWithValue("@name", data[1].Trim().Trim('"'));
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(data[2].Trim()));
                        cmd.Parameters.AddWithValue("@unit", data[3].Trim());
                    }
                    else if (tableName == "customer")
                    {
                        sql = "INSERT INTO customer (id, name, DateOfBirth, Phone) VALUES (@id, @name, @dob, @phone)";
                        cmd.Parameters.AddWithValue("@id", int.Parse(data[0].Trim()));
                        cmd.Parameters.AddWithValue("@name", data[1].Trim().Trim('"'));
                        cmd.Parameters.AddWithValue("@dob", DateTime.Parse(data[2].Trim()));
                        cmd.Parameters.AddWithValue("@phone", data[3].Trim());
                    }

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}