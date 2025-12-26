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
            bt_OK = new Button();
            SuspendLayout();
            // 
            // bt_OK
            // 
            bt_OK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_OK.Location = new Point(303, 249);
            bt_OK.Margin = new Padding(3, 4, 3, 4);
            bt_OK.Name = "bt_OK";
            bt_OK.Size = new Size(103, 47);
            bt_OK.TabIndex = 0;
            bt_OK.Text = "OK";
            bt_OK.UseVisualStyleBackColor = true;
            // 
            // Bai06
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 347);
            Controls.Add(bt_OK);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Bai06";
            Text = "Bai 06: Button Anchor";
            ResumeLayout(false);
        }
    }
}