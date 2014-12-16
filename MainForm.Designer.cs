namespace ezHashCheck
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FindFileButton = new System.Windows.Forms.Button();
            this.HashMethodsComboBox = new System.Windows.Forms.ComboBox();
            this.HashStringTextBox = new System.Windows.Forms.TextBox();
            this.FileToHashTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckHashButton = new System.Windows.Forms.Button();
            this.GenerateHashButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FindFileButton
            // 
            this.FindFileButton.Location = new System.Drawing.Point(305, 96);
            this.FindFileButton.Name = "FindFileButton";
            this.FindFileButton.Size = new System.Drawing.Size(75, 23);
            this.FindFileButton.TabIndex = 2;
            this.FindFileButton.Text = "...";
            this.FindFileButton.UseVisualStyleBackColor = true;
            this.FindFileButton.Click += new System.EventHandler(this.FindFileButton_Click);
            // 
            // HashMethodsComboBox
            // 
            this.HashMethodsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HashMethodsComboBox.FormattingEnabled = true;
            this.HashMethodsComboBox.Location = new System.Drawing.Point(12, 46);
            this.HashMethodsComboBox.Name = "HashMethodsComboBox";
            this.HashMethodsComboBox.Size = new System.Drawing.Size(121, 21);
            this.HashMethodsComboBox.TabIndex = 0;
            // 
            // HashStringTextBox
            // 
            this.HashStringTextBox.Location = new System.Drawing.Point(12, 144);
            this.HashStringTextBox.Name = "HashStringTextBox";
            this.HashStringTextBox.Size = new System.Drawing.Size(287, 20);
            this.HashStringTextBox.TabIndex = 3;
            // 
            // FileToHashTextBox
            // 
            this.FileToHashTextBox.Location = new System.Drawing.Point(12, 96);
            this.FileToHashTextBox.Name = "FileToHashTextBox";
            this.FileToHashTextBox.Size = new System.Drawing.Size(287, 20);
            this.FileToHashTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hash Method:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hash String:";
            // 
            // CheckHashButton
            // 
            this.CheckHashButton.Location = new System.Drawing.Point(12, 201);
            this.CheckHashButton.Name = "CheckHashButton";
            this.CheckHashButton.Size = new System.Drawing.Size(167, 39);
            this.CheckHashButton.TabIndex = 4;
            this.CheckHashButton.Text = "Check Hash";
            this.CheckHashButton.UseVisualStyleBackColor = true;
            this.CheckHashButton.Click += new System.EventHandler(this.CheckHashButton_Click);
            // 
            // GenerateHashButton
            // 
            this.GenerateHashButton.Location = new System.Drawing.Point(213, 201);
            this.GenerateHashButton.Name = "GenerateHashButton";
            this.GenerateHashButton.Size = new System.Drawing.Size(167, 39);
            this.GenerateHashButton.TabIndex = 5;
            this.GenerateHashButton.Text = "Generate Hash";
            this.GenerateHashButton.UseVisualStyleBackColor = true;
            this.GenerateHashButton.Click += new System.EventHandler(this.GenerateHashButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 261);
            this.Controls.Add(this.GenerateHashButton);
            this.Controls.Add(this.CheckHashButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileToHashTextBox);
            this.Controls.Add(this.HashStringTextBox);
            this.Controls.Add(this.HashMethodsComboBox);
            this.Controls.Add(this.FindFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ezHashCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FindFileButton;
        private System.Windows.Forms.ComboBox HashMethodsComboBox;
        private System.Windows.Forms.TextBox HashStringTextBox;
        private System.Windows.Forms.TextBox FileToHashTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CheckHashButton;
        private System.Windows.Forms.Button GenerateHashButton;
    }
}

