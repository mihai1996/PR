namespace MailClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.Recipient = new System.Windows.Forms.Label();
            this.recipientTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bodyTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.receiveTextBox = new System.Windows.Forms.RichTextBox();
            this.receiveButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(98, 32);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(189, 22);
            this.emailTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(98, 72);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(189, 22);
            this.passwordTextBox.TabIndex = 3;
            // 
            // Recipient
            // 
            this.Recipient.AutoSize = true;
            this.Recipient.Location = new System.Drawing.Point(13, 141);
            this.Recipient.Name = "Recipient";
            this.Recipient.Size = new System.Drawing.Size(67, 17);
            this.Recipient.TabIndex = 4;
            this.Recipient.Text = "Recipient";
            // 
            // recipientTextBox
            // 
            this.recipientTextBox.Location = new System.Drawing.Point(98, 138);
            this.recipientTextBox.Name = "recipientTextBox";
            this.recipientTextBox.Size = new System.Drawing.Size(189, 22);
            this.recipientTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subject";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(98, 179);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(189, 22);
            this.subjectTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Body";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(33, 261);
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(254, 149);
            this.bodyTextBox.TabIndex = 9;
            this.bodyTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Receive";
            // 
            // receiveTextBox
            // 
            this.receiveTextBox.Location = new System.Drawing.Point(313, 39);
            this.receiveTextBox.Name = "receiveTextBox";
            this.receiveTextBox.Size = new System.Drawing.Size(306, 371);
            this.receiveTextBox.TabIndex = 11;
            this.receiveTextBox.Text = "";
            // 
            // receiveButton
            // 
            this.receiveButton.Location = new System.Drawing.Point(434, 429);
            this.receiveButton.Name = "receiveButton";
            this.receiveButton.Size = new System.Drawing.Size(75, 23);
            this.receiveButton.TabIndex = 12;
            this.receiveButton.Text = "Receive";
            this.receiveButton.UseVisualStyleBackColor = true;
            this.receiveButton.Click += new System.EventHandler(this.receiveButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(126, 429);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 13;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 474);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.receiveButton);
            this.Controls.Add(this.receiveTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.recipientTextBox);
            this.Controls.Add(this.Recipient);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label Recipient;
        private System.Windows.Forms.TextBox recipientTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox bodyTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox receiveTextBox;
        private System.Windows.Forms.Button receiveButton;
        private System.Windows.Forms.Button sendButton;
    }
}

