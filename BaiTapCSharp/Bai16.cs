using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai16 : Form
    {
        public Bai16()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form bắt đầu chạy -> Nạp dữ liệu vào ComboBox Khoa
        private void Bai16_Load(object sender, EventArgs e)
        {
            cbFaculty.Items.Add("Công nghệ thông tin");
            cbFaculty.Items.Add("Kế toán tài chính");
            cbFaculty.Items.Add("Quản trị kinh doanh");
            cbFaculty.Items.Add("Cơ khí động lực");

            // Chọn mặc định dòng đầu tiên
            cbFaculty.SelectedIndex = 0;
        }

        // Sự kiện nút THÊM
        private void btAdd_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập tên chưa
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!", "Thông báo");
                tbName.Focus();
                return;
            }

            // 2. Lấy thông tin từ các điều khiển
            string name = tbName.Text;
            string date = dtpBirth.Value.ToShortDateString(); // Lấy ngày ngắn
            string gender = rbMale.Checked ? "Nam" : "Nữ";
            string faculty = cbFaculty.Text;

            // 3. Tạo chuỗi kết quả (đếm số lượng hiện có để đánh số thứ tự)
            int count = lbInfo.Items.Count + 1;
            string info = count + ". " + name + " - " + gender + " - " + date + " - " + faculty;

            // 4. Thêm vào ListBox
            lbInfo.Items.Add(info);

            // 5. Xóa tên để nhập người tiếp theo cho nhanh
            tbName.Text = "";
            tbName.Focus();
        }

        // Sự kiện nút THOÁT
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}