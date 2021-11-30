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
            WorkItems = new List<WorkItem>();
        }

        public bool AddWorkItem(WorkItem workItem)
        {
            var items = WorkItems.Find(x => x.CodItem == workItem.CodItem);
            if (items == null)
            {
                WorkItems.Add(workItem);
                return true;
            }
            return false;
        }
        public bool RemoveWorkItem(int codItem)
        {
            var item = WorkItems.Find(x => x.CodItem == codItem);
            if (item != null)
            {
                WorkItems.Remove(item);
                return true;
            }
            return false;
        }
        
        public override string ToString()
        {
            return "Name >> " + Name + "; Email >> " + Email + "; NickName >> " + NickName;
        }
    }
}
