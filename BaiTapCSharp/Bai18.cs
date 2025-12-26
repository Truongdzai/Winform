using System;
using System.Collections; // Cần thư viện này để dùng ArrayList
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai18 : Form
    {
        // Khai báo danh sách gốc để quản lý dữ liệu
        ArrayList songList;

        public Bai18()
        {
            InitializeComponent();
        }

        // 1. Hàm tạo dữ liệu giả (Slide 123)
        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();

            Song s1 = new Song();
            s1.Id = 53418;
            s1.Name = "Giấc mơ Cha pi";
            s1.Author = "Trần Tiến";
            lst.Add(s1);

            Song s2 = new Song();
            s2.Id = 52616;
            s2.Name = "Đôi mắt Pleiku";
            s2.Author = "Nguyễn Cường";
            lst.Add(s2);

            Song s3 = new Song();
            s3.Id = 51172;
            s3.Name = "Em muốn sống bên anh trọn đời";
            s3.Author = "Nguyễn Cường";
            lst.Add(s3);

            return lst;
        }

        // 2. Load Form: Đổ dữ liệu vào ListBox trái (Slide 124)
        private void Bai18_Load(object sender, EventArgs e)
        {
            songList = GetData();

            // Gán nguồn dữ liệu
            lbSong.DataSource = songList;
            // Chỉ định hiển thị thuộc tính "Name" ra màn hình
            lbSong.DisplayMember = "Name";
            // Giá trị ngầm định (nếu cần)
            lbSong.ValueMember = "Id";
        }

        // 3. Nút Chọn (>): Lấy object -> ghép chuỗi -> bỏ sang phải (Slide 124)
        private void btSelect_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có chọn bài nào không
            if (lbSong.SelectedItem != null)
            {
                // Ép kiểu item đang chọn về dạng Class Song
                Song song = (Song)lbSong.SelectedItem;

                string id = song.Id.ToString();
                string name = song.Name;
                string author = song.Author;

                // Tạo chuỗi hiển thị bên phải
                string info = id + " - " + name + " - " + author;

                // Thêm vào ListBox Phải (ListBox này chứa chuỗi String, không phải Object)
                lbFavorite.Items.Add(info);
            }
        }

        // 4. Nút Bỏ chọn (<): Xóa khỏi danh sách yêu thích
        private void btDeselect_Click(object sender, EventArgs e)
        {
            if (lbFavorite.SelectedIndex != -1)
            {
                lbFavorite.Items.RemoveAt(lbFavorite.SelectedIndex);
            }
        }
    }
}