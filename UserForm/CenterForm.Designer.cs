namespace Library_management_system.UserForm
{
    partial class CenterForm
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
            Borrow_List = new ListView();
            Bookname = new ColumnHeader();
            Author = new ColumnHeader();
            nickname = new Label();
            NicknameBox = new TextBox();
            ReturnButton = new Button();
            OK = new Button();
            SuspendLayout();
            // 
            // Borrow_List
            // 
            Borrow_List.Columns.AddRange(new ColumnHeader[] { Bookname, Author });
            Borrow_List.Font = new Font("Microsoft YaHei UI", 14F);
            Borrow_List.Location = new Point(12, 12);
            Borrow_List.Name = "Borrow_List";
            Borrow_List.Scrollable = false;
            Borrow_List.Size = new Size(637, 605);
            Borrow_List.TabIndex = 19;
            Borrow_List.UseCompatibleStateImageBehavior = false;
            Borrow_List.View = View.Details;
            // 
            // Bookname
            // 
            Bookname.Text = "书名";
            Bookname.Width = 387;
            // 
            // Author
            // 
            Author.Text = "作者";
            Author.Width = 250;
            // 
            // nickname
            // 
            nickname.AutoSize = true;
            nickname.Font = new Font("Microsoft YaHei UI", 14F);
            nickname.Location = new Point(655, 12);
            nickname.Name = "nickname";
            nickname.Size = new Size(78, 36);
            nickname.TabIndex = 23;
            nickname.Text = "昵称:";
            // 
            // NicknameBox
            // 
            NicknameBox.Font = new Font("Microsoft YaHei UI", 16F);
            NicknameBox.Location = new Point(655, 51);
            NicknameBox.Name = "NicknameBox";
            NicknameBox.Size = new Size(199, 48);
            NicknameBox.TabIndex = 24;
            // 
            // ReturnButton
            // 
            ReturnButton.Font = new Font("Microsoft YaHei UI", 12F);
            ReturnButton.Location = new Point(680, 147);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(152, 68);
            ReturnButton.TabIndex = 25;
            ReturnButton.Text = "归还此书";
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // OK
            // 
            OK.Font = new Font("Microsoft YaHei UI", 12F);
            OK.Location = new Point(680, 260);
            OK.Name = "OK";
            OK.Size = new Size(152, 68);
            OK.TabIndex = 26;
            OK.Text = "确定";
            OK.UseVisualStyleBackColor = true;
            OK.Click += OK_Click;
            // 
            // CenterForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 628);
            Controls.Add(OK);
            Controls.Add(ReturnButton);
            Controls.Add(NicknameBox);
            Controls.Add(nickname);
            Controls.Add(Borrow_List);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CenterForm";
            Text = "用户中心";
            Load += CenterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView Borrow_List;
        private ColumnHeader Bookname;
        private Label nickname;
        private TextBox NicknameBox;
        private Button ReturnButton;
        private Button OK;
        private ColumnHeader Author;
    }
}