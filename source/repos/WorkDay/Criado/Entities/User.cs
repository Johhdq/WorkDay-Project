using System;
using System.Collections.Generic;
using System.Text;

namespace Criado.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<WorkItem> WorkItems { get; set; }

        public User(string name, string nickName, string email, string password)
        {
            Name = name;
            NickName = nickName;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Name >> {Name}; NickName >> {NickName}; Email >> {Email}";
        }
    }
}
