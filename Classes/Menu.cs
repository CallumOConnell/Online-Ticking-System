using System;
using System.Collections.Generic;

namespace OnlineTicketingSystem.Classes
{
    public class Menu
    {
        // Properties
        public string Name { get; set; }

        public List<MenuOption> Options { get; set; }

        // Constructor
        public Menu(string name)
        {
            Name = name;
            Options = new List<MenuOption>();
        }

        // Public Member Properties
        public void AddOption(int id, string name, Action callback) => Options.Add(new MenuOption(id, name, callback));

        public void DisplayMenuOptions(List<MenuOption> options)
        {
            foreach (MenuOption option in options)
            {
                Console.WriteLine($"{option.Id}. {option.Name}");
            }

            Console.WriteLine();
        }
    }
}