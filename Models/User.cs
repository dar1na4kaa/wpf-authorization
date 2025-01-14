using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace author.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
