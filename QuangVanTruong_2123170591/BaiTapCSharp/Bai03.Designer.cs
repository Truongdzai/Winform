namespace WinFormsApp_Article
{
    partial class Bai03
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
            this.Name = "Bai03";
            this.Text = "Bai 03: Save XML";
            // Các sự kiện đã được gán trong file .cs chính nên không cần gán ở đây nữa 
            // để tránh lỗi lặp.
            this.ResumeLayout(false);
        }
    }
}