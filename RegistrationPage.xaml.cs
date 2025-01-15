using author.Models;
using author.Service;
using System.Windows;
using System.Windows.Controls;

namespace author
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly UserDb _database;

        public RegistrationPage(UserDb userDatabase)
        {
            InitializeComponent();
            _database = userDatabase;
        }

        private void CheckPasswordGenerate(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Text = AuthorizationService.GeneratePassword();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string position = PositionComboBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            if (!_database.IsLoginUnique(login))
            {
                MessageBox.Show("Логин уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Position = position,
                Login = login,
                PasswordHash = AuthorizationService.HashPassword(password),
                IsConfirmed = false
            };

            _database.AddUser(user);
            MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new LoginPage(_database));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage(_database));
        }
    }
}
