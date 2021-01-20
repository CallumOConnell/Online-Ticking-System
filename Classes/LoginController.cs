namespace OnlineTicketingSystem.Classes
{
    public class LoginController
    {
        // Private Fields
        private static LoginController _instance;

        // Properties
        public Customer SessionCustomer { get; set; }

        public static LoginController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginController();
                }

                return _instance;
            }
        }
    }
}