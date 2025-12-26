using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai20 : Form
    {
        public Bai20()
        {
            InitializeComponent();
        }

        // 1. Sự kiện nút THÊM (Slide 136)
        private void btAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đơn giản
            if (string.IsNullOrEmpty(tbId.Text) || string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Thêm dòng mới vào DataGridView
            // Thứ tự: Mã, Tên, Tuổi, Giới tính (True/False)
            dgvEmployee.Rows.Add(tbId.Text, tbName.Text, tbAge.Text, ckGender.Checked);

            // Xóa textbox sau khi thêm
            tbId.Clear();
            tbName.Clear();
            tbAge.Clear();
            ckGender.Checked = false;
            tbId.Focus();
        }

        // 2. Sự kiện nút XÓA (Slide 137)
        private void btDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn không
            if (dgvEmployee.CurrentCell != null && dgvEmployee.CurrentCell.RowIndex != -1)
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
            else
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
            }
        }

        // 3. Sự kiện KHI CHỌN DÒNG (RowEnter) - Đổ dữ liệu ngược lại TextBox (Slide 137)
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            // Kiểm tra dòng hợp lệ (không phải dòng tiêu đề hoặc dòng trống cuối cùng)
            if (idx >= 0 && idx < dgvEmployee.Rows.Count)
            {
                // Lấy giá trị từng ô (Cell) theo thứ tự cột 0, 1, 2, 3
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