using System.Data.SqlClient;
namespace Library_management_system.RootForm
{
    public partial class AddBook : Form
    {
        string sql;
        public AddBook(string sql)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.sql = sql;
        }
        public string[] GetArray()
        {
            string[] array = new string[4];
            array[0] = Bookname.Text;
            array[1] = Author.Text;
            array[2] = Booktype.Text;
            array[3] = Booknum.Text;
            return array;
        }
        private void Text_changed(object sender, EventArgs e)
        {
            if (Bookname.Text != "" || Author.Text != "" || Booktype.Text != "" || Booknum.Text != "")
            {
                foreach (Control c in this.Controls)
                {
                    if (c.Name == "ErrorLabel")
                    {
                        this.Controls.Remove(c);
                    }
                }
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Bookname.Text != "" && Author.Text != "" && Booktype.Text != "" && Booknum.Text != "")
            {
                string[] book = GetArray();
                try
                {

                    if (Int32.Parse(book[3]) > 0)
                    {
                        using (SqlConnection con = new SqlConnection(sql))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("USE [Library management system];INSERT INTO Book (Bookname, Author, Booktype, Booknum) VALUES (@Bookname, @Author, @Booktype, @Booknum)", con);
                            cmd.Parameters.AddWithValue("@Bookname", book[0]);
                            cmd.Parameters.AddWithValue("@Author", book[1]);
                            cmd.Parameters.AddWithValue("@Booktype", book[2]);
                            cmd.Parameters.AddWithValue("@Booknum", Int32.Parse(book[3])); cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        MessageBox.Show("添加成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("数量不可小于1");
                    }
                }
                catch (SqlException)
                {
                    using (SqlConnection con = new SqlConnection(sql))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand($"USE [Library management system];SELECT * FROM Book WHERE Bookname = '{book[0]}' and Author='{book[1]}'", con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        string a = MessageBox.Show($"已经存在该书本:\n{reader.GetValue(0)}  {reader.GetValue(1)}  {reader.GetValue(2)}  {reader.GetValue(3)}\n是否改为增加库存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        reader.Close();
                        if (a == "Yes")
                        {
                            SqlCommand cmd2 = new SqlCommand($"USE [Library management system];UPDATE Book SET Booknum = Booknum + {Int32.Parse(book[3])} WHERE Bookname = '{book[0]}' and Author='{book[1]}'", con);
                            cmd2.ExecuteNonQuery();
                            con.Close();
                        }
                        con.Close();
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Label l = new Label();
                l.Text = "请填写完整信息";
                l.Location = new Point(0, 0);
                l.AutoSize = true;
                l.Name = "ErrorLabel";
                l.ForeColor = Color.Red;
                l.Font = new Font("微软雅黑", 16);
                this.Controls.Add(l);
            }
        }
    }
}
