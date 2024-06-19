namespace Library_management_system.RootForm
{
    partial class UpdateBook
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
            Cancel = new Button();
            UpdateButton = new Button();
            BooknameLabel = new Label();
            BooknameBox = new TextBox();
            AuthorBox = new TextBox();
            AuthorLabel = new Label();
            BooktypeBox = new TextBox();
            BooktypeLabel = new Label();
            BooknumBox = new TextBox();
            BooknumLabel = new Label();
            SuspendLayout();
            // 
            // Cancel
            // 
            Cancel.Font = new Font("Microsoft YaHei UI", 14F);
            Cancel.Location = new Point(430, 506);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(144, 53);
            Cancel.TabIndex = 12;
            Cancel.Text = "取消";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Font = new Font("Microsoft YaHei UI", 14F);
            UpdateButton.Location = new Point(66, 506);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(144, 53);
            UpdateButton.TabIndex = 13;
            UpdateButton.Text = "确定";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // BooknameLabel
            // 
            BooknameLabel.AutoSize = true;
            BooknameLabel.Font = new Font("Microsoft YaHei UI", 16F);
            BooknameLabel.Location = new Point(66, 55);
            BooknameLabel.Name = "BooknameLabel";
            BooknameLabel.Size = new Size(82, 41);
            BooknameLabel.TabIndex = 14;
            BooknameLabel.Text = "书名";
            // 
            // BooknameBox
            // 
            BooknameBox.Font = new Font("Microsoft YaHei UI", 16F);
            BooknameBox.Location = new Point(220, 52);
            BooknameBox.Name = "BooknameBox";
            BooknameBox.ReadOnly = true;
            BooknameBox.Size = new Size(354, 48);
            BooknameBox.TabIndex = 15;
            BooknameBox.MouseClick += BoxMouseClick;
            // 
            // AuthorBox
            // 
            AuthorBox.Font = new Font("Microsoft YaHei UI", 16F);
            AuthorBox.Location = new Point(220, 170);
            AuthorBox.Name = "AuthorBox";
            AuthorBox.ReadOnly = true;
            AuthorBox.Size = new Size(354, 48);
            AuthorBox.TabIndex = 17;
            AuthorBox.MouseClick += BoxMouseClick;
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Font = new Font("Microsoft YaHei UI", 16F);
            AuthorLabel.Location = new Point(66, 173);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(82, 41);
            AuthorLabel.TabIndex = 16;
            AuthorLabel.Text = "作者";
            // 
            // BooktypeBox
            // 
            BooktypeBox.BackColor = Color.White;
            BooktypeBox.Font = new Font("Microsoft YaHei UI", 16F);
            BooktypeBox.Location = new Point(218, 275);
            BooktypeBox.Name = "BooktypeBox";
            BooktypeBox.Size = new Size(354, 48);
            BooktypeBox.TabIndex = 19;
            BooktypeBox.MouseClick += BoxMouseClick;
            // 
            // BooktypeLabel
            // 
            BooktypeLabel.AutoSize = true;
            BooktypeLabel.Font = new Font("Microsoft YaHei UI", 16F);
            BooktypeLabel.Location = new Point(66, 278);
            BooktypeLabel.Name = "BooktypeLabel";
            BooktypeLabel.Size = new Size(146, 41);
            BooktypeLabel.TabIndex = 18;
            BooktypeLabel.Text = "书籍类型";
            // 
            // BooknumBox
            // 
            BooknumBox.BackColor = Color.White;
            BooknumBox.Font = new Font("Microsoft YaHei UI", 16F);
            BooknumBox.ForeColor = SystemColors.WindowText;
            BooknumBox.Location = new Point(218, 385);
            BooknumBox.Name = "BooknumBox";
            BooknumBox.Size = new Size(354, 48);
            BooknumBox.TabIndex = 21;
            BooknumBox.MouseClick += BoxMouseClick;
            // 
            // BooknumLabel
            // 
            BooknumLabel.AutoSize = true;
            BooknumLabel.Font = new Font("Microsoft YaHei UI", 16F);
            BooknumLabel.Location = new Point(66, 388);
            BooknumLabel.Name = "BooknumLabel";
            BooknumLabel.Size = new Size(82, 41);
            BooknumLabel.TabIndex = 20;
            BooknumLabel.Text = "库存";
            // 
            // UpdateBook
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 604);
            Controls.Add(BooknumBox);
            Controls.Add(BooknumLabel);
            Controls.Add(BooktypeBox);
            Controls.Add(BooktypeLabel);
            Controls.Add(AuthorBox);
            Controls.Add(AuthorLabel);
            Controls.Add(BooknameBox);
            Controls.Add(BooknameLabel);
            Controls.Add(UpdateButton);
            Controls.Add(Cancel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateBook";
            Text = "修改信息";
            Load += UpdateBook_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Cancel;
        private Button UpdateButton;
        private Label BooknameLabel;
        private TextBox BooknameBox;
        private TextBox AuthorBox;
        private Label AuthorLabel;
        private TextBox BooktypeBox;
        private Label BooktypeLabel;
        private TextBox BooknumBox;
        private Label BooknumLabel;
    }
}