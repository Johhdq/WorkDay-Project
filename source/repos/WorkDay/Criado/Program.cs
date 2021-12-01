using Criado.Entities;
using Criado.Enums;
using Criado.Menus;
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
            var menu = new Menu();

            while (true)
            {
                menu.InitialMenu();
                Console.Write("\nOption: ");
                string op = Console.ReadLine();
                var login = new LoginService();

                var user = login.LoginCad(op, users);

                // Menu principal após o login ou cadastro >> Que pode ser modularizado para evitar poluição do código
                if (user != null)
                {
                    menu.MainMenu();
                    Console.Write("\nOption: ");
                    op = Console.ReadLine();

                    if (op == "1")
                    {
                        menu.UserMenu();
                        Console.Write("\nOption: ");
                        op = Console.ReadLine();

                        if (op == "1")
                        {
                            menu.UserSubMenu();
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

                        menu.CategoryMenu();

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
                    else if (op == "5")
                    {
                        menu.ItemChangeMenu();
                        Console.Write("Option: ");
                        op = Console.ReadLine();

                        Console.Write("Enter the CodItem >> ");
                        int codItem = int.Parse(Console.ReadLine());
                        var item = user.ReturnWorkItem(codItem);

                        switch (op)
                        {
                            case "1":
                                if (item != null)
                                {
                                    Console.Write("New Description >> ");
                                }
                                else
                                {
                                    Console.WriteLine($"There's no WorkItem with the followed code: {codItem}");
                                }
                                break;

                            case "2":
                                if (item != null)
                                {

                                    menu.CategoryMenu();
                                    Console.Write("\nNew category >> ");
                                    
                                    try
                                    {
                                        var workItemCategory = (WorkItemCategory)Enum.Parse(typeof(WorkItemCategory), op);
                                        item.Category = workItemCategory;
                                    }
                                    catch
                                    {
                                        throw new ArgumentException("Error! Invalid option!");
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException($"There's no WorkItem with the followed code: {codItem}");
                                }
                                break;

                            case "3":
                                if (item != null)
                                {
                                    try
                                    {
                                        Console.Write("\nNew Start >> ");
                                        var start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                        Console.Write("New Finish >> ");
                                        var finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                    }
                                    catch
                                    {
                                        throw new ArgumentException("Error! Dates with the wrong format!!");
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException($"There's no WorkItem with the followed code: {codItem}");
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
                op = Console.ReadLine();
            }
        }

        // Funções de Menu, que podem ser modularizadas também em outro arquivo?

    }
}

