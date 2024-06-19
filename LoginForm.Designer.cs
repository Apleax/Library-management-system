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
            Mailboxlabel = new Label();
            Mailbox = new TextBox();
            SuspendLayout();
            // 
            // User_Namelabel
            // 
            User_Namelabel.AutoSize = true;
            User_Namelabel.Font = new Font("Microsoft YaHei UI", 14F);
            User_Namelabel.Location = new Point(109, 180);
            User_Namelabel.Name = "User_Namelabel";
            User_Namelabel.Size = new Size(99, 36);
            User_Namelabel.TabIndex = 0;
            User_Namelabel.Text = "用户名";
            // 
            // Pass_Wordlabel
            // 
            Pass_Wordlabel.AutoSize = true;
            Pass_Wordlabel.Font = new Font("Microsoft YaHei UI", 14F);
            Pass_Wordlabel.Location = new Point(109, 279);
            Pass_Wordlabel.Name = "Pass_Wordlabel";
            Pass_Wordlabel.Size = new Size(95, 36);
            Pass_Wordlabel.TabIndex = 1;
            Pass_Wordlabel.Text = "密   码";
            // 
            // UserName
            // 
            UserName.Font = new Font("Microsoft YaHei UI", 14F);
            UserName.Location = new Point(236, 177);
            UserName.MaxLength = 20;
            UserName.Name = "UserName";
            UserName.Size = new Size(336, 43);
            UserName.TabIndex = 2;
            UserName.TextChanged += Text_changed;
            // 
            // PassWord
            // 
            PassWord.Font = new Font("Microsoft YaHei UI", 14F);
            PassWord.Location = new Point(236, 276);
            PassWord.MaxLength = 16;
            PassWord.Name = "PassWord";
            PassWord.PasswordChar = '*';
            PassWord.Size = new Size(336, 43);
            PassWord.TabIndex = 3;
            PassWord.TextChanged += Text_changed;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Microsoft YaHei UI", 14F);
            LoginButton.Location = new Point(126, 422);
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
            Sign_inButton.Location = new Point(409, 422);
            Sign_inButton.Name = "Sign_inButton";
            Sign_inButton.Size = new Size(138, 52);
            Sign_inButton.TabIndex = 5;
            Sign_inButton.Text = "注册";
            Sign_inButton.UseVisualStyleBackColor = true;
            Sign_inButton.Click += Sign_inButton_Click;
            // 
            // ChangePassWord
            // 
            ChangePassWord.Location = new Point(451, 370);
            ChangePassWord.Name = "ChangePassWord";
            ChangePassWord.Size = new Size(96, 34);
            ChangePassWord.TabIndex = 6;
            ChangePassWord.Text = "修改密码";
            ChangePassWord.UseVisualStyleBackColor = true;
            ChangePassWord.Click += ChangePassWord_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(327, 375);
            label1.Name = "label1";
            label1.Size = new Size(104, 24);
            label1.TabIndex = 7;
            label1.Text = "忘记密码？:";
            // 
            // Mailboxlabel
            // 
            Mailboxlabel.AutoSize = true;
            Mailboxlabel.Font = new Font("Microsoft YaHei UI", 14F);
            Mailboxlabel.Location = new Point(109, 76);
            Mailboxlabel.Name = "Mailboxlabel";
            Mailboxlabel.Size = new Size(95, 36);
            Mailboxlabel.TabIndex = 8;
            Mailboxlabel.Text = "邮   箱";
            // 
            // Mailbox
            // 
            Mailbox.Font = new Font("Microsoft YaHei UI", 14F);
            Mailbox.Location = new Point(236, 76);
            Mailbox.MaxLength = 20;
            Mailbox.Name = "Mailbox";
            Mailbox.Size = new Size(336, 43);
            Mailbox.TabIndex = 9;
            Mailbox.TextChanged += Text_changed;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 525);
            Controls.Add(Mailbox);
            Controls.Add(Mailboxlabel);
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
        private Label Mailboxlabel;
        private TextBox Mailbox;
    }
}
