using System;

namespace OnlineTicketingSystem.Classes
{
    public class MenuOption
    {
        // Properties
        public readonly int Id;

        public readonly string Name;

        public readonly Action Callback;

        // Constructor
        public MenuOption(int id, string name, Action callback)
        {
            Id = id;
            Name = name;
            Callback = callback;
        }
    }
}