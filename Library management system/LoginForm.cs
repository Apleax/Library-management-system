using Library_management_system.UserForm;
namespace Library_management_system
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm.UserForm form1 = new UserForm.UserForm();
            form1.Show();
            form1.FormClosed += (s, args) => this.Close();
        }
    }
}
