using System.Data.SqlClient;

namespace Library_management_system.RootForm
{
    public partial class UpdateBook : Form
    {
        readonly string sql;
        readonly string Bookname;
        readonly string Author;
        public UpdateBook(string sql, string Bookname, string Author)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.sql = sql;
            this.Bookname = Bookname;
            this.Author = Author;
        }
        private void UpdateBook_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand command = new SqlCommand($"USE [Library management system];SELECT * FROM Book WHERE Bookname = '{Bookname}' AND Author = '{Author}'", con);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                BooknameBox.Text = reader["Bookname"].ToString();
                AuthorBox.Text = reader["Author"].ToString();
                BooktypeBox.Text = reader["Booktype"].ToString();
                BooknumBox.Text = reader["Booknum"].ToString();
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BoxMouseClick(object sender, MouseEventArgs e)
        {
            TextBox box = (TextBox)sender;
            foreach (Control c in this.Controls)
            {
                if (c.Name == "ErrorLabel")
                {
                    this.Controls.Remove(c);
                }
            }
            if (box.Name == "BooknameBox" || box.Name == "AuthorBox")
            {
                Label err = new Label();
                err.Text = "该项不支持修改";
                err.Location = new Point(220, box.Location.Y + box.Height + 5);
                err.AutoSize = true;
                err.Name = "ErrorLabel";
                err.ForeColor = Color.Red;
                this.Controls.Add(err);
            }
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sql))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand($"USE [Library management system];UPDATE Book SET Booktype = '{BooktypeBox.Text}', Booknum = '{BooknumBox.Text}' WHERE Bookname = '{Bookname}' AND Author = '{Author}'", con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
