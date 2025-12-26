using System;
using System.Collections.Generic; // Cần thiết để dùng List
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai21 : Form
    {
        // Khai báo List để quản lý dữ liệu (Slide 142)
        List<Employee> lst = new List<Employee>();

        public Bai21()
        {
            InitializeComponent();
        }

        // 1. Hàm tạo dữ liệu mẫu (Slide 141)
        public List<Employee> GetData()
        {
            List<Employee> data = new List<Employee>();

            Employee e1 = new Employee();
            e1.Id = "53418"; e1.Name = "Trần Tiến"; e1.Age = 20; e1.Gender = true;
            data.Add(e1);

            Employee e2 = new Employee();
            e2.Id = "53416"; e2.Name = "Nguyễn Cường"; e2.Age = 25; e2.Gender = false;
            data.Add(e2);

            Employee e3 = new Employee();
            e3.Id = "53417"; e3.Name = "Nguyễn Hào"; e3.Age = 23; e3.Gender = true;
            data.Add(e3);

            return data;
        }

        // 2. Form Load: Đổ dữ liệu từ List vào Grid (Slide 142)
        private void Bai21_Load(object sender, EventArgs e)
        {
            lst = GetData();

            // Duyệt danh sách và thêm từng dòng vào Grid
            foreach (Employee em in lst)
            {
                dgvEmployee.Rows.Add(em.Id, em.Name, em.Age, em.Gender);
            }
        }

        // 3. Thêm mới (Slide 143)
        private void btAdd_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Employee mới
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            // Xử lý chuyển đổi tuổi an toàn
            int age = 0;
            int.TryParse(tbAge.Text, out age);
            em.Age = age;
            em.Gender = ckGender.Checked;

            // Thêm vào List (Dữ liệu nền)
            lst.Add(em);

            // Thêm vào Grid (Giao diện)
            dgvEmployee.Rows.Add(em.Id, em.Name, em.Age, em.Gender);

            // Xóa ô nhập
            tbId.Clear(); tbName.Clear(); tbAge.Clear(); ckGender.Checked = false;
        }

        // 4. Xóa (Slide 144)
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentCell != null)
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;

                // Xóa trong List trước
                if (idx < lst.Count) lst.RemoveAt(idx);

                // Xóa trên Grid sau
                dgvEmployee.Rows.RemoveAt(idx);
            }
        }

        // 5. Binding ngược lại TextBox (Slide 144)
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < dgvEmployee.Rows.Count)
            {
                if (dgvEmployee.Rows[idx].Cells[0].Value != null)
                    tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[1].Value != null)
                    tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[2].Value != null)
                    tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[3].Value != null)
                    ckGender.Checked = bool.Parse(dgvEmployee.Rows[idx].Cells[3].Value.ToString());
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}