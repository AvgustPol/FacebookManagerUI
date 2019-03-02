using System.Threading.Tasks;
using System.Windows;
using FBManager;


namespace FacebookManagerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FacebookService _facebookService;
        public MainWindow()
        {
            InitializeComponent();
            _facebookService = new FacebookService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _facebookService.AccessToken = TextBoxAccessToken.Text;
        }

        private void SetAnswer(string answer)
        {
            TextBlockAnswer.Text = answer;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonGetName.IsEnabled = false;
            var task = _facebookService.GetUserName();
            await task;
            SetAnswer(task.Result);
            ButtonGetName.IsEnabled = true;
        }
    }
}