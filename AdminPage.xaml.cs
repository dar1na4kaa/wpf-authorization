using author.Models;
using author.Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace author
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public ObservableCollection<User> DisplayUsers { get; set; }
        private UserDb _database;

        public AdminPage(UserDb userDatabase)
        {
            InitializeComponent();
            _database = userDatabase;

            DisplayUsers = new ObservableCollection<User>(_database.GetUnconfirmedUsers().ToList());
            updateUnconfirmedUsers();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage(_database));
        }
        private void updateUnconfirmedUsers()
        { if (DisplayUsers.Count > 0)
            {
                userListBox.ItemsSource = DisplayUsers;
                userListViewer.Visibility = Visibility.Visible;
            }
            else
            {
                userListViewer.Visibility = Visibility.Hidden;
            }
        }
        private void AdminConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is User user)
            {
                _database.ConfirmUser(user);
                DisplayUsers.Remove(user);
            }
            updateUnconfirmedUsers();
        }
    }
}

