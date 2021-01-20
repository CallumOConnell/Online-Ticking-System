namespace OnlineTicketingSystem.Classes
{
    public class ShowSeat
    {
        public enum SeatStatus { Available, Held, Taken }

        // Properties
        public SeatStatus Status { get; set; }

        public float Price { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }

        // Constructor
        public ShowSeat(int row, int column)
        {
            Row = row;
            Column = column;
            Price = 0f;
            Status = SeatStatus.Available;
        }

        // Public Member Functions
        public string ConvertStatus()
        {
            switch (Status)
            {
                case SeatStatus.Available: return "A";
                case SeatStatus.Held: return "H";
                case SeatStatus.Taken: return "T";
                default: return "";
            }
        }

        public float CalculatePrice(int ticketType)
        {
            float finalPrice = 0f;

            if (Row >= 1 && Row <= 4)
            {
                finalPrice += 20f;
            }
            else
            {
                finalPrice += 30f;
            }

            switch ((Ticket.TicketType)ticketType)
            {
                case Ticket.TicketType.Child:
                {
                    finalPrice += 2.5f;
                    break;
                }
                case Ticket.TicketType.Teen:
                {
                    finalPrice += 15f;
                    break;
                }
                case Ticket.TicketType.Student:
                {
                    finalPrice += 10f;
                    break;
                }
                case Ticket.TicketType.Adult:
                {
                    finalPrice += 20f;
                    break;
                }
                case Ticket.TicketType.OAP:
                {
                    finalPrice += 13f;
                    break;
                }
                default:
                {
                    break;
                }
            }

            Price = finalPrice;

            return finalPrice;
        }
    }
}