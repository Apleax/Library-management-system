using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace Library_management_system.UserForm
{
    public partial class UserForm : Form
    {
        readonly string sql;
        int boun;
        bool flag = true;
        string Username;
        public UserForm(string sql, string Username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sql = sql;
            this.Username = Username;
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUSER_SNAME()", con);
                string Username = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"USE [Library management system];SELECT nickname FROM [User] WHERE Username = '{Username}'";
                SqlDataReader sqlData = cmd.ExecuteReader();
                sqlData.Read();
                if (sqlData.GetValue(0) != Username)
                {
                    Userstatus.Text = $"当前用户：{sqlData["nickname"]}";
                }
                else
                {
                    Userstatus.Text = $"当前用户：{Username}";
                }
                con.Close();
            }
            Result.Items.Clear();
            Load_Select(sender, e);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.Timenow.Text = now.ToString("HH:mm");
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sql))
                {
                    con.Open();
                    if (SelectBooknameBox.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand($"USE [Library management system];DECLARE @Page INT = {Int32.Parse(Page.Text)};DECLARE @PageSize INT = 14;DECLARE @SearchTerm NVARCHAR(100) = '{SelectBooknameBox.Text}';DECLARE @TotalRecords INT;DECLARE @TotalPages INT;SELECT @TotalRecords = COUNT(*) FROM Book WHERE Bookname LIKE '%' + @SearchTerm + '%';IF @TotalRecords > 0 BEGIN SET @TotalPages = CEILING(CONVERT(FLOAT, @TotalRecords) / @PageSize);IF @Page <= @TotalPages BEGIN SELECT * FROM Book WHERE Bookname LIKE '%' + @SearchTerm + '%' ORDER BY Bookname OFFSET (@Page - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;END ELSE BEGIN SELECT '1' AS Result;END END ELSE BEGIN SELECT '2' AS Result;END", con);
                        SqlDataReader sqlData = cmd.ExecuteReader();
                        if (flag)
                        {
                            Result.Items.Clear();
                        }
                        while (sqlData.Read())
                        {
                            List<string> book = new List<string>();
                            if (sqlData.GetValue(0).ToString() == "2")
                            {
                                Page.Text = "1";
                                MessageBox.Show("没有找到相关书籍", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                boun = 1;
                                flag = false;
                                break;
                            }
                            else
                            {
                                if (sqlData.GetValue(0).ToString() != "1")
                                {
                                    for (int i = 0; i < sqlData.FieldCount; i++)
                                    {
                                        book.Add(sqlData.GetValue(i).ToString());
                                    }
                                    Result.Items.Add(new ListViewItem(book.ToArray()));
                                    flag = true;
                                }
                                else
                                {
                                    Page.Text = (Int32.Parse(Page.Text) - 1).ToString();
                                    MessageBox.Show("已经是最后一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    boun = 1;
                                    flag = false;
                                }
                            }
                        }
                        boun = 0;
                    }
                    else
                    {
                        MessageBox.Show("请输入要搜索的书名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        boun = 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boun = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                boun = 1;
            }
        }
        private int Load_Select(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sql))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"USE [Library management system];DECLARE @Page INT;DECLARE @PageSize INT = 14;DECLARE @PageNumber INT = {Int32.Parse(Page.Text)};DECLARE @TotalRecords INT;DECLARE @TotalPages INT;SELECT @TotalRecords = COUNT(*) FROM Book;SET @TotalPages = CEILING(CONVERT(FLOAT, @TotalRecords) / @PageSize);IF @PageNumber < @TotalPages BEGIN SELECT * FROM Book ORDER BY Bookname OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;END ELSE IF @PageNumber = @TotalPages BEGIN SELECT * FROM Book ORDER BY Bookname OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @TotalRecords - ((@TotalPages - 1) * @PageSize) ROWS ONLY;END ELSE IF @PageNumber = @TotalPages BEGIN SELECT * FROM Book ORDER BY Bookname OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @TotalRecords - ((@TotalPages - 1) * @PageSize) ROWS ONLY;END ELSE IF @PageNumber > @TotalPages BEGIN SET @Page = 1;SELECT 1 AS resule; END", con);
                    SqlDataReader sqlData = cmd.ExecuteReader();
                    while (sqlData.Read())
                    {
                        List<string> book = new List<string>();
                        if (sqlData.GetValue(0).ToString() != "1")
                        {
                            for (int i = 0; i < sqlData.FieldCount; i++)
                            {
                                book.Add(sqlData.GetValue(i).ToString());
                            }
                            Result.Items.Add(new ListViewItem(book.ToArray()));
                        }
                        else
                        {
                            if (Int32.Parse(Page.Text) - 1 > 0)
                                Page.Text = (Int32.Parse(Page.Text) - 1).ToString();
                            MessageBox.Show("已经是最后一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return 1;
                        }
                    }
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 1;
            }
        }
        private void DownPage_Click(object sender, EventArgs e)
        {
            if (SelectBooknameBox.Text == "")
            {
                Page.Text = (Int32.Parse(Page.Text) + 1).ToString();
                if (Load_Select(sender, e) == 0)
                {
                    Result.Items.Clear();
                    Load_Select(sender, e);
                }
            }
            else
            {
                Page.Text = (Int32.Parse(Page.Text) + 1).ToString();
                if (boun == 0)
                {
                    flag = false;
                    SelectButton_Click(sender, e);
                    flag = true;
                }
            }
        }
        private void UpPage_Click(object sender, EventArgs e)
        {
            if (SelectBooknameBox.Text == "")
            {
                if (Int32.Parse(Page.Text) - 1 > 0)
                {
                    Page.Text = (Int32.Parse(Page.Text) - 1).ToString();
                    if (Load_Select(sender, e) == 0)
                    {
                        Result.Items.Clear();
                        Load_Select(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("已经是第一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (Int32.Parse(Page.Text) - 1 > 0)
                {
                    Page.Text = (Int32.Parse(Page.Text) - 1).ToString();
                    if (boun == 0)
                    {
                        Result.Items.Clear();
                        SelectButton_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("已经是第一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            SelectBooknameBox.Clear();
            Result.Items.Clear();
            Page.Text = "1";
            Load_Select(sender, e);
        }

        private void UserForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Refresh_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                SelectButton_Click(sender, e);
            }
        }

        private void Borrow_Click(object sender, EventArgs e)
        {
            if (Result.SelectedItems.Count > 0)
            {
                if (Int32.Parse(Result.SelectedItems[0].SubItems[3].Text) > 0)
                {
                    using (SqlConnection con = new SqlConnection(sql))
                    {
                        int num = 0;
                        con.Open();
                        SqlCommand cmd = new SqlCommand($"USE [Library management system];SELECT Borrowing_books FROM [User] WHERE Username = '{Username}'", con);
                        string borrowing_books = cmd.ExecuteScalar().ToString();
                        if (borrowing_books != "")
                        {
                            JArray jo = JArray.Parse(borrowing_books);
                            bool flag = true;
                            foreach (JObject j in jo)
                            {
                                if (j["bookname"].ToString() == Result.SelectedItems[0].SubItems[0].Text && j["author"].ToString() == Result.SelectedItems[0].SubItems[1].Text)
                                {
                                    flag = false;
                                    break;
                                }
                                num++;
                            }
                            if (num >= 14)
                            {
                                MessageBox.Show("已经14本了，你借这么多真的是拿来看吗？？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                if (flag)
                                {
                                    if (SelectBooknameBox.Text == "")
                                    {
                                        JObject j = new JObject { { "bookname", Result.SelectedItems[0].SubItems[0].Text }, { "author", Result.SelectedItems[0].SubItems[1].Text }, { "booknum", 1 } };
                                        jo.Add(j);
                                        Regex regex = new Regex("\\s+", RegexOptions.IgnoreCase);
                                        string json = regex.Replace(jo.ToString(), "");
                                        cmd.CommandText = $"USE [Library management system];UPDATE [User] SET Borrowing_books = '{json}' WHERE Username = '{Username}'";
                                        cmd.ExecuteNonQuery();
                                        cmd.CommandText = $"USE [Library management system];UPDATE [Book] SET Booknum = Booknum - 1 WHERE Bookname = '{Result.SelectedItems[0].SubItems[0].Text}'";
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("借阅成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Result.Items.Clear();
                                        Load_Select(sender, e);
                                    }
                                    else
                                    {
                                        JObject j = new JObject { { "bookname", Result.SelectedItems[0].SubItems[0].Text }, { "author", Result.SelectedItems[0].SubItems[1].Text }, { "booknum", 1 } };
                                        jo.Add(j);
                                        Regex regex = new Regex("\\s+", RegexOptions.IgnoreCase);
                                        string json = regex.Replace(jo.ToString(), "");
                                        cmd.CommandText = $"USE [Library management system];UPDATE [User] SET Borrowing_books = '{json}' WHERE Username = '{Username}'";
                                        cmd.ExecuteNonQuery();
                                        cmd.CommandText = $"USE [Library management system];UPDATE [Book] SET Booknum = Booknum - 1 WHERE Bookname = '{Result.SelectedItems[0].SubItems[0].Text}'";
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("借阅成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Result.Items.Clear();
                                        SelectButton_Click(sender, e);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("您已经借阅过这本书", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            if (SelectBooknameBox.Text != "")
                            {
                                JArray jo = new JArray();
                                jo.Add(new JObject { { "bookname", Result.SelectedItems[0].SubItems[0].Text }, { "author", Result.SelectedItems[0].SubItems[1].Text }, { "booknum", 1 } });
                                Regex regex = new Regex("\\s+", RegexOptions.IgnoreCase);
                                string json = regex.Replace(jo.ToString(), "");
                                cmd.CommandText = $"USE [Library management system];UPDATE [User] SET Borrowing_books = '{json}' WHERE Username = '{Username}'";
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = $"USE [Library management system];UPDATE [Book] SET Booknum = Booknum - 1 WHERE Bookname = '{Result.SelectedItems[0].SubItems[0].Text}'";
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("借阅成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Result.Items.Clear();
                                SelectButton_Click(sender, e);
                            }
                            else
                            {
                                JArray jo = new JArray();
                                jo.Add(new JObject { { "bookname", Result.SelectedItems[0].SubItems[0].Text }, { "author", Result.SelectedItems[0].SubItems[1].Text }, { "booknum", 1 } });
                                Regex regex = new Regex("\\s+", RegexOptions.IgnoreCase);
                                string json = regex.Replace(jo.ToString(), "");
                                cmd.CommandText = $"USE [Library management system];UPDATE [User] SET Borrowing_books = '{json}' WHERE Username = '{Username}'";
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = $"USE [Library management system];UPDATE [Book] SET Booknum = Booknum - 1 WHERE Bookname = '{Result.SelectedItems[0].SubItems[0].Text}'";
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("借阅成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Result.Items.Clear();
                                Load_Select(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("这本书已经被借完了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请先选择要借阅的书籍", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Personal_Center_Click(object sender, EventArgs e)
        {
            CenterForm center = new CenterForm(sql, Username);
            center.Show();
            center.FormClosed += (s, args) =>
            {
                UserForm_Load(sender, e);
            };
        }
    }
}
