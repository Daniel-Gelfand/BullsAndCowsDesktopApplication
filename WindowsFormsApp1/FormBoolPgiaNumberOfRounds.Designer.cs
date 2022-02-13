namespace GuiBoolPgia
{
    public partial class FormBoolPgiaNumberOfRounds
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonNumberOfRounds = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonStart.Location = new System.Drawing.Point(205, 88);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonNumberOfRounds
            // 
            this.buttonNumberOfRounds.BackColor = System.Drawing.Color.Transparent;
            this.buttonNumberOfRounds.Location = new System.Drawing.Point(12, 27);
            this.buttonNumberOfRounds.Name = "buttonNumberOfRounds";
            this.buttonNumberOfRounds.Size = new System.Drawing.Size(268, 38);
            this.buttonNumberOfRounds.TabIndex = 1;
            this.buttonNumberOfRounds.Text = "Number of chances: 4";
            this.buttonNumberOfRounds.UseVisualStyleBackColor = false;
            this.buttonNumberOfRounds.Click += new System.EventHandler(this.buttonNumberOfRounds_Click);
            // 
            // FormBoolPgiaNumberOfRounds
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 143);
            this.Controls.Add(this.buttonNumberOfRounds);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormBoolPgiaNumberOfRounds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonNumberOfRounds;
    }
}