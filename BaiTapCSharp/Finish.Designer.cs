namespace WinFormsApp_Article
{
    partial class Finish
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(80, 80);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(300, 30);
            this.lblResult.Text = "Chúc mừng! Bạn đã hoàn thành.";
            // btExit
            this.btExit.Location = new System.Drawing.Point(180, 150);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(120, 40);
            this.btExit.Text = "Thoát";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // Finish
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.lblResult);
            this.Name = "Finish";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblResult;
        public System.Windows.Forms.Button btExit;
    }
}