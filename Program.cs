using System;
using OnlineTicketingSystem.Classes;

namespace OnlineTicketingSystem
{
    class Program
    {
        private static void Main()
        {
            Console.Title = "Online Ticketing System";

            Console.WriteLine("Welcome to the Bucks Centre for the Performing Arts Ticking System");

            Account account = new Account();
            Venue venue = new Venue();

            // Define menus and their options

            Menu accountMenu = new Menu("account");

            accountMenu.AddOption(1, "Login", account.Login);
            accountMenu.AddOption(2, "Exit", account.LogOut);

            Menu mainMenu = new Menu("main");

            Customer customer = LoginController.Instance.SessionCustomer;

            mainMenu.AddOption(1, "View Upcoming Shows", venue.DisplayShows);
            mainMenu.AddOption(2, "Log Out", account.LogOut);

            View.Instance.Menus.Add(accountMenu);
            View.Instance.Menus.Add(mainMenu);

            // Display account menu

            View.Instance.MenuHandler("account");

            // Display main menu

            View.Instance.MenuHandler("main");

            Console.ReadLine();
        }
    }
}