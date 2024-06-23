namespace Library_management_system.UserForm
{
    partial class UserForm
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
            Status = new StatusStrip();
            Timenow = new ToolStripStatusLabel();
            SelectBooknameBox = new TextBox();
            Page = new Label();
            DownPage = new Button();
            UpPage = new Button();
            SelectButton = new Button();
            Userstatus = new Label();
            Result = new ListView();
            Bookname = new ColumnHeader();
            Author = new ColumnHeader();
            Booketype = new ColumnHeader();
            Booknum = new ColumnHeader();
            Refresh = new Button();
            Borrow = new Button();
            Personal_Center = new Button();
            Status.SuspendLayout();
            SuspendLayout();
            // 
            // Status
            // 
            Status.Font = new Font("Microsoft YaHei UI", 12F);
            Status.ImageScalingSize = new Size(24, 24);
            Status.Items.AddRange(new ToolStripItem[] { Timenow });
            Status.Location = new Point(0, 706);
            Status.Name = "Status";
            Status.RightToLeft = RightToLeft.Yes;
            Status.Size = new Size(1166, 22);
            Status.SizingGrip = false;
            Status.TabIndex = 0;
            // 
            // Timenow
            // 
            Timenow.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Timenow.Name = "Timenow";
            Timenow.Size = new Size(0, 15);
            // 
            // SelectBooknameBox
            // 
            SelectBooknameBox.Font = new Font("Microsoft YaHei UI", 13F);
            SelectBooknameBox.Location = new Point(1002, 76);
            SelectBooknameBox.Name = "SelectBooknameBox";
            SelectBooknameBox.Size = new Size(152, 41);
            SelectBooknameBox.TabIndex = 19;
            // 
            // Page
            // 
            Page.Font = new Font("Microsoft YaHei UI", 16F);
            Page.Location = new Point(474, 623);
            Page.Name = "Page";
            Page.Size = new Size(68, 55);
            Page.TabIndex = 18;
            Page.Text = "1";
            Page.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DownPage
            // 
            DownPage.Font = new Font("Microsoft Sans Serif", 16F);
            DownPage.Location = new Point(621, 623);
            DownPage.Name = "DownPage";
            DownPage.Size = new Size(58, 55);
            DownPage.TabIndex = 17;
            DownPage.Text = ">";
            DownPage.UseVisualStyleBackColor = true;
            DownPage.Click += DownPage_Click;
            // 
            // UpPage
            // 
            UpPage.Font = new Font("Microsoft Sans Serif", 16F);
            UpPage.Location = new Point(308, 623);
            UpPage.Name = "UpPage";
            UpPage.Size = new Size(58, 55);
            UpPage.TabIndex = 16;
            UpPage.Text = "<";
            UpPage.UseVisualStyleBackColor = true;
            UpPage.Click += UpPage_Click;
            // 
            // SelectButton
            // 
            SelectButton.Font = new Font("Microsoft YaHei UI", 12F);
            SelectButton.Location = new Point(1002, 123);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(152, 68);
            SelectButton.TabIndex = 15;
            SelectButton.Text = "搜索";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // Userstatus
            // 
            Userstatus.Font = new Font("Microsoft YaHei UI", 9F);
            Userstatus.Location = new Point(1002, 12);
            Userstatus.Name = "Userstatus";
            Userstatus.Size = new Size(152, 61);
            Userstatus.TabIndex = 14;
            Userstatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Result
            // 
            Result.Columns.AddRange(new ColumnHeader[] { Bookname, Author, Booketype, Booknum });
            Result.Font = new Font("Microsoft YaHei UI", 14F);
            Result.Location = new Point(12, 12);
            Result.Name = "Result";
            Result.Scrollable = false;
            Result.Size = new Size(984, 605);
            Result.TabIndex = 13;
            Result.UseCompatibleStateImageBehavior = false;
            Result.View = View.Details;
            // 
            // Bookname
            // 
            Bookname.Text = "书名";
            Bookname.Width = 354;
            // 
            // Author
            // 
            Author.Text = "作者";
            Author.Width = 250;
            // 
            // Booketype
            // 
            Booketype.Text = "类型";
            Booketype.Width = 200;
            // 
            // Booknum
            // 
            Booknum.Text = "库存";
            Booknum.Width = 180;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(1027, 583);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(112, 34);
            Refresh.TabIndex = 20;
            Refresh.Text = "刷新(F5)";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // Borrow
            // 
            Borrow.Font = new Font("Microsoft YaHei UI", 12F);
            Borrow.Location = new Point(1002, 242);
            Borrow.Name = "Borrow";
            Borrow.Size = new Size(152, 68);
            Borrow.TabIndex = 21;
            Borrow.Text = "借阅此书";
            Borrow.UseVisualStyleBackColor = true;
            Borrow.Click += Borrow_Click;
            // 
            // Personal_Center
            // 
            Personal_Center.Font = new Font("Microsoft YaHei UI", 12F);
            Personal_Center.Location = new Point(1002, 366);
            Personal_Center.Name = "Personal_Center";
            Personal_Center.Size = new Size(152, 68);
            Personal_Center.TabIndex = 22;
            Personal_Center.Text = "个人中心";
            Personal_Center.UseVisualStyleBackColor = true;
            Personal_Center.Click += Personal_Center_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 728);
            Controls.Add(Personal_Center);
            Controls.Add(Borrow);
            Controls.Add(Refresh);
            Controls.Add(SelectBooknameBox);
            Controls.Add(Page);
            Controls.Add(DownPage);
            Controls.Add(UpPage);
            Controls.Add(SelectButton);
            Controls.Add(Userstatus);
            Controls.Add(Result);
            Controls.Add(Status);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "UserForm";
            Text = "图书查询";
            Load += UserForm_Load;
            KeyUp += UserForm_KeyUp;
            Status.ResumeLayout(false);
            Status.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip Status;
        private ToolStripStatusLabel Timenow;
        private TextBox SelectBooknameBox;
        private Label Page;
        private Button DownPage;
        private Button UpPage;
        private Button SelectButton;
        private Label Userstatus;
        private ListView Result;
        private ColumnHeader Bookname;
        private ColumnHeader Author;
        private ColumnHeader Booketype;
        private ColumnHeader Booknum;
        private Button Refresh;
        private Button Borrow;
        private Button Personal_Center;
    }
}