using Library_management_system.UserForm;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
namespace Library_management_system
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public static string MD5encipher(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] passwordByte = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] passwordHash = md5.ComputeHash(passwordByte);
                string s = "";
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    s += passwordHash[i].ToString("X2");
                }
                return s;
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" || PassWord.Text != "")
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

        private void Sign_inButton_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" || PassWord.Text != "")
            {
                try
                {
                        SqlConnection con = new SqlConnection($"Data Source=frp-oil.top,23082;Initial Catalog=master;User ID=apleax; Password=yzj041206");
                        con.Open();
                        string sql = $"create login {UserName.Text} with password=N'{PassWord.Text}';use [Library management system];create user {UserName.Text} for login {UserName.Text};grant select,update on [Book_num] to {UserName.Text};use master;alter login {UserName.Text} WITH DEFAULT_DATABASE = [Library management system];";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        MessageBox.Show("注册成功！");
                        con.Dispose();
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Number.ToString());
                }
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
    }
}
