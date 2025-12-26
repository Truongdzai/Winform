using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai22 : Form
    {
        // 1. Khai báo BindingSource (Slide 149)
        BindingSource bs = new BindingSource();
        List<Employee> lst = new List<Employee>();

        public Bai22()
        {
            InitializeComponent();
        }

        public List<Employee> GetData()
        {
            List<Employee> data = new List<Employee>();
            data.Add(new Employee { Id = "53418", Name = "Trần Tiến", Age = 20, Gender = true });
            data.Add(new Employee { Id = "53416", Name = "Nguyễn Cường", Age = 25, Gender = false });
            data.Add(new Employee { Id = "53417", Name = "Nguyễn Hào", Age = 23, Gender = true });
            return data;
        }

        // 2. Form Load: Kết nối List -> BindingSource -> DataGridView
        private void Bai22_Load(object sender, EventArgs e)
        {
            lst = GetData();
            bs.DataSource = lst;
            dgvEmployee.DataSource = bs;
        }

        // 3. Thêm mới thông qua BindingSource (Slide 149)
        private void btAdd_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            int age = 0;
            int.TryParse(tbAge.Text, out age);
            em.Age = age;
            em.Gender = ckGender.Checked;

            // QUAN TRỌNG: Chỉ cần thêm vào BindingSource, Grid tự cập nhật
            bs.Add(em);

            // Dọn dẹp ô nhập
            tbId.Clear(); tbName.Clear(); tbAge.Clear(); ckGender.Checked = false;
            tbId.Focus();
        }

        // 4. Xóa thông qua BindingSource (Slide 150)
        private void btDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
            if (dgvEmployee.CurrentCell != null)
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;

                // BindingSource tự động xử lý xóa cả trong List và trên Grid
                bs.RemoveAt(idx);
            }
        }

        // 5. Binding ngược lại TextBox (Giống bài trước)
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < dgvEmployee.Rows.Count)
            {
                // Vì dùng BindingSource nên có thể lấy object trực tiếp
                // Employee em = (Employee)bs[idx]; 
                // Nhưng làm theo cách truyền thống của Slide để bạn dễ hiểu:
                if (dgvEmployee.Rows[idx].Cells[0].Value != null)
                    tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[1].Value != null)
                    tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[2].Value != null)
                    tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[3].Value != null)
                    ckGender.Checked = (bool)dgvEmployee.Rows[idx].Cells[3].Value;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}