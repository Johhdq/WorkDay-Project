using Criado.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Criado.Services
{
    public class LoginService
    {
        public User LoginCad(string op, List<User> users)
        {
            User user = null;
            string nickName;
            string password;

            switch (op)
            {
                case "1":
                    Console.WriteLine("\nLOGIN");
                    Console.Write("NickName: ");
                    nickName = Console.ReadLine();
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    user = users.Find(x => x.NickName == nickName && x.Password == password);
                    if (user == null)
                    {
                        Console.WriteLine("\nUser not registered!");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine("\nLogin successfully!");
                        return user;
                    }
                case "2":
                    Console.WriteLine("\nREGISTER SCREEN");
                    Console.Write("Name >> ");
                    string name = Console.ReadLine();
                    Console.Write("NickName >> ");
                    nickName = Console.ReadLine();
                    Console.Write("Email >> ");
                    string email = Console.ReadLine();
                    Console.Write("Password >> ");
                    password = Console.ReadLine();

                    user = new User(name, nickName, email, password);
                    var userServices = new UserServices(user);

                    if (userServices.AddUser(users))
                    {
                        Console.WriteLine("\nUser registered successfully");
                        return user;
                    }
                    else
                    {
                        Console.WriteLine($"\nUser already registered with this NickName: {nickName} ");
                        return null;
                    }
                default:
                    Console.WriteLine("\nInvalid option!");
                    return null;
                    
            }
        }

    }
}
