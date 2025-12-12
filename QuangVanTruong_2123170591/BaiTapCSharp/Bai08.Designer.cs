namespace WinFormsApp_Article
{
    partial class Bai08
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label lbInstruction;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbYear = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.lbInstruction = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Location = new System.Drawing.Point(30, 40);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(32, 15);
            this.lbYear.Text = "Year:";

            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(80, 37);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(150, 23);

            // 
            // lbInstruction
            // 
            this.lbInstruction.AutoSize = true;
            this.lbInstruction.ForeColor = System.Drawing.Color.Red;
            this.lbInstruction.Location = new System.Drawing.Point(80, 65);
            this.lbInstruction.Name = "lbInstruction";
            this.lbInstruction.Size = new System.Drawing.Size(160, 15);
            this.lbInstruction.Text = "(Must be <= 2000 to validate)";

            // 
            // Bai08 Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.lbInstruction);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.lbYear);
            this.Name = "Bai08";
            this.Text = "Bai 08: Validating";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}