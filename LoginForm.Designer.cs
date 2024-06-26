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
            ChangePassWord = new Button();
            label1 = new Label();
            Tag = new Label();
            SuspendLayout();
            // 
            // User_Namelabel
            // 
            User_Namelabel.AutoSize = true;
            User_Namelabel.Font = new Font("Microsoft YaHei UI", 14F);
            User_Namelabel.Location = new Point(112, 71);
            User_Namelabel.Name = "User_Namelabel";
            User_Namelabel.Size = new Size(99, 36);
            User_Namelabel.TabIndex = 0;
            User_Namelabel.Text = "用户名";
            // 
            // Pass_Wordlabel
            // 
            Pass_Wordlabel.AutoSize = true;
            Pass_Wordlabel.Font = new Font("Microsoft YaHei UI", 14F);
            Pass_Wordlabel.Location = new Point(112, 170);
            Pass_Wordlabel.Name = "Pass_Wordlabel";
            Pass_Wordlabel.Size = new Size(95, 36);
            Pass_Wordlabel.TabIndex = 1;
            Pass_Wordlabel.Text = "密   码";
            // 
            // UserName
            // 
            UserName.Font = new Font("Microsoft YaHei UI", 14F);
            UserName.Location = new Point(239, 68);
            UserName.MaxLength = 20;
            UserName.Name = "UserName";
            UserName.Size = new Size(336, 43);
            UserName.TabIndex = 2;
            UserName.TextChanged += Text_changed;
            // 
            // PassWord
            // 
            PassWord.Font = new Font("Microsoft YaHei UI", 14F);
            PassWord.Location = new Point(239, 167);
            PassWord.MaxLength = 16;
            PassWord.Name = "PassWord";
            PassWord.PasswordChar = '*';
            PassWord.Size = new Size(336, 43);
            PassWord.TabIndex = 3;
            PassWord.TextChanged += Text_changed;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Microsoft YaHei UI", 16F);
            LoginButton.Location = new Point(156, 313);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(237, 72);
            LoginButton.TabIndex = 4;
            LoginButton.TabStop = false;
            LoginButton.Text = "登录";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // Sign_inButton
            // 
            Sign_inButton.FlatStyle = FlatStyle.Popup;
            Sign_inButton.Font = new Font("Microsoft YaHei UI", 9F);
            Sign_inButton.Location = new Point(541, 335);
            Sign_inButton.Name = "Sign_inButton";
            Sign_inButton.Size = new Size(76, 40);
            Sign_inButton.TabIndex = 5;
            Sign_inButton.TabStop = false;
            Sign_inButton.Text = "注册";
            Sign_inButton.UseVisualStyleBackColor = true;
            Sign_inButton.Click += Sign_inButton_Click;
            // 
            // ChangePassWord
            // 
            ChangePassWord.Location = new Point(454, 261);
            ChangePassWord.Name = "ChangePassWord";
            ChangePassWord.Size = new Size(96, 34);
            ChangePassWord.TabIndex = 6;
            ChangePassWord.TabStop = false;
            ChangePassWord.Text = "修改密码";
            ChangePassWord.UseVisualStyleBackColor = true;
            ChangePassWord.Click += ChangePassWord_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(330, 266);
            label1.Name = "label1";
            label1.Size = new Size(104, 24);
            label1.TabIndex = 7;
            label1.Text = "忘记密码？:";
            // 
            // Tag
            // 
            Tag.AutoSize = true;
            Tag.Location = new Point(399, 343);
            Tag.Name = "Tag";
            Tag.Size = new Size(136, 24);
            Tag.TabIndex = 8;
            Tag.Text = "没有帐号？立即";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 425);
            Controls.Add(Tag);
            Controls.Add(label1);
            Controls.Add(ChangePassWord);
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
        private Button ChangePassWord;
        private Label label1;
        private Label Tag;
    }
}
