using author.Models;
using author.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace author
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserDb _database = new UserDb();
        public MainWindow()
        {
            InitializeComponent();

            User user = new User
            {
                FirstName = "Стаценко",
                LastName = "Дарина",
                Position = "Администратор",
                Login = "admin",
                PasswordHash = AuthorizationService.HashPassword("admin1234"),
                IsConfirmed = true,
            };
            _database.AddUser(user);

            MainFrame.Navigate(new LoginPage(_database));
        }
    }
}
