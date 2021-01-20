using System;
using System.Collections.Generic;

namespace OnlineTicketingSystem.Classes
{
    public class Show
    {
        // Properties
        public Guid Id { get; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<DateTime> ViewingTimes { get; set; }
        public List<ShowSeat> Seats { get; set; }

        // Constructor
        public Show(string name, DateTime date)
        {
            Id = Guid.NewGuid();
            Name = name;
            Date = date;
            ViewingTimes = new List<DateTime>();
            Seats = new List<ShowSeat>();

            InitialiseSeatingPlan();
        }

        // Public Member Functions
        public void AddShowing(int hour, int minute, int second)
        {
            DateTime newTime = Date.Date + new TimeSpan(hour, minute, second);

            ViewingTimes.Add(newTime);
        }

        public void DisplayViewingTimes()
        {
            Console.WriteLine("\nPlease select a time from the list below by entering the number next to the time:\n");

            for (int i = 0; i < ViewingTimes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ViewingTimes[i]:T}");
            }

            Console.WriteLine();
        }

        public void DisplaySeatingPlan()
        {
            Console.WriteLine($"\n= {Name} Seat Selection =\n");

            for (int column = 1; column < 7; column++)
            {
                Console.Write($"    {column}");
            }

            for (int row = 1; row < 8; row++)
            {
                Console.Write($"\n\n\r{row}");

                for (int column = 1; column < 7; column++)
                {
                    ShowSeat seat = Seats.Find(p => p.Row == row && p.Column == column);

                    Console.Write($"   {seat.ConvertStatus()} ");
                }
            }

            Console.WriteLine("\n\t===== Key ====");
            Console.WriteLine("\tA - Available");
            Console.WriteLine("\tH - Held");
            Console.WriteLine("\tT - Taken");
            Console.WriteLine("\t==============");
        }

        // Private Member Functions
        private void InitialiseSeatingPlan()
        {
            for (int row = 1; row < 8; row++)
            {
                for (int column = 1; column < 7; column++)
                {
                    ShowSeat seat = new ShowSeat(row, column);

                    Seats.Add(seat);
                }
            }
        }
    }
}