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
            User_Namelabel = new Label();
            Pass_Wordlabel = new Label();
            UserName = new TextBox();
            PassWord = new TextBox();
            LoginButton = new Button();
            Sign_inButton = new Button();
            SuspendLayout();
            // 
            // User_Namelabel
            // 
            User_Namelabel.AutoSize = true;
            User_Namelabel.Font = new Font("Microsoft YaHei UI", 14F);
            User_Namelabel.Location = new Point(128, 101);
            User_Namelabel.Name = "User_Namelabel";
            User_Namelabel.Size = new Size(99, 36);
            User_Namelabel.TabIndex = 0;
            User_Namelabel.Text = "用户名";
            // 
            // Pass_Wordlabel
            // 
            Pass_Wordlabel.AutoSize = true;
            Pass_Wordlabel.Font = new Font("Microsoft YaHei UI", 14F);
            Pass_Wordlabel.Location = new Point(128, 200);
            Pass_Wordlabel.Name = "Pass_Wordlabel";
            Pass_Wordlabel.Size = new Size(95, 36);
            Pass_Wordlabel.TabIndex = 1;
            Pass_Wordlabel.Text = "密   码";
            // 
            // UserName
            // 
            UserName.Font = new Font("Microsoft YaHei UI", 14F);
            UserName.Location = new Point(255, 98);
            UserName.MaxLength = 20;
            UserName.Name = "UserName";
            UserName.Size = new Size(294, 43);
            UserName.TabIndex = 2;
            UserName.TextChanged += Text_changed;
            // 
            // PassWord
            // 
            PassWord.Font = new Font("Microsoft YaHei UI", 14F);
            PassWord.Location = new Point(255, 197);
            PassWord.MaxLength = 16;
            PassWord.Name = "PassWord";
            PassWord.PasswordChar = '*';
            PassWord.Size = new Size(294, 43);
            PassWord.TabIndex = 3;
            PassWord.TextChanged += Text_changed;
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
            LoginButton.Click += LoginButton_Click;
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
            Sign_inButton.Click += Sign_inButton_Click;
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
            Controls.Add(Pass_Wordlabel);
            Controls.Add(User_Namelabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "图书馆管理系统";
            KeyUp += LoginForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label User_Namelabel;
        private Label Pass_Wordlabel;
        private TextBox UserName;
        private TextBox PassWord;
        private Button LoginButton;
        private Button Sign_inButton;
    }
}
