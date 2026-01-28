using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADO
{
    public partial class InvoiceForm : Form
    {
        private readonly string strCon = @"Data Source=.;Initial Catalog=sale;Integrated Security=True;TrustServerCertificate=True";

        // Biến lưu tổng tiền tạm tính
        private decimal cartTotal = 0;

        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            // Tự động sinh mã hóa đơn theo thời gian: HD + yyyyMMddHHmmss
            tbInvoiceId.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    // 1. Load Khách hàng
                    SqlDataAdapter daCust = new SqlDataAdapter("SELECT id, name FROM customer", conn);
                    DataTable dtCust = new DataTable();
                    daCust.Fill(dtCust);
                    // Thêm dòng chọn mặc định
                    DataRow row = dtCust.NewRow(); row["id"] = -1; row["name"] = "-- Chọn Khách Hàng --";
                    dtCust.Rows.InsertAt(row, 0);

                    cbCustomer.DataSource = dtCust;
                    cbCustomer.DisplayMember = "name";
                    cbCustomer.ValueMember = "id";
                    cbCustomer.SelectedIndex = 0;

                    // 2. Load Sản phẩm
                    SqlDataAdapter daProd = new SqlDataAdapter("SELECT id, name, price, unit FROM product", conn);
                    DataTable dtProd = new DataTable();
                    daProd.Fill(dtProd);

                    cbProduct.DataSource = dtProd;
                    cbProduct.DisplayMember = "name";
                    cbProduct.ValueMember = "id";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // Khi chọn sản phẩm thì tự động điền giá và đơn vị
        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedItem is DataRowView row)
            {
                tbPrice.Text = Convert.ToDecimal(row["price"]).ToString("N0");
                tbUnit.Text = row["unit"].ToString();
            }
        }

        // Thêm sản phẩm vào giỏ hàng (DataGridView)
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (cbProduct.SelectedIndex < 0) return;

            // Lấy thông tin từ form
            string prodId = cbProduct.SelectedValue.ToString();
            string prodName = cbProduct.Text;
            decimal price = decimal.Parse(tbPrice.Text.Replace(",", "").Replace(".", "")); // Xử lý dấu phân cách ngàn
            int qty = (int)numQty.Value;
            decimal amount = price * qty;

            if (qty <= 0) { MessageBox.Show("Số lượng phải > 0"); return; }

            // Kiểm tra xem sản phẩm đã có trong giỏ chưa để cộng dồn
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["colProdId"].Value.ToString() == prodId)
                {
                    int oldQty = int.Parse(row.Cells["colQty"].Value.ToString());
                    decimal oldAmount = decimal.Parse(row.Cells["colAmount"].Value.ToString());

                    // Cập nhật dòng cũ
                    row.Cells["colQty"].Value = oldQty + qty;
                    row.Cells["colAmount"].Value = oldAmount + amount;

                    UpdateTotal(amount); // Cộng thêm tiền vào tổng
                    return;
                }
            }

            // Nếu chưa có thì thêm dòng mới
            dgvCart.Rows.Add(prodId, prodName, qty, price.ToString("N0"), amount.ToString("N0"));
            UpdateTotal(amount);
        }

        private void UpdateTotal(decimal amountToAdd)
        {
            cartTotal += amountToAdd;
            lblTotal.Text = cartTotal.ToString("N0") + " VNĐ";
        }

        // Lưu Hóa Đơn (Thanh toán)
        private void btSave_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0) { MessageBox.Show("Giỏ hàng đang trống!"); return; }
            if (cbCustomer.SelectedIndex <= 0) { MessageBox.Show("Vui lòng chọn khách hàng!"); return; }

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // Dùng transaction để đảm bảo toàn vẹn dữ liệu

                try
                {
                    // 1. Lưu vào bảng invoice
                    string sqlInvoice = "INSERT INTO invoice (id, customer_id, total_amount) VALUES (@id, @custId, @total)";
                    using (SqlCommand cmd = new SqlCommand(sqlInvoice, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", tbInvoiceId.Text);
                        cmd.Parameters.AddWithValue("@custId", cbCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@total", cartTotal);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Lưu chi tiết vào bảng invoice_detail
                    string sqlDetail = "INSERT INTO invoice_detail (invoice_id, product_id, quantity, price, amount) VALUES (@invId, @prodId, @qty, @price, @amt)";
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlDetail, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@invId", tbInvoiceId.Text);
                            cmd.Parameters.AddWithValue("@prodId", row.Cells["colProdId"].Value);
                            cmd.Parameters.AddWithValue("@qty", int.Parse(row.Cells["colQty"].Value.ToString()));
                            cmd.Parameters.AddWithValue("@price", decimal.Parse(row.Cells["colPrice"].Value.ToString().Replace(".", ""))); // Parse lại từ string format
                            cmd.Parameters.AddWithValue("@amt", decimal.Parse(row.Cells["colAmount"].Value.ToString().Replace(".", "")));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit(); // Xác nhận lưu thành công
                    MessageBox.Show("Thanh toán thành công!");

                    // Reset form để bán tiếp
                    dgvCart.Rows.Clear();
                    cartTotal = 0;
                    lblTotal.Text = "0 VNĐ";
                    tbInvoiceId.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Nếu lỗi thì hoàn tác, không lưu gì cả
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message);
                }
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCart.SelectedRows)
                {
                    decimal amount = decimal.Parse(row.Cells["colAmount"].Value.ToString().Replace(".", ""));
                    UpdateTotal(-amount); // Trừ tiền
                    dgvCart.Rows.Remove(row);
                }
            }
        }
    }
}