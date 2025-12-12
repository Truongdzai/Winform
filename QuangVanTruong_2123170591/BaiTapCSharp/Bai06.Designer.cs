namespace WinFormsApp_Article
{
    partial class Bai06
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button bt_OK; // Khai báo nút

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.bt_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // bt_OK
            // 
            this.bt_OK.Text = "OK";
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(90, 35);
            // Đặt vị trí ban đầu gần góc phải dưới
            this.bt_OK.Location = new System.Drawing.Point(280, 200);

            // --- CẤU HÌNH ANCHOR (NEO) ---
            // Neo vào Bên Dưới (Bottom) và Bên Phải (Right)
            this.bt_OK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.bt_OK.UseVisualStyleBackColor = true;

            // 
            // Bai06 Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 260); // Form chữ nhật
            this.Controls.Add(this.bt_OK); // Thêm nút vào Form
            this.Name = "Bai06";
            this.Text = "Bai 06: Button Anchor";
            this.ResumeLayout(false);
        }
    }
}