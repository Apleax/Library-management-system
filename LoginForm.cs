using System.Data.SqlClient;
using System.Diagnostics;
using static Library_management_system.Login_Sign_in;

namespace Library_management_system {     public partial class LoginForm : Form     {         public LoginForm()         {             InitializeComponent();             this.StartPosition = FormStartPosition.CenterScreen;         }
        private void Text_changed(object sender, EventArgs e)
        {
            if (UserName.Text != "" || PassWord.Text != "")
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
        private async void LoginButton_Click(object sender, EventArgs e)         {             if (UserName.Text != "" && PassWord.Text != "")
            {                 if (await Pingtest())
                {
                    try
                    {
                        SqlConnection con = new SqlConnection($"Data Source={DecryptString(GetJsonObject().DataSource)};Initial Catalog={DecryptString(GetJsonObject().InitialCatalog)};User ID={UserName.Text}; Password={MD5encipher(PassWord.Text)}");
                        string sql = con.ConnectionString;
                        con.Open();
                        if (UserName.Text != "ROOT")
                        {
                            UserForm.UserForm userForm = new UserForm.UserForm();
                            userForm.Show();
                            this.Hide();
                            userForm.FormClosing += (s, args) =>
                            {
                                this.Show();
                                con.Close();
                            };
                        }
                        else
                        {
                            AdminForm.RootForm adminForm = new AdminForm.RootForm(sql);
                            adminForm.Show();
                            this.Hide();
                            adminForm.FormClosing += (s, args) =>
                            {
                                this.Show();
                                con.Close();
                            };
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
                }             }             else             {                 Label l = new Label();                 l.Text = "请输入完整用户名或密码";                 l.Location = new Point(255, 250);                 l.AutoSize = true;                 l.Name = "ErrorLabel";                 l.ForeColor = Color.Red;                 this.Controls.Add(l);             }         }
        private async void Sign_inButton_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" && PassWord.Text != "")
            {
                if (await Pingtest())
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection($"Data Source={DecryptString(GetJsonObject().DataSource)};Initial Catalog={DecryptString(GetJsonObject().InitialCatalog)};User ID={DecryptString(GetJsonObject().UserID)}; Password={DecryptString(GetJsonObject().Password)}"))
                        {
                            con.Open();
                            string sql = $"create login {UserName.Text} with password=N'{MD5encipher(PassWord.Text)}';use [Library management system];create user {UserName.Text} for login {UserName.Text};grant select,update on [Book] to {UserName.Text};grant select,update on [User] to {UserName.Text};use master;alter login {UserName.Text} WITH DEFAULT_DATABASE = [Library management system];";
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("注册成功");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 15025)
                        {
                            MessageBox.Show("用户已存在", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }                     catch (ArgumentNullException ex)
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
                l.Text = "请输入完整用户名或密码";
                l.Location = new Point(255, 250);
                l.AutoSize = true;
                l.Name = "ErrorLabel";
                l.ForeColor = Color.Red;
                this.Controls.Add(l);
            }
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private async void ChangePassWord_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" && PassWord.Text != "")
            {
                if (await Pingtest())
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection($"Data Source={DecryptString(GetJsonObject().DataSource)};Initial Catalog={DecryptString(GetJsonObject().InitialCatalog)};User ID={DecryptString(GetJsonObject().UserID)}; Password={DecryptString(GetJsonObject().Password)}"))
                        {
                            con.Open();
                            string sql = $"ALTER LOGIN {UserName.Text} WITH PASSWORD = '{MD5encipher(PassWord.Text)}'";
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("密码修改成功,即将将重启应用");
                        Process process = new Process();
                        process.Close();
                        Application.Restart();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "密码修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                     catch (ArgumentNullException ex)
                    {
                        MessageBox.Show(ex.Message, "密码修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                l.Text = "请输入完整用户名或密码";
                l.Location = new Point(255, 250);
                l.AutoSize = true;
                l.Name = "ErrorLabel";
                l.ForeColor = Color.Red;
                this.Controls.Add(l);
            }
        }
    } } 