namespace WinFormsApp_Article
{
    partial class Bai05
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Bai05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "Bai05";
            this.Text = "Bai 05: Key Logger";

            // --- CẤU HÌNH THEO SLIDE 45 ---
            this.KeyPreview = true;          // Bắt buộc để bắt phím
            this.ShowInTaskbar = false;      // Ẩn dưới thanh Taskbar
            // -------------------------------

            this.ResumeLayout(false);
        }
    }
}