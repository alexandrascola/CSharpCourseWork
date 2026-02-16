using System;
using System.Collections.Generic;
using System.Text;

namespace ITSupportTicketManagerApp
{
    public class TicketManager
    {
        //List to hold a collection of tickets
        private readonly List<Ticket> _tickets = new();

        //Void to ADD tickets
        public void AddTicket(Ticket t)
        {
            //Validate NULL
            if (t is null) throw new ArgumentNullException(nameof(t));
            //Validate Duplicates
            if (FindTicket(t.Id) is not null)
                throw new InvalidOperationException($"A ticket with ID '(t.Id)' already exists.");
            _tickets.Add(t);
        }

        //Bool to REMOVE tickets
        public bool RemoveTicket(string id)
        {
            var t = FindTicket(id);
            if (t is null) return false;
            _tickets.Remove(t);
            return true;
        }

        //Method to find tickets
        public Ticket FindTicket(string id)
        {
            foreach (var t in _tickets)
                if (string.Equals(t.Id, id, StringComparison.OrdinalIgnoreCase))
                    return t;
            return null;
        }

        //Void to DISPLAY all tickets
        public void DisplayAllTickets()
        {
            if (_tickets.Count == 0)
            {
                Console.WriteLine("No tickets found.");
                return;
            }
            
            Console.WriteLine("\n--- Ticket List---");
            foreach (var t in _tickets)
                    Console.WriteLine(t.GetSummary());
        }

        //Int Method to COUNT open tickets
        public int GetOpenCount() 
        {
            int count = 0;
            foreach (var t in _tickets)
                if (!string.Equals(t.Status, "Closed", StringComparison.OrdinalIgnoreCase))
                    count++;
            return count;
        }

        // --------------- CSV Persistence ---------------




    }
}
