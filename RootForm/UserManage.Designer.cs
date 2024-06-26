namespace Library_management_system.RootForm
{
    partial class UserManage
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
            Result = new ListView();
            Mailbox = new ColumnHeader();
            Username = new ColumnHeader();
            Last_Login = new ColumnHeader();
            Page = new Label();
            DownPage = new Button();
            UpPage = new Button();
            SelectUsernameBox = new TextBox();
            SelectButton = new Button();
            Refresh = new Button();
            SingOutButton = new Button();
            SuspendLayout();
            // 
            // Result
            // 
            Result.Columns.AddRange(new ColumnHeader[] { Mailbox, Username, Last_Login });
            Result.Font = new Font("Microsoft YaHei UI", 14F);
            Result.Location = new Point(12, 12);
            Result.Name = "Result";
            Result.Scrollable = false;
            Result.Size = new Size(984, 605);
            Result.TabIndex = 3;
            Result.UseCompatibleStateImageBehavior = false;
            Result.View = View.Details;
            // 
            // Mailbox
            // 
            Mailbox.Text = "邮箱";
            Mailbox.Width = 384;
            // 
            // Username
            // 
            Username.Text = "用户名";
            Username.Width = 254;
            // 
            // Last_Login
            // 
            Last_Login.Text = "最后登录时间";
            Last_Login.Width = 344;
            // 
            // Page
            // 
            Page.Font = new Font("Microsoft YaHei UI", 16F);
            Page.Location = new Point(449, 620);
            Page.Name = "Page";
            Page.Size = new Size(68, 55);
            Page.TabIndex = 11;
            Page.Text = "1";
            Page.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DownPage
            // 
            DownPage.Font = new Font("Microsoft Sans Serif", 16F);
            DownPage.Location = new Point(596, 620);
            DownPage.Name = "DownPage";
            DownPage.Size = new Size(58, 55);
            DownPage.TabIndex = 10;
            DownPage.Text = ">";
            DownPage.UseVisualStyleBackColor = true;
            DownPage.Click += DownPage_Click;
            // 
            // UpPage
            // 
            UpPage.Font = new Font("Microsoft Sans Serif", 16F);
            UpPage.Location = new Point(283, 620);
            UpPage.Name = "UpPage";
            UpPage.Size = new Size(58, 55);
            UpPage.TabIndex = 9;
            UpPage.Text = "<";
            UpPage.UseVisualStyleBackColor = true;
            UpPage.Click += UpPage_Click;
            // 
            // SelectUsernameBox
            // 
            SelectUsernameBox.Font = new Font("Microsoft YaHei UI", 13F);
            SelectUsernameBox.Location = new Point(1002, 72);
            SelectUsernameBox.Name = "SelectUsernameBox";
            SelectUsernameBox.Size = new Size(206, 41);
            SelectUsernameBox.TabIndex = 12;
            // 
            // SelectButton
            // 
            SelectButton.Font = new Font("Microsoft YaHei UI", 12F);
            SelectButton.Location = new Point(1031, 119);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(152, 68);
            SelectButton.TabIndex = 13;
            SelectButton.Text = "搜索";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(1047, 583);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(112, 34);
            Refresh.TabIndex = 14;
            Refresh.Text = "刷新(F5)";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            Refresh.KeyUp += Refresh_KeyUp;
            // 
            // SingOutButton
            // 
            SingOutButton.Font = new Font("Microsoft YaHei UI", 12F);
            SingOutButton.Location = new Point(1031, 315);
            SingOutButton.Name = "SingOutButton";
            SingOutButton.Size = new Size(152, 68);
            SingOutButton.TabIndex = 15;
            SingOutButton.Text = "注销此帐号";
            SingOutButton.UseVisualStyleBackColor = true;
            SingOutButton.Click += SingOutButton_Click;
            // 
            // UserManage
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 696);
            Controls.Add(SingOutButton);
            Controls.Add(Refresh);
            Controls.Add(SelectButton);
            Controls.Add(SelectUsernameBox);
            Controls.Add(Page);
            Controls.Add(DownPage);
            Controls.Add(UpPage);
            Controls.Add(Result);
            KeyPreview = true;
            Name = "UserManage";
            Text = "用户管理";
            Load += UserManage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView Result;
        private ColumnHeader Mailbox;
        private ColumnHeader Username;
        private ColumnHeader Last_Login;
        private Label Page;
        private Button DownPage;
        private Button UpPage;
        private TextBox SelectUsernameBox;
        private Button SelectButton;
        private Button Refresh;
        private Button SingOutButton;
    }
}