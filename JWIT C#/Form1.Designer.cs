namespace JWIT_C_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPwd = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(53, 45);
            label1.Name = "label1";
            label1.Size = new Size(362, 38);
            label1.TabIndex = 0;
            label1.Text = "Welcome to JWIT Connect";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 97);
            label2.Name = "label2";
            label2.Size = new Size(201, 25);
            label2.TabIndex = 1;
            label2.Text = "Please login to continue";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 282);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 182);
            label4.Name = "label4";
            label4.Size = new Size(91, 25);
            label4.TabIndex = 3;
            label4.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.AccessibleRole = AccessibleRole.None;
            btnLogin.BackColor = SystemColors.ActiveCaption;
            btnLogin.Location = new Point(53, 420);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(362, 62);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login ";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(53, 228);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(362, 31);
            txtUsername.TabIndex = 5;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(53, 328);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(362, 31);
            txtPwd.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 522);
            Controls.Add(txtPwd);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "JWIT Connect";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPwd;
    }
}
