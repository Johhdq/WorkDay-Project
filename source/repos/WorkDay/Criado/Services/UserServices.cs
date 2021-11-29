using Criado.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Criado.Services
{
    class UserServices
    {
        public User User { get; set; }

        public UserServices(User user)
        {
            User = user;
        }

        public bool RemoveUser(List<User> users)
        {
            users.Remove(User);
            return true;
        }
        public bool AddUser(List<User> users)
        {
            var userVal = users.Find(x => x.NickName.ToUpper() == User.NickName.ToUpper());
            if (userVal == null)
            {
                users.Add(User);
                return true;
            }
            return false;
        }

        public void ListAllUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
