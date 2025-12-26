namespace WinFormsApp_Article
{
    partial class Question
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.btPrev = new System.Windows.Forms.Button();
            this.btFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // lblQuestion
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(40, 30);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(300, 30);
            this.lblQuestion.Text = "1 + 1 bằng mấy?";
            // rbA
            this.rbA.AutoSize = true;
            this.rbA.Location = new System.Drawing.Point(60, 80);
            this.rbA.Name = "rbA";
            this.rbA.Text = "Hai";
            // rbB
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(60, 110);
            this.rbB.Name = "rbB";
            this.rbB.Text = "Ba";
            // btPrev
            this.btPrev.Location = new System.Drawing.Point(150, 200);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(100, 40);
            this.btPrev.Text = "Quay lại";
            // btFinish
            this.btFinish.Location = new System.Drawing.Point(270, 200);
            this.btFinish.Name = "btFinish";
            this.btFinish.Size = new System.Drawing.Size(100, 40);
            this.btFinish.Text = "Nộp bài";
            // Question
            this.Controls.Add(this.btFinish);
            this.Controls.Add(this.btPrev);
            this.Controls.Add(this.rbB);
            this.Controls.Add(this.rbA);
            this.Controls.Add(this.lblQuestion);
            this.Name = "Question";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.RadioButton rbB;
        // QUAN TRỌNG: Public Buttons
        public System.Windows.Forms.Button btPrev;
        public System.Windows.Forms.Button btFinish;
    }
}