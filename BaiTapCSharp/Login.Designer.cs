namespace WinFormsApp_Article
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Tên thí sinh:";
            // tbName
            this.tbName.Location = new System.Drawing.Point(160, 47);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 27);
            // btLogin
            this.btLogin.Location = new System.Drawing.Point(160, 100);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(120, 40);
            this.btLogin.Text = "Tiếp tục";
            this.btLogin.UseVisualStyleBackColor = true;
            // Login
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        // QUAN TRỌNG: Để là Public để Form1 nhìn thấy
        public System.Windows.Forms.Button btLogin;
    }
}