using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Bai17 : Form
    {
        public Bai17()
        {
            InitializeComponent();
        }

        // 1. CHỌN MỘT BÀI (>)
        private void btSelect_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có bài nào đang được chọn không
            if (lbSong.SelectedIndex != -1)
            {
                string song = lbSong.SelectedItem.ToString();
                lbFavorite.Items.Add(song);          // Thêm sang phải
                lbSong.Items.RemoveAt(lbSong.SelectedIndex); // Xóa bên trái
            }
        }

        // 2. BỎ CHỌN MỘT BÀI (<)
        private void btDeselect_Click(object sender, EventArgs e)
        {
            if (lbFavorite.SelectedIndex != -1)
            {
                string song = lbFavorite.SelectedItem.ToString();
                lbSong.Items.Add(song);              // Trả về trái
                lbFavorite.Items.RemoveAt(lbFavorite.SelectedIndex); // Xóa bên phải
            }
        }

        // 3. CHỌN TẤT CẢ (>>)
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            // Duyệt tất cả phần tử bên trái đưa sang phải
            // Cách nhanh nhất: Dùng AddRange và Clear
            lbFavorite.Items.AddRange(lbSong.Items);
            lbSong.Items.Clear();
        }

        // 4. BỎ CHỌN TẤT CẢ (<<)
        private void btDeselectAll_Click(object sender, EventArgs e)
        {
            lbSong.Items.AddRange(lbFavorite.Items);
            lbFavorite.Items.Clear();
        }

        // (Nâng cao - Slide 119) Click đúp chuột để chọn nhanh
        private void lbSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbSong.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string song = lbSong.Items[index].ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(index);
            }
        }
    }
}