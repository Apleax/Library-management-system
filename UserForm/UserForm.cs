using Timer = System.Windows.Forms.Timer;

namespace Library_management_system.UserForm
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.Timenow.Text = now.ToString("HH:mm");
        }
    }
}
