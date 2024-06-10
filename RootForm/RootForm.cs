using System.Data.SqlClient;
using static Library_management_system.Login_Sign_in;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Timer = System.Windows.Forms.Timer;

namespace Library_management_system.AdminForm
{
    public partial class RootForm : Form
    {
        string sql;
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

        private async void Load_Select(object sender, EventArgs e)
        {
            if (await Pingtest())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(sql))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand($"USE [Library management system];DECLARE @Page INT;DECLARE @PageSize INT = 14;DECLARE @PageNumber INT = {Int32.Parse(label1.Text)};DECLARE @TotalRecords INT;DECLARE @TotalPages INT;SELECT @TotalRecords = COUNT(*) FROM Book;SET @TotalPages = CEILING(CONVERT(FLOAT, @TotalRecords) / @PageSize);IF @PageNumber < @TotalPages BEGIN SELECT * FROM Book ORDER BY Bookname OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;END ELSE IF @PageNumber = @TotalPages BEGIN SELECT * FROM Book ORDER BY Bookname OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @TotalRecords - ((@TotalPages - 1) * @PageSize) ROWS ONLY;END ELSE IF @PageNumber = @TotalPages BEGIN SELECT * FROM Book ORDER BY Bookname OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @TotalRecords - ((@TotalPages - 1) * @PageSize) ROWS ONLY;END ELSE IF @PageNumber > @TotalPages BEGIN SET @Page = 1;SELECT @Page AS resule; END", con);
                        SqlDataReader sqlData = cmd.ExecuteReader();
                        sqlData.Read();
                        if (sqlData.GetValue(0).ToString() != "1")
                        {
                            Result.Items.Clear();
                            while (sqlData.Read())
                            {
                                List<string> book = new List<string>();
                                for (int i = 0; i < sqlData.FieldCount; i++)
                                {
                                    book.Add(sqlData.GetValue(i).ToString());
                                }
                                Result.Items.Add(new ListViewItem(book.ToArray()));
                            }
                        }
                        else
                        {
                            label1.Text = (Int32.Parse(label1.Text) - 1).ToString();
                            MessageBox.Show("已经是最后一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("无法连接至远程服务器", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownPage_Click(object sender, EventArgs e)
        {
            label1.Text = (Int32.Parse(label1.Text) + 1).ToString();
            Load_Select(sender, e);
        }

        private void UpPage_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(label1.Text) - 1 > 0)
            {
                label1.Text = (Int32.Parse(label1.Text) - 1).ToString();
                Load_Select(sender, e);
            }
            else
            {
                MessageBox.Show("已经是第一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
