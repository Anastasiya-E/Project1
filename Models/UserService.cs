using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserService
    {
        public List<User> Users = new List<User>
        {
            new User {login="nastya", password="nnn123", fullname="Anastasiya", birthday="01/01/2000"},
            new User {login="alena", password="aaa123", fullname="Alena", birthday="02/02/2001"},
            new User {login="tanya", password="ttt123", fullname="Tatyana", birthday="01/01/1999"}
        };
        public bool F = false;
        public bool CheckCredentials(string login, string password)
        {
            bool F = Users.Any(u=>u.login==login && u.password==password);
            return F;
        }
    }
}
