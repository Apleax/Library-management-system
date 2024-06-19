namespace Library_management_system.AdminForm
{
    partial class RootForm
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
            Result = new ListView();
            Bookname = new ColumnHeader();
            Author = new ColumnHeader();
            Booketype = new ColumnHeader();
            Booknum = new ColumnHeader();
            Userstatus = new Label();
            SelectButton = new Button();
            UpPage = new Button();
            DownPage = new Button();
            Page = new Label();
            SelectBooknameBox = new TextBox();
            Del_Button = new Button();
            Add_BookButton = new Button();
            UpdateButton = new Button();
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
            Status.TabIndex = 1;
            // 
            // Timenow
            // 
            Timenow.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Timenow.Name = "Timenow";
            Timenow.Size = new Size(0, 15);
            // 
            // Result
            // 
            Result.Columns.AddRange(new ColumnHeader[] { Bookname, Author, Booketype, Booknum });
            Result.Font = new Font("Microsoft YaHei UI", 14F);
            Result.Location = new Point(12, 12);
            Result.Name = "Result";
            Result.Scrollable = false;
            Result.Size = new Size(984, 605);
            Result.TabIndex = 2;
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
            // Userstatus
            // 
            Userstatus.Font = new Font("Microsoft YaHei UI", 9F);
            Userstatus.Location = new Point(1002, 12);
            Userstatus.Name = "Userstatus";
            Userstatus.Size = new Size(152, 61);
            Userstatus.TabIndex = 4;
            Userstatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectButton
            // 
            SelectButton.Font = new Font("Microsoft YaHei UI", 12F);
            SelectButton.Location = new Point(1002, 123);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(152, 68);
            SelectButton.TabIndex = 5;
            SelectButton.Text = "搜索";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // UpPage
            // 
            UpPage.Font = new Font("Microsoft Sans Serif", 16F);
            UpPage.Location = new Point(308, 623);
            UpPage.Name = "UpPage";
            UpPage.Size = new Size(58, 55);
            UpPage.TabIndex = 6;
            UpPage.Text = "<";
            UpPage.UseVisualStyleBackColor = true;
            UpPage.Click += UpPage_Click;
            // 
            // DownPage
            // 
            DownPage.Font = new Font("Microsoft Sans Serif", 16F);
            DownPage.Location = new Point(621, 623);
            DownPage.Name = "DownPage";
            DownPage.Size = new Size(58, 55);
            DownPage.TabIndex = 7;
            DownPage.Text = ">";
            DownPage.UseVisualStyleBackColor = true;
            DownPage.Click += DownPage_Click;
            // 
            // Page
            // 
            Page.Font = new Font("Microsoft YaHei UI", 16F);
            Page.Location = new Point(474, 623);
            Page.Name = "Page";
            Page.Size = new Size(68, 55);
            Page.TabIndex = 8;
            Page.Text = "1";
            Page.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectBooknameBox
            // 
            SelectBooknameBox.Font = new Font("Microsoft YaHei UI", 13F);
            SelectBooknameBox.Location = new Point(1002, 76);
            SelectBooknameBox.Name = "SelectBooknameBox";
            SelectBooknameBox.Size = new Size(152, 41);
            SelectBooknameBox.TabIndex = 9;
            // 
            // Del_Button
            // 
            Del_Button.Font = new Font("Microsoft YaHei UI", 12F);
            Del_Button.Location = new Point(1002, 239);
            Del_Button.Name = "Del_Button";
            Del_Button.Size = new Size(152, 68);
            Del_Button.TabIndex = 10;
            Del_Button.Text = "删除选中项";
            Del_Button.UseVisualStyleBackColor = true;
            Del_Button.Click += Del_Button_Click;
            // 
            // Add_BookButton
            // 
            Add_BookButton.Font = new Font("Microsoft YaHei UI", 12F);
            Add_BookButton.Location = new Point(1002, 351);
            Add_BookButton.Name = "Add_BookButton";
            Add_BookButton.Size = new Size(152, 68);
            Add_BookButton.TabIndex = 11;
            Add_BookButton.Text = "添加书籍";
            Add_BookButton.UseVisualStyleBackColor = true;
            Add_BookButton.Click += Add_BookButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Font = new Font("Microsoft YaHei UI", 12F);
            UpdateButton.Location = new Point(1002, 466);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(152, 68);
            UpdateButton.TabIndex = 12;
            UpdateButton.Text = "修改信息";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // RootForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 728);
            Controls.Add(UpdateButton);
            Controls.Add(Add_BookButton);
            Controls.Add(Del_Button);
            Controls.Add(SelectBooknameBox);
            Controls.Add(Page);
            Controls.Add(DownPage);
            Controls.Add(UpPage);
            Controls.Add(SelectButton);
            Controls.Add(Userstatus);
            Controls.Add(Result);
            Controls.Add(Status);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RootForm";
            Text = "后台管理";
            Load += RootForm_Load;
            Status.ResumeLayout(false);
            Status.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip Status;
        private ToolStripStatusLabel Timenow;
        private ListView Result;
        private ColumnHeader Bookname;
        private ColumnHeader Author;
        private ColumnHeader Booketype;
        private ColumnHeader Booknum;
        private Label Userstatus;
        private Button SelectButton;
        private Button UpPage;
        private Button DownPage;
        private Label Page;
        private TextBox SelectBooknameBox;
        private Button Del_Button;
        private Button Add_BookButton;
        private Button UpdateButton;
    }
}