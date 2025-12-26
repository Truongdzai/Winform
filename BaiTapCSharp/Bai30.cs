using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Cần thiết để dùng chức năng Tìm kiếm (Where/ToList)
using System.Windows.Forms;
using System.IO;
namespace WinFormsApp_Article
{
    public partial class Bai30 : Form
    {
        // Danh sách gốc chứa dữ liệu
        List<Student> lstStudent = new List<Student>();
        // BindingSource làm trung gian (Bài 22)
        BindingSource bs = new BindingSource();

        // Biến cờ để biết đang Thêm hay đang Sửa
        bool isAdding = false;
        string currentImagePath = ""; // Lưu đường dẫn ảnh tạm

        public Bai30()
        {
            InitializeComponent();
        }

        // --- 1. KHỞI TẠO DỮ LIỆU ---
        private void Bai30_Load(object sender, EventArgs e)
        {
            // Tạo dữ liệu mẫu
            lstStudent.Add(new Student { Id = "SV01", Name = "Nguyễn Văn A", ClassName = "CNTT K15", Gender = true });
            lstStudent.Add(new Student { Id = "SV02", Name = "Trần Thị B", ClassName = "Kinh Tế K16", Gender = false });

            // Gán vào BindingSource
            bs.DataSource = lstStudent;
            dgvData.DataSource = bs;

            // Khóa các ô nhập liệu khi mới vào
            ToggleInputs(false);
        }

        // Hàm bật/tắt các ô nhập liệu
        void ToggleInputs(bool enable)
        {
            tbId.Enabled = enable;
            tbName.Enabled = enable;
            cboClass.Enabled = enable;
            ckGender.Enabled = enable;
            btBrowse.Enabled = enable;

            btSave.Enabled = enable; // Nút Lưu chỉ sáng khi đang nhập

            btAdd.Enabled = !enable; // Các nút chức năng thì ngược lại
            btEdit.Enabled = !enable;
            btDelete.Enabled = !enable;
        }

        // Hàm xóa trắng form
        void ClearInputs()
        {
            tbId.Clear();
            tbName.Clear();
            cboClass.SelectedIndex = -1;
            ckGender.Checked = false;
            pbAvatar.Image = null;
            currentImagePath = "";
        }

        // --- 2. BINDING NGƯỢC (CLICK GRID -> HIỆN LÊN TEXTBOX) ---
        private void dgvData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= bs.Count) return;

            // Lấy đối tượng đang chọn từ BindingSource
            Student s = (Student)bs[e.RowIndex];

            // Đổ dữ liệu ra Form
            tbId.Text = s.Id;
            tbName.Text = s.Name;
            cboClass.Text = s.ClassName;
            ckGender.Checked = s.Gender;

            // Hiển thị ảnh (Article 19)
            if (!string.IsNullOrEmpty(s.ImagePath))
            {
                try { pbAvatar.Image = Image.FromFile(s.ImagePath); }
                catch { pbAvatar.Image = null; }
            }
            else pbAvatar.Image = null;
        }

        // --- 3. NÚT CHỌN ẢNH (ARTICLE 19) ---
        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentImagePath = dlg.FileName;

                    // 1. Giải phóng ảnh cũ nếu đang có (tránh rò rỉ bộ nhớ)
                    if (pbAvatar.Image != null)
                    {
                        pbAvatar.Image.Dispose();
                        pbAvatar.Image = null;
                    }

                    // 2. CÁCH KHẮC PHỤC LỖI OUT OF MEMORY:
                    // Đọc file thành các byte rồi nạp vào MemoryStream
                    // Cách này an toàn hơn Image.FromFile rất nhiều
                    byte[] imageBytes = File.ReadAllBytes(currentImagePath);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Tạo ảnh từ dòng dữ liệu trong bộ nhớ
                        Image img = Image.FromStream(ms);

                        // Gán vào PictureBox (Tạo bản sao để không bị phụ thuộc vào Stream đã đóng)
                        pbAvatar.Image = new Bitmap(img);
                    }

                    // 3. Chỉnh chế độ hiển thị đẹp
                    pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ảnh này bị lỗi hoặc định dạng không hỗ trợ!\nChi tiết: " + ex.Message);
                }
            }
        }

        // --- 4. CHỨC NĂNG THÊM ---
        private void btAdd_Click(object sender, EventArgs e)
        {
            isAdding = true; // Đánh dấu là đang thêm mới
            ClearInputs();   // Xóa trắng để nhập
            ToggleInputs(true); // Bật ô nhập
            tbId.Focus();
        }

        // --- 5. CHỨC NĂNG SỬA ---
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (bs.Current == null) return;
            isAdding = false; // Đánh dấu là đang sửa
            ToggleInputs(true);
            tbId.Enabled = false; // Không cho sửa Mã Sinh Viên (Khóa chính)
        }

        // --- 6. CHỨC NĂNG XÓA ---
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (bs.Current != null)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bs.RemoveCurrent(); // Xóa khỏi BindingSource là xong (Article 22)
                }
            }
        }

        // --- 7. CHỨC NĂNG LƯU (QUAN TRỌNG NHẤT) ---
        private void btSave_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu (Bài 7)
            if (string.IsNullOrEmpty(tbId.Text) || string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên!");
                return;
            }

            if (isAdding)
            {
                // Logic THÊM MỚI
                Student s = new Student();
                s.Id = tbId.Text;
                s.Name = tbName.Text;
                s.ClassName = cboClass.Text;
                s.Gender = ckGender.Checked;
                s.ImagePath = currentImagePath;

                bs.Add(s); // Thêm vào BindingSource
            }
            else
            {
                // Logic CẬP NHẬT
                Student s = (Student)bs.Current; // Lấy sinh viên đang chọn
                s.Name = tbName.Text;
                s.ClassName = cboClass.Text;
                s.Gender = ckGender.Checked;
                if (!string.IsNullOrEmpty(currentImagePath))
                    s.ImagePath = currentImagePath; // Chỉ cập nhật ảnh nếu có chọn ảnh mới

                bs.ResetCurrentItem(); // Refresh lại dòng đang chọn trên lưới
            }

            // Xong việc thì khóa lại
            ToggleInputs(false);
            MessageBox.Show("Đã lưu thành công!");
        }

        // --- 8. TÌM KIẾM (BONUS) ---
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // Lọc danh sách gốc theo tên
            string keyword = tbSearch.Text.ToLower();
            var filteredList = lstStudent.Where(s => s.Name.ToLower().Contains(keyword)).ToList();

            // Gán danh sách đã lọc vào BindingSource
            bs.DataSource = filteredList;
        }
    }
}