using System;

namespace OnlineTicketingSystem.Classes
{
    public class Account
    {
        private void Register()
        {
            enterDetails:

            Console.WriteLine("\nYou need to register your account details before you can proceed.");

            Console.Write("\nPlease enter your first name: ");

            string firstName = Console.ReadLine();

            Console.Write("\nPlease enter your last name: ");

            string lastName = Console.ReadLine();

            Console.Write("\nPlease enter your address: ");

            string address = Console.ReadLine();

            ConsoleKey response;

            do
            {
                Console.WriteLine($"\nFirst Name: {firstName}\nLast Name: {lastName}\nAddress: {address}");
                Console.Write("\nAre the details you entered correct? [Y/N] ");

                response = Console.ReadKey(false).Key;

                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            }
            while (response != ConsoleKey.Y && response != ConsoleKey.N);

            if (response == ConsoleKey.Y)
            {
                Customer customer = new Customer(firstName, lastName, address);

                LoginController.Instance.SessionCustomer = customer;
            }
            else
            {
                goto enterDetails;
            }
        }

        public void Login()
        {
            string username;

            do
            {
                Console.Write("Please enter your username: ");

                username = Console.ReadLine();

                if (username != "cal")
                {
                    Console.WriteLine("\nYou didn't enter the correct username!\n");
                }
            }
            while (username != "cal");

            string password;

            do
            {
                Console.Write("\nPlease enter your password: ");

                password = Console.ReadLine();

                if (password != "123")
                {
                    Console.WriteLine("\nYou didn't enter the correct password!");
                }
            }
            while (password != "123");

            Console.WriteLine("\nYou have successfully logged in!");

            Register();
        }

        public void LogOut() => Environment.Exit(0);
    }
}