using Library_management_system.RootForm;
using System.Data.SqlClient;
using Timer = System.Windows.Forms.Timer;


namespace Library_management_system.AdminForm
{
    public partial class RootForm : Form
    {
        readonly string sql;
        int boun;
        bool flag = true;
        public RootForm(string sql)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sql = sql;
        }
        private void RootForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUSER_SNAME()", con);
                Userstatus.Text = "当前用户：" + cmd.ExecuteScalar().ToString();
            }
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

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (SelectBooknameBox.Text == "")
            {
                if (Result.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection(sql))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand($"USE [Library management system];DELETE FROM Book WHERE Bookname = '{Result.SelectedItems[0].SubItems[0].Text}'", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Result.Items.Clear();
                            Load_Select(sender, e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择要删除的书籍", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (Result.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection(sql))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand($"USE [Library management system];DELETE FROM Book WHERE Bookname = '{Result.SelectedItems[0].SubItems[0].Text}'", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Result.Items.Clear();
                            SelectButton_Click(sender, e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择要删除的书籍", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Add_BookButton_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook(sql);
            addBook.Show();
            addBook.FormClosed += (s, args) =>
            {
                Result.Items.Clear();
                Load_Select(sender, e);
            };
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string Bookname;
            string Author;
            try
            {
                Bookname = Result.SelectedItems[0].SubItems[0].Text;
                Author = Result.SelectedItems[0].SubItems[1].Text;
                UpdateBook update = new UpdateBook(sql, Bookname, Author);
                update.Show();
                update.FormClosed += (s, args) =>
                {
                    Result.Items.Clear();
                    Load_Select(sender, e);
                };
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("请先选择要修改的书籍", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            SelectBooknameBox.Clear();
            Result.Items.Clear();
            Page.Text = "1";
            Load_Select(sender, e);
        }
        private void RootForm_KeyUp(object sender, KeyEventArgs e)
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
    }
}
