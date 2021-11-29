using Criado.Entities;
using Criado.Enums;
using Criado.Services;
using System;
using System.Collections.Generic;

namespace Criado
{
    class Program
    {

        static void Main(string[] args)
        {
            var users = new List<User>();

            while (true)
            {
                bool hasUser = false;
                InitialMenu();
                User user = null;
                string op = Console.ReadLine();

                if (op == "1")
                {
                    Console.WriteLine("\nLOGIN");
                    Console.Write("NickName: ");
                    string nickName = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();

                    var userVal = users.Find(x => x.NickName == nickName && x.Password == password);
                    if (userVal == null)
                    {
                        Console.WriteLine("\nUser not registered!");
                    }
                    else
                    {
                        hasUser = true;
                        user = userVal;
                        Console.WriteLine("\nLogin successfully!");
                    }
                }
                else if (op == "2")
                {
                    Console.WriteLine("\nREGISTER SCREEN");
                    Console.Write("Name >> ");
                    string name = Console.ReadLine();
                    Console.Write("NickName >> ");
                    string nickName = Console.ReadLine();
                    Console.Write("Email >> ");
                    string email = Console.ReadLine();
                    Console.Write("Password >> ");
                    string password = Console.ReadLine();

                    var userVal = new User(name, nickName, email, password);
                    var userServices = new UserServices(userVal);

                    if (userServices.AddUser(users))
                    {
                        hasUser = true;
                        user = userVal;
                        Console.WriteLine("User registered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"User already registered with this NickName: {nickName} ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

                if (hasUser)
                {
                    MainMenu();
                    Console.Write("Option: ");
                    op = Console.ReadLine();

                    if (op == "1")
                    {
                        UserMenu();
                        Console.Write("Option: ");
                        op = Console.ReadLine();

                        if (op == "1")
                        {
                            UserSubMenu();
                            op = Console.ReadLine();

                            if (op == "1")
                            {
                                string email = Console.ReadLine();
                                user.Email = email;
                                Console.WriteLine("Email successfully changed");
                            }
                            else if (op == "2")
                            {
                                string password = Console.ReadLine();
                                user.Password = password;
                                Console.WriteLine("Password successfully changed");
                            }
                            else
                            {
                                Console.WriteLine("Invalid option!");
                            }
                        }
                        else if (op == "2")
                        {
                            var userVal = new UserServices(user);
                            if (userVal.RemoveUser(users))
                            {
                                Console.WriteLine($"User successfully removed!");
                            }
                            else
                            {
                                Console.WriteLine("User can not be removed, he has work to do!");
                            }
                        }
                    }
                    else if (op == "2")
                    {
                        Console.Write("Description >> ");
                        string description = Console.ReadLine();
                        Console.WriteLine("Item cod >> ");
                        int codItem = int.Parse(Console.ReadLine());

                        Console.WriteLine("CATEGORY");
                        Console.WriteLine(
                            "\n1. Health" +
                            "\n2. Fun" +
                            "\nWork");
                        Console.Write("\nOption: ");
                        op = Console.ReadLine();
                        var workItemCategory = (WorkItemCategory)Enum.Parse(typeof(WorkItemCategory), op);
                        
                    }
                    

                }
                op = Console.ReadLine();
            }






        }


        static void InitialMenu()
        {
            Console.WriteLine(
                "\n1. Enter with a user" +
                "\n2. Register a user");
        }

        static void MainMenu()
        {
            Console.WriteLine(
                "\n1. User settings" +
                "\n2. Add a Work Item" +
                "\n3. Change Item" +
                "\n4. Remove Item" +
                "\n5. List all Work Itens" +
                "\nEnd");
        }
        static void UserMenu()
        {
            Console.WriteLine(
                "\n1. Change a user" +
                "\n2. Remove a user" +
                "\nEnd");
        }
        static void UserSubMenu()
        {
            Console.WriteLine(
                "\n1. Change email" +
                "\n2. Change password");
        }

    }
}

