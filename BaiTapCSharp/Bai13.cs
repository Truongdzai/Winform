using System;
using System.Windows.Forms;
using System.Collections; 

namespace WinFormsApp_Article
{
    public partial class Bai13 : Form
    {
        public Bai13()
        {
            InitializeComponent();
        }

        // 1. Hàm tạo dữ liệu giả
        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();

            Faculty f1 = new Faculty(); f1.Id = "K01"; f1.Name = "Công nghệ thông tin"; f1.Quantity = 1200;
            lst.Add(f1);

            Faculty f2 = new Faculty(); f2.Id = "K02"; f2.Name = "Quản trị kinh doanh"; f2.Quantity = 4200;
            lst.Add(f2);

            Faculty f3 = new Faculty(); f3.Id = "K03"; f3.Name = "Kế toán tài chính"; f3.Quantity = 5200;
            lst.Add(f3);

            return lst;
        }

        // 2. Form Load: Đổ dữ liệu vào ComboBox
        private void Bai13_Load(object sender, EventArgs e)
        {
            ArrayList lst = GetData();
            cb_Faculty.DataSource = lst;       // Nguồn dữ liệu
            cb_Faculty.DisplayMember = "Name"; // Hiển thị Tên (Name) ra ngoài
        }

        // 3. Sự kiện chọn: Lấy Mã (Id)
        private void cb_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Slide hướng dẫn set ValueMember ngay tại đây để lấy Id
            cb_Faculty.ValueMember = "Id";

            if (cb_Faculty.SelectedValue != null)
            {
                string id = cb_Faculty.SelectedValue.ToString();
                tbDisplay.Text = "Bạn đã chọn khoa có mã: " + id;
            }
        }

        // 4. Sự kiện OK: Lấy Tên (Name)
        private void bt_OK_Click(object sender, EventArgs e)
        {
            // Slide hướng dẫn đổi ValueMember thành Name để lấy Tên
            cb_Faculty.ValueMember = "Name";

            string name = cb_Faculty.SelectedValue.ToString();
            tbDisplay.Text = "Bạn đã chọn khoa có tên: " + name;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = "";           // Xóa trắng ô kết quả
            cb_Faculty.SelectedIndex = -1; // Reset ComboBox về trạng thái chưa chọn gì
            cb_Faculty.Text = "";          // Xóa chữ trên ComboBox 
            cb_Faculty.Focus();            // Đưa con trỏ chuột quay về ComboBox
        }
    }
}