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
        private async void AdminForm_Load(object sender, EventArgs e)
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
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.Timenow.Text = now.ToString("HH:mm");
        }

        private async void SelectButton_Click(object sender, EventArgs e)
        {
            if (await Pingtest())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(sql))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("USE [Library management system];SELECT * FROM Book", con);
                        SqlDataReader sqlData = cmd.ExecuteReader();
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
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 18456)
                    {
                        MessageBox.Show("用户名或密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
    }
}
