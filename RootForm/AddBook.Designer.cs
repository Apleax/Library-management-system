namespace Library_management_system.RootForm
{
    partial class AddBook
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
            AddButton = new Button();
            BooknameLabel = new Label();
            AuthorLabel = new Label();
            BooktypeLabel = new Label();
            BooknumLabel = new Label();
            Bookname = new TextBox();
            Author = new TextBox();
            Booktype = new TextBox();
            Booknum = new TextBox();
            Cancel = new Button();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Font = new Font("Microsoft YaHei UI", 14F);
            AddButton.Location = new Point(99, 487);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(144, 53);
            AddButton.TabIndex = 0;
            AddButton.Text = "确定";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // BooknameLabel
            // 
            BooknameLabel.AutoSize = true;
            BooknameLabel.Font = new Font("Microsoft YaHei UI", 16F);
            BooknameLabel.Location = new Point(99, 76);
            BooknameLabel.Name = "BooknameLabel";
            BooknameLabel.Size = new Size(82, 41);
            BooknameLabel.TabIndex = 1;
            BooknameLabel.Text = "书名";
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Font = new Font("Microsoft YaHei UI", 16F);
            AuthorLabel.Location = new Point(99, 164);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(82, 41);
            AuthorLabel.TabIndex = 2;
            AuthorLabel.Text = "作者";
            // 
            // BooktypeLabel
            // 
            BooktypeLabel.AutoSize = true;
            BooktypeLabel.Font = new Font("Microsoft YaHei UI", 16F);
            BooktypeLabel.Location = new Point(99, 257);
            BooktypeLabel.Name = "BooktypeLabel";
            BooktypeLabel.Size = new Size(82, 41);
            BooktypeLabel.TabIndex = 3;
            BooktypeLabel.Text = "类型";
            // 
            // BooknumLabel
            // 
            BooknumLabel.AutoSize = true;
            BooknumLabel.Font = new Font("Microsoft YaHei UI", 16F);
            BooknumLabel.Location = new Point(99, 363);
            BooknumLabel.Name = "BooknumLabel";
            BooknumLabel.Size = new Size(82, 41);
            BooknumLabel.TabIndex = 4;
            BooknumLabel.Text = "库存";
            // 
            // Bookname
            // 
            Bookname.Font = new Font("Microsoft YaHei UI", 16F);
            Bookname.Location = new Point(187, 73);
            Bookname.Name = "Bookname";
            Bookname.Size = new Size(348, 48);
            Bookname.TabIndex = 7;
            Bookname.TextChanged += Text_changed;
            // 
            // Author
            // 
            Author.Font = new Font("Microsoft YaHei UI", 16F);
            Author.Location = new Point(187, 161);
            Author.Name = "Author";
            Author.Size = new Size(348, 48);
            Author.TabIndex = 8;
            Author.TextChanged += Text_changed;
            // 
            // Booktype
            // 
            Booktype.Font = new Font("Microsoft YaHei UI", 16F);
            Booktype.Location = new Point(187, 254);
            Booktype.Name = "Booktype";
            Booktype.Size = new Size(348, 48);
            Booktype.TabIndex = 9;
            Booktype.TextChanged += Text_changed;
            // 
            // Booknum
            // 
            Booknum.Font = new Font("Microsoft YaHei UI", 16F);
            Booknum.Location = new Point(187, 360);
            Booknum.Name = "Booknum";
            Booknum.Size = new Size(348, 48);
            Booknum.TabIndex = 10;
            Booknum.TextChanged += Text_changed;
            // 
            // Cancel
            // 
            Cancel.Font = new Font("Microsoft YaHei UI", 14F);
            Cancel.Location = new Point(391, 487);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(144, 53);
            Cancel.TabIndex = 11;
            Cancel.Text = "取消";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // AddBook
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 629);
            Controls.Add(Cancel);
            Controls.Add(Booknum);
            Controls.Add(Booktype);
            Controls.Add(Author);
            Controls.Add(Bookname);
            Controls.Add(BooknumLabel);
            Controls.Add(BooktypeLabel);
            Controls.Add(AuthorLabel);
            Controls.Add(BooknameLabel);
            Controls.Add(AddButton);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBook";
            Text = "填写信息";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Label BooknameLabel;
        private Label AuthorLabel;
        private Label BooktypeLabel;
        private Label BooknumLabel;
        private TextBox Bookname;
        private TextBox Author;
        private TextBox Booktype;
        private TextBox Booknum;
        private Button Cancel;
    }
}