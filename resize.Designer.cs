namespace ImagePro
{
    partial class resize
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
            this.Okay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.height_text = new System.Windows.Forms.TextBox();
            this.width_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Okay
            // 
            this.Okay.Location = new System.Drawing.Point(104, 76);
            this.Okay.Name = "Okay";
            this.Okay.Size = new System.Drawing.Size(100, 23);
            this.Okay.TabIndex = 0;
            this.Okay.Text = "button1";
            this.Okay.UseVisualStyleBackColor = true;
            this.Okay.Click += new System.EventHandler(this.Okay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Height";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // height_text
            // 
            this.height_text.Location = new System.Drawing.Point(104, 15);
            this.height_text.Name = "height_text";
            this.height_text.Size = new System.Drawing.Size(100, 20);
            this.height_text.TabIndex = 3;
            // 
            // width_text
            // 
            this.width_text.Location = new System.Drawing.Point(104, 50);
            this.width_text.Name = "width_text";
            this.width_text.Size = new System.Drawing.Size(100, 20);
            this.width_text.TabIndex = 4;
            // 
            // resize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 111);
            this.Controls.Add(this.width_text);
            this.Controls.Add(this.height_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Okay);
            this.Name = "resize";
            this.Text = "Prompt";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Okay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox height_text;
        private System.Windows.Forms.TextBox width_text;
    }
}