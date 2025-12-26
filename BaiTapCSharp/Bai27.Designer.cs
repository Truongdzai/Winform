namespace WinFormsApp_Article
{
    partial class Bai27
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600); // Tăng chiều cao để có chỗ cho giỏ
            this.Text = "Game: Catch Egg (Full)";

            // 1. Sự kiện Load để khởi tạo game
            this.Load += new System.EventHandler(this.Bai27_Load);

            // 2. Sự kiện KeyDown để bắt phím bấm (Slide 174)
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Bai27_KeyDown);

            // QUAN TRỌNG: Phải bật KeyPreview thì Form mới nhận được phím bấm
            this.KeyPreview = true;
        }

        #endregion
    }
}