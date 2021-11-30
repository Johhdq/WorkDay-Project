using Criado.Entities;
using Criado.Enums;
using Criado.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

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
                Console.Write("\nOption: ");
                string op = Console.ReadLine();

                // Realizando login ou cadastro do usuário!
                if (op == "1")
                {
                    Console.WriteLine("\nLOGIN");
                    Console.Write("NickName: ");
                    string nickName = Console.ReadLine();
                    Console.Write("Password: ");
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
                        Console.WriteLine("\nUser registered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"\nUser already registered with this NickName: {nickName} ");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid option!");
                }

                // Menu principal após o login ou cadastro >> Que pode ser modularizado para evitar poluição do código
                if (hasUser)
                {
                    MainMenu();
                    Console.Write("\nOption: ");
                    op = Console.ReadLine();

                    if (op == "1")
                    {
                        UserMenu();
                        Console.Write("\nOption: ");
                        op = Console.ReadLine();

                        if (op == "1")
                        {
                            UserSubMenu();
                            Console.Write("\nOption: ");
                            op = Console.ReadLine();

                            if (op == "1")
                            {
                                Console.Write("Email >> ");
                                string email = Console.ReadLine();
                                user.Email = email;
                                Console.WriteLine("\nEmail successfully changed");
                            }
                            else if (op == "2")
                            {
                                Console.Write("Password >> ");
                                string password = Console.ReadLine();
                                user.Password = password;
                                Console.WriteLine("\nPassword successfully changed");
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
                        else if (op == "3")
                        {
                            Console.WriteLine(user);
                        }
                    }
                    else if (op == "2")
                    {
                        Console.Write("Description >> ");
                        string description = Console.ReadLine();
                        Console.Write("Item cod >> ");
                        int codItem = int.Parse(Console.ReadLine());

                        CategoryMenu();

                        Console.Write("\nOption: ");
                        op = Console.ReadLine();
                        var workItemCategory = (WorkItemCategory)Enum.Parse(typeof(WorkItemCategory), op);

                        Console.Write("\nStart >> ");
                        var start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        Console.Write("Finish >> ");
                        var finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                        var workItem = new WorkItem(description, codItem, workItemCategory, start, finish);
                        Console.WriteLine(workItem);

                        if(user.AddWorkItem(workItem))
                        {
                            Console.WriteLine($"Work item add to {user.Name}'s list!");
                        }
                        else
                        {
                            Console.WriteLine("It not works");
                        }
                        
                    }
                    else if (op == "3")
                    {
                        Console.WriteLine("\nWorkItens:");
                        if (user.WorkItems.Count != 0)
                        {
                            foreach (var item in user.WorkItems)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No WorkItens!");
                        }
                       
                    }
                    else if (op == "4")
                    {
                        Console.WriteLine("\nRemove WorkItem");
                        Console.Write("CodItem >> ");
                        int codItem = int.Parse(Console.ReadLine());

                        if (user.RemoveWorkItem(codItem))
                        {
                            Console.WriteLine("WorkItem removed successfully!!");
                        }
                        else
                        {
                            Console.WriteLine($"There's no WorkItem with the followed code: {codItem}");
                        }
                    }
                }
                op = Console.ReadLine();
            }
        }

        // Funções de Menu, que podem ser modularizadas também em outro arquivo?
        static void CategoryMenu()
        {
            Console.WriteLine("CATEGORY");
            Console.WriteLine(
                "\n1. Health" +
                "\n2. Fun" +
                "\nWork");
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
                "\n3. List all Work Itens" +
                "\n4. Remove Item" +
                "\n5. Change Item" +
                "\nEnd");
        }
        static void UserMenu()
        {
            Console.WriteLine(
                "\n1. Change a user" +
                "\n2. Remove a user" +
                "\n3. Show the user data" +
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

