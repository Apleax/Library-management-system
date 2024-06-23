using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Library_management_system.RootForm;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library_management_system.UserForm
{
    public partial class CenterForm : Form
    {
        readonly string sql;
        string Username;
        string oldnickname;
        public CenterForm(string sql, string Username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sql = sql;
            this.Username = Username;
        }

        private void CenterForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand command = new SqlCommand($"USE [Library management system];SELECT [Borrowing_books] FROM [User] WHERE [Username] = '{Username}';", con);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    JArray books = JArray.Parse(reader[0].ToString());
                    List<string> book = new List<string>();
                    foreach (JObject bookObject in books)
                    {
                        book.Add(bookObject["bookname"].ToString());
                        book.Add(bookObject["author"].ToString());
                        Borrow_List.Items.Add(new ListViewItem(book.ToArray()));
                        book.Clear();
                    }
                }
                reader.Close();
                command.CommandText = $"USE [Library management system];SELECT [nickname] FROM [User] WHERE [Username] = '{Username}';";
                string newNickname = (string)command.ExecuteScalar();
                NicknameBox.Text = newNickname.Trim();
                oldnickname = NicknameBox.Text;
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sql))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand($"USE [Library management system];SELECT [Borrowing_books] FROM [User] WHERE [Username] = '{Username}';", con);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    JArray books = JArray.Parse(reader[0].ToString());
                    reader.Close();
                    var itemToRemove = books.Children<JObject>().FirstOrDefault(item => item["bookname"]?.ToString() == Borrow_List.SelectedItems[0].SubItems[0].Text);
                    books.Remove(itemToRemove);
                    Regex regex = new Regex("\\s+", RegexOptions.IgnoreCase);
                    string json = regex.Replace(JsonConvert.SerializeObject(books), "");
                    command.CommandText = $"USE [Library management system];UPDATE [User] SET [Borrowing_books] = '{json}' WHERE [Username] = '{Username}';";
                    command.ExecuteNonQuery();
                    command.CommandText = $"USE [Library management system];UPDATE [Book] SET Booknum = Booknum + 1 WHERE Bookname = '{Borrow_List.SelectedItems[0].SubItems[0].Text}'";
                    command.ExecuteNonQuery();
                    MessageBox.Show("归还成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Borrow_List.Items.Clear();
                CenterForm_Load(sender, e);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("请先选择要归还的书籍", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (NicknameBox.Text != oldnickname)
            {
                if (MessageBox.Show($"是否要将昵称:{oldnickname}改为:{NicknameBox.Text}?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    using (SqlConnection con = new SqlConnection(sql)) { 
                        con.Open();
                        SqlCommand command = new SqlCommand($"USE [Library management system];UPDATE [User] SET [nickname] = '{NicknameBox.Text}' WHERE [Username] = '{Username}';", con);
                        command.ExecuteNonQuery();
                        MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            this.Close();
        }
    }
}
