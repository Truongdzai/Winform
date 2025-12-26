namespace WinFormsApp_Article
{
    partial class Bai26
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
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Text = "Game: Catch Egg";
            // Quan trọng: Gán sự kiện Load
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        #endregion
    }
}