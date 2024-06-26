using System.Data.SqlClient;
using static Library_management_system.Login_Sign_in;

namespace Library_management_system
{
    public partial class SigninForm : Form
    {
        public SigninForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Text_changed(object sender, EventArgs e)
        {
            if (UserName.Text != "" || PassWord.Text != "" || Mailbox.Text != "")
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
        private async void Sign_inButton_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" && PassWord.Text != "" && Mailbox.Text != "")
            {
                if (await Pingtest())
                {
                    try
                    {
                        if (MessageBox.Show($"邮箱:{Mailbox.Text}\n用户名:{UserName.Text}\n密码:{PassWord.Text}\n是否确认注册？", "注册确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (SqlConnection con = new SqlConnection($"Data Source={DecryptString(GetJsonObject().DataSource)};Initial Catalog={DecryptString(GetJsonObject().InitialCatalog)};User ID={DecryptString(GetJsonObject().UserID)}; Password={DecryptString(GetJsonObject().Password)}"))
                            {
                                con.Open();
                                DateTime now = DateTime.Now;
                                string sql2 = $"use [Library management system];INSERT INTO [User](nickname,mailbox,Username,[Last Login])VALUES('{UserName.Text}','{Mailbox.Text}','{UserName.Text}','{now}')";
                                string sql = $"create login [{UserName.Text}] with password=N'{MD5encipher(PassWord.Text)}';use [Library management system];create user [{UserName.Text}] for login [{UserName.Text}];grant select,update on [Book] to [{UserName.Text}];grant select,update on [User] to [{UserName.Text}];use master;alter login [{UserName.Text}] WITH DEFAULT_DATABASE = [Library management system];";
                                SqlCommand cmd = new SqlCommand(sql2, con);
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("注册成功");
                                    this.Close();
                                }
                            }
                        }
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("用户已存在", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentNullException ex)
                    {
                        MessageBox.Show(ex.Message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                Label l = new Label();
                l.Text = "请输入完整用户名或密码和邮箱";
                l.Location = new Point(255, 300);
                l.AutoSize = true;
                l.Name = "ErrorLabel";
                l.ForeColor = Color.Red;
                this.Controls.Add(l);
            }
        }

        private void SigninForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sign_inButton_Click(sender, e);
            }
        }
    }
}
