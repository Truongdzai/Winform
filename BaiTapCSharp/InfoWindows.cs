using System;
using System.Drawing; // [Quan trọng] Thêm dòng này để dùng Point

namespace WinFormsApp_Article
{
    public class InfoWindows
    {
        public int Width { get; set; }
        public int Height { get; set; }

        // Thêm thuộc tính này cho Article 03
        public Point Location { get; set; }
    }
}