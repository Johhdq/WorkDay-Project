using System;
using System.Collections.Generic;
using System.Text;

namespace Criado.Menus
{
    public class Menu
    {
        public void CategoryMenu()
        {
            Console.WriteLine("CATEGORY");
            Console.WriteLine(
                "\n1. Health" +
                "\n2. Fun" +
                "\nWork");
        }
        public void InitialMenu()
        {
            Console.WriteLine(
                "\n1. Enter with a user" +
                "\n2. Register a user");
        }
        public void MainMenu()
        {
            Console.WriteLine(
                "\n1. User settings" +
                "\n2. Add a Work Item" +
                "\n3. List all Work Itens" +
                "\n4. Remove Item" +
                "\n5. Change Item" +
                "\nEnd");
        }
        public void UserMenu()
        {
            Console.WriteLine(
                "\n1. Change a user" +
                "\n2. Remove a user" +
                "\n3. Show the user data" +
                "\nEnd");
        }
        public void UserSubMenu()
        {
            Console.WriteLine(
                "\n1. Change email" +
                "\n2. Change password");
        }
        public void ItemChangeMenu()
        {
            Console.WriteLine(
                "\n1. Change description" +
                "\n2. Change category" +
                "\n3. Change start/finish" +
                "\nEnd");
        }


    }
}
