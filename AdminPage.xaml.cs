using author.Models;
using author.Service;
using System.Windows;
using System.Windows.Controls;

namespace author
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private readonly UserDb _database;

        public AdminPage(UserDb userDatabase)
        {
            InitializeComponent();
            _database = userDatabase;
            userListBox.ItemsSource = _database.Users;
        }
        private void updateUnconfirmedUsers()
        {
            userListBox.Items.Clear();
            userListBox.ItemsSource = _database.Users;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage(_database));
        }

        private void AdminConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in _database.GetUnconfirmedUsers())
            {
                _database.ConfirmUser(user);
            }

            MessageBox.Show("Все пользователи подтверждены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            updateUnconfirmedUsers();
        }
    }
}

