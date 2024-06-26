using System.Data.SqlClient;

namespace Library_management_system.RootForm
{
    public partial class UserManage : Form
    {
        readonly string sql;
        int boun;
        bool flag = true;
        public UserManage(string sql)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sql = sql;
        }
        private int UserManageLoadSelect(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sql))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"USE [Library management system];DECLARE @Page INT = {Int32.Parse(Page.Text)};DECLARE @PageSize INT = 14;DECLARE @SearchTerm NVARCHAR(100) = '';DECLARE @TotalRecords INT;DECLARE @TotalPages INT;SELECT @TotalRecords = COUNT(*) FROM [User] WHERE [Username] LIKE '%' + @SearchTerm + '%';IF @TotalRecords > 0 BEGIN SET @TotalPages = CEILING(CONVERT(FLOAT, @TotalRecords) / @PageSize);IF @Page <= @TotalPages BEGIN SELECT [mailbox],[Username],[Last Login]FROM [User]WHERE [Username] LIKE '%' + @SearchTerm + '%'ORDER BY [Last Login]OFFSET (@Page - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;END ELSE BEGIN SELECT '1' AS Result;END END ELSE BEGIN SELECT '2' AS Result;END", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        List<string> book = new List<string>();
                        if (dr.GetValue(0).ToString() != "1")
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                book.Add(dr.GetValue(i).ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
        }
        private void UserManage_Load(object sender, EventArgs e)
        {
            UserManageLoadSelect(sender, e);
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sql))
                {
                    con.Open();
                    if (SelectUsernameBox.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand($"USE [Library management system];DECLARE @Page INT = {Int32.Parse(Page.Text)};DECLARE @PageSize INT = 14;DECLARE @SearchTerm NVARCHAR(100) = '{SelectUsernameBox.Text}';DECLARE @TotalRecords INT;DECLARE @TotalPages INT;SELECT @TotalRecords = COUNT(*) FROM [User] WHERE [Username] LIKE '%' + @SearchTerm + '%';IF @TotalRecords > 0 BEGIN SET @TotalPages = CEILING(CONVERT(FLOAT, @TotalRecords) / @PageSize);IF @Page <= @TotalPages BEGIN SELECT [mailbox],[Username],[Last Login]FROM [User]WHERE [Username] LIKE '%' + @SearchTerm + '%'ORDER BY [Last Login]OFFSET (@Page - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;END ELSE BEGIN SELECT '1' AS Result;END END ELSE BEGIN SELECT '2' AS Result;END", con);
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
                                MessageBox.Show("没有找到相关账号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                boun = 1;
            }
        }
        private void DownPage_Click(object sender, EventArgs e)
        {
            if (SelectUsernameBox.Text == "")
            {
                Page.Text = (Int32.Parse(Page.Text) + 1).ToString();
                if (UserManageLoadSelect(sender, e) == 0)
                {
                    Result.Items.Clear();
                    UserManageLoadSelect(sender, e);
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
            if (SelectUsernameBox.Text == "")
            {
                if (Int32.Parse(Page.Text) - 1 > 0)
                {
                    Page.Text = (Int32.Parse(Page.Text) - 1).ToString();
                    if (UserManageLoadSelect(sender, e) == 0)
                    {
                        Result.Items.Clear();
                        UserManageLoadSelect(sender, e);
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

        private void Refresh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Refresh_Click(sender, e);
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            SelectUsernameBox.Clear();
            Result.Items.Clear();
            Page.Text = "1";
            UserManageLoadSelect(sender, e);
        }

        private void SingOutButton_Click(object sender, EventArgs e)
        {
            if (SelectUsernameBox.Text == "")
            {
                if (Result.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show("确定要注销此帐号吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection(sql))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand($"USE [master];DROP LOGIN [{Result.SelectedItems[0].SubItems[1].Text}];USE [Library management system];DROP USER [{Result.SelectedItems[0].SubItems[1].Text}];DELETE FROM [User] WHERE Username = '{Result.SelectedItems[0].SubItems[1].Text}';", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("注销成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Result.Items.Clear();
                            UserManageLoadSelect(sender, e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择帐号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            SqlCommand cmd = new SqlCommand($"", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("注销成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Result.Items.Clear();
                            SelectButton_Click(sender, e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择帐号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
