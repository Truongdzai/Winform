using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADO
{
    public partial class StatsForm : Form
    {
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";

        public StatsForm()
        {
            InitializeComponent();
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {
            // Mặc định chọn từ đầu tháng đến hiện tại
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            LoadStats();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats()
        {
            dgvStats.Rows.Clear();
            decimal totalRevenue = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    // Câu lệnh SQL lấy hóa đơn trong khoảng thời gian
                    // Kết hợp (JOIN) để lấy tên khách hàng thay vì chỉ hiện ID
                    string sql = @"
                        SELECT i.id, i.created_date, c.name, i.total_amount 
                        FROM invoice i
                        LEFT JOIN customer c ON i.customer_id = c.id
                        WHERE i.created_date BETWEEN @from AND @to";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Set giờ về 00:00:00 và 23:59:59 để bao trọn ngày
                        cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date.AddDays(1).AddSeconds(-1));

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                decimal amount = Convert.ToDecimal(rd["total_amount"]);
                                totalRevenue += amount;

                                dgvStats.Rows.Add(
                                    rd["id"],
                                    Convert.ToDateTime(rd["created_date"]).ToString("dd/MM/yyyy HH:mm"),
                                    rd["name"],
                                    amount.ToString("N0")
                                );
                            }
                        }
                    }
                }

                // Hiển thị tổng tiền
                lblTotalRevenue.Text = totalRevenue.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message);
            }
        }
    }
}