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
            Status.SuspendLayout();
            SuspendLayout();
            // 
            // Status
            // 
            Status.Font = new Font("Microsoft YaHei UI", 12F);
            Status.ImageScalingSize = new Size(24, 24);
            Status.Items.AddRange(new ToolStripItem[] { Timenow });
            Status.Location = new Point(0, 670);
            Status.Name = "Status";
            Status.RightToLeft = RightToLeft.Yes;
            Status.Size = new Size(983, 22);
            Status.SizingGrip = false;
            Status.TabIndex = 0;
            // 
            // Timenow
            // 
            Timenow.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Timenow.Name = "Timenow";
            Timenow.Size = new Size(0, 21);
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 692);
            Controls.Add(Status);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserForm";
            Text = "图书查询";
            Load += UserForm_Load;
            Status.ResumeLayout(false);
            Status.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip Status;
        private ToolStripStatusLabel Timenow;
    }
}