using System;

namespace OnlineTicketingSystem.Classes
{
    public class Ticket
    {
        public enum TicketType { Child, Teen, Adult, Student, OAP }

        // Properties
        public Guid Id { get; }

        public TicketType Type { get; set; }
        
        public string ShowName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }

        public DateTime ShowDate { get; set; }
        public DateTime ShowTime { get; set; }

        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }

        public float Cost { get; set; }

        // Constructor
        public Ticket(string showName, DateTime showDate, DateTime showTime, int row, int column, TicketType type, float cost, string firstName, string lastName, string address)
        {
            Id = Guid.NewGuid();
            ShowName = showName;
            ShowDate = showDate;
            ShowTime = showTime;
            SeatRow = row;
            SeatColumn = column;
            Type = type;
            Cost = cost;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            CustomerAddress = address;
        }

        // Public Member Functions
        public void DisplayTicket()
        {
            Console.WriteLine();
            Console.WriteLine($"Show: {ShowName}");
            Console.WriteLine($"Date: {ShowDate:d}");
            Console.WriteLine($"Time: {ShowTime:HH:mm tt}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Cost: {Cost:C}");
            Console.WriteLine($"Purchaser: {CustomerFirstName} {CustomerLastName}");
            Console.WriteLine($"Address: {CustomerAddress}");
            Console.WriteLine();
        }
    }
}