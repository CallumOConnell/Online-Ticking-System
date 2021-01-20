using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTicketingSystem.Classes
{
    public class View
    {
        private static View _instance;

        public static View Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new View();
                }

                return _instance;
            }
        }

        public List<Menu> Menus = new List<Menu>();

        public void MenuHandler(string menuName)
        {
            Menu menu = FindMenu(menuName);

            List<MenuOption> options = menu.Options;

            int selectedOption;

            Console.WriteLine("\nPlease select an option from the list below by entering the number of the option:\n");

            do
            {
                menu.DisplayMenuOptions(options);

                selectedOption = Int32.Parse(Console.ReadLine());

                Console.WriteLine();
            }
            while (!options.Any(p => p.Id == selectedOption));

            MenuOption selectedMenuOption = options.Where(p => p.Id == selectedOption).Single();

            selectedMenuOption.Callback(); // Callback parameter on the menu option
        }

        private Menu FindMenu(string menuName)
        {
            foreach (Menu menu in Menus)
            {
                if (menu.Name == menuName)
                {
                    return menu;
                }
            }

            return null;
        }
    }
}