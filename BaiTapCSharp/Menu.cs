using System;
using System.Windows.Forms;

namespace WinFormsApp_Article
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        // --- NHÓM CƠ BẢN (00 - 09) ---
        private void btnBai00_Click(object sender, EventArgs e) { new Bai00().ShowDialog(); }
        private void btnBai01_Click(object sender, EventArgs e) { new Bai01().ShowDialog(); }
        private void btnBai02_Click(object sender, EventArgs e) { new Bai02().ShowDialog(); }
        private void btnBai03_Click(object sender, EventArgs e) { new Bai03().ShowDialog(); }
        private void btnBai04_Click(object sender, EventArgs e) { MessageBox.Show("Bài 04: Demo Message Box (Không có Form)"); }
        private void btnBai05_Click(object sender, EventArgs e) { new Bai05().ShowDialog(); }
        private void btnBai06_Click(object sender, EventArgs e) { new Bai06().ShowDialog(); }
        private void btnBai07_Click(object sender, EventArgs e) { new Bai07().ShowDialog(); }
        private void btnBai08_Click(object sender, EventArgs e) { new Bai08().ShowDialog(); }
        private void btnBai09_Click(object sender, EventArgs e) { new Bai09().ShowDialog(); }

        // --- NHÓM CONTROL & LOGIC (10 - 19) ---
        private void btnBai10_Click(object sender, EventArgs e) { new Bai10().ShowDialog(); }
        private void btnBai11_Click(object sender, EventArgs e) { new Bai11().ShowDialog(); }
        private void btnBai12_Click(object sender, EventArgs e) { new Bai12().ShowDialog(); }
        private void btnBai13_Click(object sender, EventArgs e) { new Bai13().ShowDialog(); }
        private void btnBai14_Click(object sender, EventArgs e) { new Bai14().ShowDialog(); }
        private void btnBai15_Click(object sender, EventArgs e) { new Bai15().ShowDialog(); }
        private void btnBai16_Click(object sender, EventArgs e) { new Bai16().ShowDialog(); }
        private void btnBai17_Click(object sender, EventArgs e) { new Bai17().ShowDialog(); }
        private void btnBai18_Click(object sender, EventArgs e) { new Bai18().ShowDialog(); }
        private void btnBai19_Click(object sender, EventArgs e) { new Bai19().ShowDialog(); }

        // --- NHÓM DATA & GAME BASIC (20 - 29) ---
        private void btnBai20_Click(object sender, EventArgs e) { new Bai20().ShowDialog(); }
        private void btnBai21_Click(object sender, EventArgs e) { new Bai21().ShowDialog(); }
        private void btnBai22_Click(object sender, EventArgs e) { new Bai22().ShowDialog(); }
        private void btnBai23_Click(object sender, EventArgs e) { new Bai23().ShowDialog(); }
        private void btnBai24_Click(object sender, EventArgs e) { new Bai24().ShowDialog(); }
        private void btnBai25_Click(object sender, EventArgs e) { new Bai25().ShowDialog(); }
        private void btnBai26_Click(object sender, EventArgs e) { new Bai26().ShowDialog(); }
        private void btnBai27_Click(object sender, EventArgs e) { new Bai27().ShowDialog(); }
        private void btnBai28_Click(object sender, EventArgs e) { new Bai28().ShowDialog(); }

        // Bài 29: UserControl (Form1 chứa 3 màn hình con)
        private void btnBai29_Click(object sender, EventArgs e) { new Form1().ShowDialog(); }

        // --- NHÓM PROJECT & GAME NÂNG CAO (30 - 32) ---

        // Bài 30: Quản Lý Sinh Viên Full
        private void btnBai30_Click(object sender, EventArgs e) { new Bai30().ShowDialog(); }

        // Bài 31: Game TOO EASY (GDI+ Rage Game)
        private void btnBai31_Click(object sender, EventArgs e) { new Bai31().ShowDialog(); }

        // Bài 32: Game LEVEL DEVIL (Advanced Platformer)
        private void btnBai32_Click(object sender, EventArgs e) { new Bai32().ShowDialog(); }
    }
}