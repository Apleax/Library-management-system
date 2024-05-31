namespace Library_management_system
{
    partial class LoginForm
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
            UserName = new TextBox();
            PassWord = new TextBox();
            LoginButton = new Button();
            Sign_inButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14F);
            label1.Location = new Point(128, 101);
            label1.Name = "label1";
            label1.Size = new Size(99, 36);
            label1.TabIndex = 0;
            label1.Text = "用户名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14F);
            label2.Location = new Point(128, 200);
            label2.Name = "label2";
            label2.Size = new Size(95, 36);
            label2.TabIndex = 1;
            label2.Text = "密   码";
            // 
            // UserName
            // 
            UserName.Font = new Font("Microsoft YaHei UI", 14F);
            UserName.Location = new Point(255, 98);
            UserName.MaxLength = 12;
            UserName.Name = "UserName";
            UserName.Size = new Size(294, 43);
            UserName.TabIndex = 2;
            // 
            // PassWord
            // 
            PassWord.Font = new Font("Microsoft YaHei UI", 14F);
            PassWord.Location = new Point(255, 197);
            PassWord.MaxLength = 8;
            PassWord.Name = "PassWord";
            PassWord.PasswordChar = '*';
            PassWord.Size = new Size(294, 43);
            PassWord.TabIndex = 3;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Microsoft YaHei UI", 14F);
            LoginButton.Location = new Point(128, 312);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(138, 52);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "登录";
            LoginButton.UseVisualStyleBackColor = true;
            // 
            // Sign_inButton
            // 
            Sign_inButton.Font = new Font("Microsoft YaHei UI", 14F);
            Sign_inButton.Location = new Point(411, 312);
            Sign_inButton.Name = "Sign_inButton";
            Sign_inButton.Size = new Size(138, 52);
            Sign_inButton.TabIndex = 5;
            Sign_inButton.Text = "注册";
            Sign_inButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 454);
            Controls.Add(Sign_inButton);
            Controls.Add(LoginButton);
            Controls.Add(PassWord);
            Controls.Add(UserName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "图书馆管理系统";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox UserName;
        private TextBox PassWord;
        private Button LoginButton;
        private Button Sign_inButton;
    }
}
