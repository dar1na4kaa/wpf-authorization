using author.Models;
using author.Service;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace author
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private readonly UserDb _database;
        private readonly string _username;

        public UserPage(UserDb userDatabase, string userLogin)
        {
            InitializeComponent();
            _database = userDatabase;
            _username = userLogin;
            updateUserInfo();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage(_database));
        }
        private void updateUserInfo()
        {
            User user = _database.getUserByLogin(_username);
            if (user.IsConfirmed)
            {
                UserTextBlock.Text = "Аккаунт подтвержден";
            }
            else
            {
                UserTextBlock.Text = "Аккаунт НЕ подтвержден";
            }
        }
    }
}
