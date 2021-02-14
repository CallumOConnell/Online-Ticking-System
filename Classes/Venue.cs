using System;
using System.Collections.Generic;

namespace OnlineTicketingSystem.Classes
{
    public class Venue
    {
        private List<Show> _shows;

        public Venue()
        {
            _shows = new List<Show>();

            Show show1 = AddShow("Toy Story 1", new DateTime(2021, 01, 20));

            show1.AddShowing(12, 00, 00);
            show1.AddShowing(18, 30, 00);

            Show show2 = AddShow("Toy Story 2", new DateTime(2021, 01, 21));

            show2.AddShowing(12, 00, 00);
            show2.AddShowing(18, 30, 00);

            Show show3 = AddShow("Toy Story 3", new DateTime(2021, 01, 22));

            show3.AddShowing(12, 00, 00);
            show3.AddShowing(18, 30, 00);
        }

        public void DisplayShows()
        {
            Console.WriteLine("Please select a show from the list below by entering the number of the show:\n");

            for (int i = 0; i < _shows.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_shows[i].Name} ({_shows[i].Date:d})");
            }

            Console.WriteLine();

            SelectShow();
        }

        public void RemoveShow(string showName)
        {
            foreach (Show show in _shows)
            {
                if (show.Name == showName)
                {
                    _shows.Remove(show);
                }
            }
        }

        private void SelectShow()
        {
            int userSelection;

            do
            {
                userSelection = Int32.Parse(Console.ReadLine());

                if (userSelection <= 0 || userSelection > _shows.Count)
                {
                    Console.WriteLine($"\nPlease enter a value between 1 and {_shows.Count}\n");
                }
            }
            while (userSelection <= 0 || userSelection > _shows.Count);

            Show selectedShow = _shows[userSelection - 1];

            SelectShowViewingTime(selectedShow);
        }

        private void SelectShowViewingTime(Show selectedShow)
        {
            selectedShow.DisplayViewingTimes();

            int userSelection;

            do
            {
                userSelection = Int32.Parse(Console.ReadLine());

                if (userSelection <= 0 || userSelection > selectedShow.ViewingTimes.Count)
                {
                    Console.WriteLine($"\nPlease enter a value between 1 and {selectedShow.ViewingTimes.Count}\n");
                }
            }
            while (userSelection <= 0 || userSelection > selectedShow.ViewingTimes.Count);

            DateTime selectedViewingTime = selectedShow.ViewingTimes[userSelection - 1];

            SelectShowSeating(selectedShow, selectedViewingTime);
        }

        private Show AddShow(string name, DateTime date)
        {
            Show show = new Show(name, date);

            _shows.Add(show);

            return show;
        }

        private Show FindShow(string showName)
        {
            foreach (Show show in _shows)
            {
                if (show.Name == showName)
                {
                    return show;
                }
            }

            return null;
        }

