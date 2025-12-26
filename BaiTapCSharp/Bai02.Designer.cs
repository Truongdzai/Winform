namespace WinFormsApp_Article
{
    partial class Bai02
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
            // Bai01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "Bai02";
            this.Text = "Bai 02: Save XML";
            // Các sự kiện đã được gán trong file .cs chính nên không cần gán ở đây nữa 
            // để tránh lỗi lặp.
            this.ResumeLayout(false);
        }
    }
}