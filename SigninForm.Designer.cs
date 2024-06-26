namespace Library_management_system
{
    partial class SigninForm
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
            Mailbox = new TextBox();
            Mailboxlabel = new Label();
            PassWord = new TextBox();
            UserName = new TextBox();
            Pass_Wordlabel = new Label();
            User_Namelabel = new Label();
            Sign_inButton = new Button();
            SuspendLayout();
            // 
            // Mailbox
            // 
            Mailbox.Font = new Font("Microsoft YaHei UI", 14F);
            Mailbox.Location = new Point(192, 53);
            Mailbox.MaxLength = 20;
            Mailbox.Name = "Mailbox";
            Mailbox.Size = new Size(336, 43);
            Mailbox.TabIndex = 1;
            Mailbox.TextChanged += Text_changed;
            // 
            // Mailboxlabel
            // 
            Mailboxlabel.AutoSize = true;
            Mailboxlabel.Font = new Font("Microsoft YaHei UI", 14F);
            Mailboxlabel.Location = new Point(65, 53);
            Mailboxlabel.Name = "Mailboxlabel";
            Mailboxlabel.Size = new Size(95, 36);
            Mailboxlabel.TabIndex = 14;
            Mailboxlabel.Text = "邮   箱";
            // 
            // PassWord
            // 
            PassWord.Font = new Font("Microsoft YaHei UI", 14F);
            PassWord.Location = new Point(192, 253);
            PassWord.MaxLength = 16;
            PassWord.Name = "PassWord";
            PassWord.PasswordChar = '*';
            PassWord.Size = new Size(336, 43);
            PassWord.TabIndex = 3;
            PassWord.TextChanged += Text_changed;
            // 
            // UserName
            // 
            UserName.Font = new Font("Microsoft YaHei UI", 14F);
            UserName.Location = new Point(192, 154);
            UserName.MaxLength = 20;
            UserName.Name = "UserName";
            UserName.Size = new Size(336, 43);
            UserName.TabIndex = 2;
            UserName.TextChanged += Text_changed;
            // 
            // Pass_Wordlabel
            // 
            Pass_Wordlabel.AutoSize = true;
            Pass_Wordlabel.Font = new Font("Microsoft YaHei UI", 14F);
            Pass_Wordlabel.Location = new Point(65, 256);
            Pass_Wordlabel.Name = "Pass_Wordlabel";
            Pass_Wordlabel.Size = new Size(95, 36);
            Pass_Wordlabel.TabIndex = 11;
            Pass_Wordlabel.Text = "密   码";
            // 
            // User_Namelabel
            // 
            User_Namelabel.AutoSize = true;
            User_Namelabel.Font = new Font("Microsoft YaHei UI", 14F);
            User_Namelabel.Location = new Point(65, 157);
            User_Namelabel.Name = "User_Namelabel";
            User_Namelabel.Size = new Size(99, 36);
            User_Namelabel.TabIndex = 10;
            User_Namelabel.Text = "用户名";
            // 
            // Sign_inButton
            // 
            Sign_inButton.Font = new Font("Microsoft YaHei UI", 14F);
            Sign_inButton.Location = new Point(220, 352);
            Sign_inButton.Name = "Sign_inButton";
            Sign_inButton.Size = new Size(138, 52);
            Sign_inButton.TabIndex = 16;
            Sign_inButton.TabStop = false;
            Sign_inButton.Text = "注册";
            Sign_inButton.UseVisualStyleBackColor = true;
            Sign_inButton.Click += Sign_inButton_Click;
            // 
            // SigninForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 432);
            Controls.Add(Sign_inButton);
            Controls.Add(Mailbox);
            Controls.Add(Mailboxlabel);
            Controls.Add(PassWord);
            Controls.Add(UserName);
            Controls.Add(Pass_Wordlabel);
            Controls.Add(User_Namelabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SigninForm";
            Text = "SigninForm";
            KeyUp += SigninForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Mailbox;
        private Label Mailboxlabel;
        private TextBox PassWord;
        private TextBox UserName;
        private Label Pass_Wordlabel;
        private Label User_Namelabel;
        private Button Sign_inButton;
    }
}