        private void SelectShowSeating(Show show, DateTime showViewingTime)
        {
            selectSeats:

            show.DisplaySeatingPlan();

            int amountOfSeats = 0;

            do
            {
                Console.Write("\nHow many seats do you want?: ");

                amountOfSeats = Int32.Parse(Console.ReadLine());

                if (amountOfSeats <= 0)
                {
                    Console.WriteLine("\nPlease enter a value greater than 0!");
                }
            }
            while (amountOfSeats <= 0);

            List<ShowSeat> selectedSeats = new List<ShowSeat>();

            for (int i = 0; i < amountOfSeats; i++)
            {
                seatTaken:

                int seatRowNumber = 0;

                do
                {
                    Console.Write($"\nPlease enter the row of seat number {i + 1}: ");

                    seatRowNumber = Int32.Parse(Console.ReadLine());

                    if (seatRowNumber <= 0 || seatRowNumber > 7)
                    {
                        Console.WriteLine("\nPlease enter a row between 1 and 7!");
                    }
                }
                while (seatRowNumber <= 0 || seatRowNumber > 7);

                int seatColumnNumber = 0;

                do
                {
                    Console.Write($"\nPlease enter the column of seat number {i + 1}: ");

                    seatColumnNumber = Int32.Parse(Console.ReadLine());

                    if (seatColumnNumber <= 0 || seatColumnNumber > 6)
                    {
                        Console.WriteLine("\nPlease enter a column between 1 and 6!");
                    }
                }
                while (seatColumnNumber <= 0 || seatColumnNumber > 6);

                ShowSeat selectedSeat = show.Seats.Find(p => p.Row == seatRowNumber && p.Column == seatColumnNumber);

                if (selectedSeat.Status == ShowSeat.SeatStatus.Taken || selectedSeat.Status == ShowSeat.SeatStatus.Held)
                {
                    Console.WriteLine("\nYou seat you selected is already taken please select another seat please!");

                    goto seatTaken;
                }

                selectedSeat.Status = ShowSeat.SeatStatus.Held;

                selectedSeats.Add(selectedSeat);
            }

            show.DisplaySeatingPlan();

            ConsoleKey response;

            do
            {
                Console.Write("\nAre you happy with your selection? [Y/N] ");

                response = Console.ReadKey(false).Key;

                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            }
            while (response != ConsoleKey.Y && response != ConsoleKey.N);

            if (response == ConsoleKey.Y)
            {
                List<Ticket> basket = new List<Ticket>();

                Customer customer = LoginController.Instance.SessionCustomer;

                Console.WriteLine("\n========== Ticket Type Selection ==========");

                for (int i = 0; i < selectedSeats.Count; i++)
                {
                    ShowSeat seat = selectedSeats[i];

                    Console.WriteLine($"\n========== Seat {i + 1} ==========");
                    Console.WriteLine($"Row: {seat.Row}");
                    Console.WriteLine($"Column: {seat.Column}");
                    Console.WriteLine("============================\n");

                    Console.WriteLine("1. Child\n2. Teen\n3. Adult\n4. Student\n5. OAP");

                    int selectedType = 0;

                    // Ask user to select the ticket type
                    do
                    {
                        Console.Write($"\nPlease enter the ticket type of seat number {i + 1}: ");

                        selectedType = Int32.Parse(Console.ReadLine());

                        if (selectedType < 1 || selectedType > 5)
                        {
                            Console.WriteLine("\nPlease enter a value between 1 and 5");
                        }
                    }
                    while (selectedType < 1 || selectedType > 5);

                    selectedType--; // Allows accurate selection within array as they start from 0

                    float cost = seat.CalculatePrice(selectedType);

                    Ticket ticket = new Ticket(show.Name, show.Date, showViewingTime, seat.Row, seat.Column, (Ticket.TicketType)selectedType, cost, customer.FirstName, customer.LastName, customer.Address);

                    basket.Add(ticket);
                }

                Console.WriteLine("\n=============== Basket ===============");

                float basketTotal = 0f;

                for (int i = 0; i < basket.Count; i++)
                {
                    Ticket ticket = basket[i];

                    basketTotal += ticket.Cost;

                    Console.WriteLine($"\n========== Ticket {i + 1} ==========");
                    Console.WriteLine($"Row: {ticket.SeatRow}");
                    Console.WriteLine($"Column: {ticket.SeatColumn}");
                    Console.WriteLine($"Type: {ticket.Type}");
                    Console.WriteLine($"Price: {ticket.Cost:C}");
                    Console.WriteLine("==============================");
                }

                Console.WriteLine($"\nBasket Total: {basketTotal:C}");

                do
                {
                    Console.Write("\nAre you sure you want to checkout? [Y/N] ");

                    response = Console.ReadKey(false).Key;

                    if (response != ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                    }
                }
                while (response != ConsoleKey.Y && response != ConsoleKey.N);

                if (response == ConsoleKey.Y)
                {
                    customer.GetPaymentInfo();

                    foreach (ShowSeat seat in selectedSeats)
                    {
                        seat.Status = ShowSeat.SeatStatus.Taken;
                    }

                    customer.PurchasedTickets.AddRange(basket);
                }
                else
                {
                    ResetSelectedSeats(selectedSeats);
                }

                customer.DisplayPurchasedTickets();

                View.Instance.MenuHandler("main");
            }
            else
            {
                ResetSelectedSeats(selectedSeats);

                goto selectSeats;
            }
        }

        private void ResetSelectedSeats(List<ShowSeat> selectedSeats)
        {
            foreach (ShowSeat seat in selectedSeats)
            {
                seat.Status = ShowSeat.SeatStatus.Available;
            }

            selectedSeats.Clear();
        }
    }
}