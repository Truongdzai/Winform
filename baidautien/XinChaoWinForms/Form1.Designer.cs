namespace Example01
{
    partial class Form1
    {
        /// <summary>
        ///  Biến chứa các thành phần (components) của Form.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Hàm dọn dẹp tài nguyên khi tắt Form (Dispose).
        /// </summary>
        /// <param name="disposing">true nếu muốn giải phóng cả code lẫn giao diện.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Hàm này KHỞI TẠO giao diện. 
        ///  Khi em kéo thả nút bấm, code sẽ tự động chui vào đây.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 450);
            Name = "Form1";
            Text = "Calculator";
            ResumeLayout(false);
        }

        #endregion
    }
}