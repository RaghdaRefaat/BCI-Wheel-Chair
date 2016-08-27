namespace BCI_Project
{
    partial class Form1
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
            this.btnDataBrowsing = new System.Windows.Forms.Button();
            this.btnTriggFile = new System.Windows.Forms.Button();
            this.btnClassLabelsFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccuracy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDataBrowsing
            // 
            this.btnDataBrowsing.Location = new System.Drawing.Point(141, 17);
            this.btnDataBrowsing.Name = "btnDataBrowsing";
            this.btnDataBrowsing.Size = new System.Drawing.Size(137, 45);
            this.btnDataBrowsing.TabIndex = 0;
            this.btnDataBrowsing.Text = "Browse Data File";
            this.btnDataBrowsing.UseVisualStyleBackColor = true;
            this.btnDataBrowsing.Click += new System.EventHandler(this.btnDataBrowsing_Click);
            // 
            // btnTriggFile
            // 
            this.btnTriggFile.Location = new System.Drawing.Point(141, 118);
            this.btnTriggFile.Name = "btnTriggFile";
            this.btnTriggFile.Size = new System.Drawing.Size(137, 47);
            this.btnTriggFile.TabIndex = 1;
            this.btnTriggFile.Text = "Browse Trigg File";
            this.btnTriggFile.UseVisualStyleBackColor = true;
            this.btnTriggFile.Click += new System.EventHandler(this.btnTriggFile_Click);
            // 
            // btnClassLabelsFile
            // 
            this.btnClassLabelsFile.Location = new System.Drawing.Point(141, 223);
            this.btnClassLabelsFile.Name = "btnClassLabelsFile";
            this.btnClassLabelsFile.Size = new System.Drawing.Size(137, 47);
            this.btnClassLabelsFile.TabIndex = 2;
            this.btnClassLabelsFile.Text = "Browse Class Labels File";
            this.btnClassLabelsFile.UseVisualStyleBackColor = true;
            this.btnClassLabelsFile.Click += new System.EventHandler(this.btnClassLabelsFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "First Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Third Step";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(22, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Second Step";
            // 
            // txtAccuracy
            // 
            this.txtAccuracy.Location = new System.Drawing.Point(141, 327);
            this.txtAccuracy.Name = "txtAccuracy";
            this.txtAccuracy.Size = new System.Drawing.Size(137, 20);
            this.txtAccuracy.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(26, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "The Accuracy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 423);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccuracy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClassLabelsFile);
            this.Controls.Add(this.btnTriggFile);
            this.Controls.Add(this.btnDataBrowsing);
            this.Name = "Form1";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDataBrowsing;
        private System.Windows.Forms.Button btnTriggFile;
        private System.Windows.Forms.Button btnClassLabelsFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccuracy;
        private System.Windows.Forms.Label label4;
    }
}

