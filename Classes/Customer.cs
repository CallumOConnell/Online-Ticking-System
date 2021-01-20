using System;
using System.Collections.Generic;
using System.Threading;

namespace OnlineTicketingSystem.Classes
{
    public class Customer
    {
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<Ticket> PurchasedTickets { get; set; }

        public Customer(string firstName, string lastName, string address)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PurchasedTickets = new List<Ticket>();
        }

        public void DisplayPurchasedTickets()
        {
            if (PurchasedTickets.Count > 0)
            {
                Console.WriteLine("\n========================= YOUR TICKETS =========================");

                foreach (var ticket in PurchasedTickets)
                {
                    ticket.DisplayTicket();
                }

                Console.WriteLine("================================================================");
            }
            else
            {
                Console.WriteLine("You haven't purchased any tickets yet!");
            }
        }

        public void GetPaymentInfo()
        {
            Console.WriteLine("\n=============== CHECKOUT ===============");

            string accountNumber;

            do
            {
                Console.Write("\nPlease enter your account number: ");

                accountNumber = Console.ReadLine();

                if (string.IsNullOrEmpty(accountNumber))
                {
                    Console.WriteLine("\nPlease enter a value for the account number field!");
                }
            }
            while (string.IsNullOrEmpty(accountNumber));

            string sortCode;

            do
            {
                Console.Write("\nPlease enter your sort code: ");

                sortCode = Console.ReadLine();

                if (string.IsNullOrEmpty(sortCode))
                {
                    Console.WriteLine("\nPlease enter a value for the sort code field!");
                }
            }
            while (string.IsNullOrEmpty(sortCode));

            Console.WriteLine("\nChecking details...");

            Thread.Sleep(3000);

            Console.WriteLine("\nProcessing payment...");

            Thread.Sleep(3000);

            Console.WriteLine("\nTransaction has been completed successfully!");
        }
    }
}