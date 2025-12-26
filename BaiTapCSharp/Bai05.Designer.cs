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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 400);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Bai05";
            this.Text = "Bai 05: Key Logger";

            // --- CẤU HÌNH QUAN TRỌNG CHO KEY LOGGER ---
            this.KeyPreview = true;       // Bắt phím dù tiêu điểm ở đâu
            this.ShowInTaskbar = false;   // Ẩn khỏi thanh Taskbar (tùy chọn)

            // Kết nối sự kiện KeyUp vào hàm xử lý
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Bai05_KeyUp);

            this.ResumeLayout(false);
        }
    }
}