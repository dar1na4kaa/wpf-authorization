using author.Models;
using author.Service;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace author
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly UserDb _database;

        public LoginPage(UserDb database)
        {
            InitializeComponent();
            _database = database;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Text;
            User user = _database.Users.FirstOrDefault(u => u.Login == login);
            if (user == null || !AuthorizationService.VerifyPassword(password, user.PasswordHash))
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Вы успешно вошли в систему!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            if (user.Position == "Администратор")
                NavigationService.Navigate(new AdminPage(_database));
            else
                NavigationService.Navigate(new UserPage(_database,login));
        }

        private void GoToRegistrationPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(_database));
        }
    }
}

