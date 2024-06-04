using Library_management_system.UserForm;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using static Library_management_system.En_and_De;
namespace Library_management_system
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private static jsonClass GetJsonObject()
        {
            try
            {
                string json = File.ReadAllText("SQLini.json");
                jsonClass jObect = JsonConvert.DeserializeObject<jsonClass>(json);
                return jObect;
            }
            catch (FileNotFoundException)
            {
                return new jsonClass();
            }
        }
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
        public async static Task<bool> Pingtest()
        {
            try
            {
                Ping ping = new Ping();
                int timeout = 3000;
                PingReply reply = await ping.SendPingAsync("www.baidu.com", timeout);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                return false;
            }
            catch (PingException)
            {
                return false;
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" && PassWord.Text != "")
            {
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
                            string sql = $"create login {UserName.Text} with password=N'{MD5encipher(PassWord.Text)}';use [Library management system];create user {UserName.Text} for login {UserName.Text};grant select,update on [Book_num] to {UserName.Text};use master;alter login {UserName.Text} WITH DEFAULT_DATABASE = [Library management system];";
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
                    }
                    catch(ArgumentNullException)
                    {
                        MessageBox.Show("配置文件缺失：\"SQLini.json\"", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("网络连接失败，请检查网络连接", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
    class jsonClass
    {
        public string? DataSource { get; set; }
        public string? InitialCatalog { get; set; }
        public string? UserID { get; set; }
        public string? Password { get; set; }
    }
}
