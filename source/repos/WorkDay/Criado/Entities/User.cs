using System;
using System.Collections.Generic;
using System.Text;

namespace Criado.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public List<WorkItem> WorkItems { get; set; }

        public bool ChangeInsertPassword(string password)
        {
            if (password.Length <= 50) 
            {
                Password = password;
                return true;
            }
            return false;
        }
    }
}
