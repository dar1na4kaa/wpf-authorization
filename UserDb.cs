using author.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace author.Service
{
    public class UserDb
    {
        public List<User> Users { get; set; } = new List<User>();

        public bool IsLoginUnique(string login)
        {
            return Users.All(u => u.Login != login);
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public List<User> GetUnconfirmedUsers()
        {
            return Users.Where(u => !u.IsConfirmed).ToList();
        }

        public void ConfirmUser(User user)
        {
            user.IsConfirmed = true;
        }

        public void ConfirmAllUsers()
        {
            foreach (User user in Users.Where(u => !u.IsConfirmed))
            {
                user.IsConfirmed = true;
            }
        }
    }
}
