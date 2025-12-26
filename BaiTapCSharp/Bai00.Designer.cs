namespace WinFormsApp_Article
{
    partial class Bai00
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
            // Bai00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 400);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Bai00";
            this.Text = "Bai 00: Show Size";

            // --- QUAN TRỌNG: Đăng ký các sự kiện tại đây ---
            this.Load += new System.EventHandler(this.Bai00_Load);
            this.Resize += new System.EventHandler(this.Bai00_Resize);
            // -----------------------------------------------

            this.ResumeLayout(false);
        }
    }
}