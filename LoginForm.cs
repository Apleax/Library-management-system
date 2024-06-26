using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Diagnostics;
using MailKit.Net.Smtp;
using MimeKit;
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
                        if (UserName.Text != "ROOT" && UserName.Text != "sa")
                        {
                            DateTime now = DateTime.Now;
                            using (SqlCommand command = new SqlCommand("USE [Library management system];UPDATE [User] SET [Last Login] = @now WHERE Username = @username", con))
                            {
                                command.Parameters.AddWithValue("@now", now.ToString("yyyy-MM-dd HH:mm:ss"));
                                command.Parameters.AddWithValue("@username", UserName.Text);
                                command.ExecuteNonQuery();
                            }
                            UserForm.UserForm userForm = new UserForm.UserForm(sql, UserName.Text);
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
                }             }             else             {
                foreach (Control c in this.Controls)
                {
                    if (c.Name == "ErrorLabel")
                    {
                        this.Controls.Remove(c);
                    }
                }                 Label l = new Label();                 l.Text = "请输入完整用户名或密码";                 l.Location = new Point(255, 220);                 l.AutoSize = true;                 l.Name = "ErrorLabel";                 l.ForeColor = Color.Red;                 this.Controls.Add(l);             }         }
        private async void Sign_inButton_Click(object sender, EventArgs e)
        {
            SigninForm signinForm = new SigninForm();
            signinForm.Show();
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !LoginButton.Focused)
            {
                LoginButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private async void ChangePassWord_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "")
            {
                if (await Pingtest())
                {
                    try
                    {
                        if (UserName.Text != "ROOT" && UserName.Text != "sa")
                        {
                            string Email = Interaction.InputBox("请输入邮箱", "修改密码", "", Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
                            string emailstring = "";
                            try
                            {
                                if (Email.Trim() != "")
                                {
                                    using (SqlConnection email = new SqlConnection($"Data Source={DecryptString(GetJsonObject().DataSource)};Initial Catalog={DecryptString(GetJsonObject().InitialCatalog)};User ID={DecryptString(GetJsonObject().UserID)}; Password={DecryptString(GetJsonObject().Password)}"))
                                    {
                                        email.Open();
                                        string sql = $"USE [Library management system];SELECT mailbox FROM [User] WHERE mailbox = '{Email}'";
                                        SqlCommand emailcmd = new SqlCommand(sql, email);
                                        SqlDataReader reader = emailcmd.ExecuteReader();
                                        reader.Read();
                                        emailstring = reader.GetString(0);
                                    }
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                MessageBox.Show("邮箱错误", "修改密码失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (Email.Trim() != "")
                            {
                                if (emailstring.Trim().Equals(Email.Trim()))
                                {
                                    string code = new Random().Next(100000, 999999).ToString();
                                    var message = new MimeMessage();
                                    message.From.Add(new MailboxAddress("Apleax", $"{DecryptString(GetJsonObject().SendEmail)}"));
                                    message.To.Add(new MailboxAddress("收件人", $"{Email}"));
                                    message.Subject = "验证码";
                                    message.Body = new TextPart("plain") { Text = $"您的验证码为：{code}" };
                                    try
                                    {
                                        using (var client = new SmtpClient())
                                        {

                                            client.Connect("smtp.qq.com", 465, true);
                                            client.Authenticate($"{DecryptString(GetJsonObject().SendEmail)}", "nypkdgpxybofddji");
                                            client.Send(message);
                                        }
                                    }
                                    catch (SmtpCommandException)
                                    {
                                        MessageBox.Show("邮箱错误", "验证码发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    string Code = Interaction.InputBox("请输入验证码", "修改密码", "", Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
                                    if (Code == code)
                                    {
                                        {
                                            string newpassworld = Interaction.InputBox("请输入新密码", "修改密码", "", Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
                                            if (newpassworld.Trim() != "")
                                            {
                                                using (SqlConnection con = new SqlConnection($"Data Source={DecryptString(GetJsonObject().DataSource)};Initial Catalog={DecryptString(GetJsonObject().InitialCatalog)};User ID={DecryptString(GetJsonObject().UserID)}; Password={DecryptString(GetJsonObject().Password)}"))
                                                {
                                                    con.Open();
                                                    string sql = $"ALTER LOGIN [{UserName.Text}] WITH PASSWORD = '{MD5encipher(newpassworld)}'";
                                                    SqlCommand cmd = new SqlCommand(sql, con);
                                                    cmd.ExecuteNonQuery();
                                                }
                                                MessageBox.Show("密码修改成功,即将将重启应用");
                                                Process process = new Process();
                                                process.Close();
                                                Application.Restart();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("验证码错误，请重试", "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("邮箱错误", "修改密码失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("您无权修改密码");
                        }
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
                foreach (Control c in this.Controls)
                {
                    if (c.Name == "ErrorLabel")
                    {
                        this.Controls.Remove(c);
                    }
                }
                Label l = new Label();
                l.Text = "请输入完整用户名";
                l.Location = new Point(255, 220);
                l.AutoSize = true;
                l.Name = "ErrorLabel";
                l.ForeColor = Color.Red;
                this.Controls.Add(l);
            }
        }
    } } 