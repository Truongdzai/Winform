namespace WinFormsApp_Article
{
    partial class Bai28
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
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Text = "Game: Chicken & Egg";

            // 1. Sự kiện Load
            this.Load += new System.EventHandler(this.Bai28_Load);

            // 2. Sự kiện KeyDown để di chuyển giỏ
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Bai28_KeyDown);

            // QUAN TRỌNG: Để nhận phím bấm
            this.KeyPreview = true;
        }

        #endregion
    }
}