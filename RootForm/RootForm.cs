using System.Data.SqlClient;
using static Library_management_system.Login_Sign_in;
using Timer = System.Windows.Forms.Timer;

namespace Library_management_system.AdminForm
{
    public partial class RootForm : Form
    {
        string sql;
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
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUSER_SNAME()", con);
                Userstatus.Text = "当前用户：" + cmd.ExecuteScalar().ToString();
            }
            Load_Select(sender, e);
        }
        private void timer_Tick(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand($"USE [Library management system];DECLARE @Page INT = {Int32.Parse(Page.Text)};DECLARE @PageSize INT = 14;DECLARE @SearchTerm NVARCHAR(100) = '{SelectBooknameBox.Text}';DECLARE @TotalRecords INT;DECLARE @TotalPages INT;SELECT @TotalRecords = COUNT(*) FROM Book WHERE Bookname LIKE '%' + @SearchTerm + '%';SET @TotalPages = CEILING(CONVERT(FLOAT, @TotalRecords) / @PageSize);IF @Page <= @TotalPages BEGIN SELECT * FROM Book WHERE Bookname LIKE '%' + @SearchTerm + '%';END ELSE BEGIN SELECT '1' AS Result;END", con);
                        SqlDataReader sqlData = cmd.ExecuteReader();
                        if (flag)
                        {
                            Result.Items.Clear();
                        }
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
                                flag = false;
                            }
                            else
                            {
                                Page.Text = (Int32.Parse(Page.Text) - 1).ToString();
                                MessageBox.Show("已经是最后一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                boun = 1;
                                flag = true;
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
                    SelectButton_Click(sender, e);
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
    }
}
