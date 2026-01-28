using System;
using System.Windows.Forms;

namespace ADO
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btCustomer_Click(object sender, EventArgs e)
        {
            // Mở quản lý Khách hàng
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void btProduct_Click(object sender, EventArgs e)
        {
            // Mở quản lý Sản phẩm
            ProductForm f = new ProductForm();
            f.ShowDialog();
        }

        private void btInvoice_Click(object sender, EventArgs e)
        {
            // Mở lập Hóa đơn (Bán hàng)
            InvoiceForm f = new InvoiceForm();
            f.ShowDialog();
        }

        private void btStats_Click(object sender, EventArgs e)
        {
            // Mở Thống kê doanh thu
            StatsForm f = new StatsForm();
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
    }
}