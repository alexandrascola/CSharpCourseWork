using System;
using System.Collections.Generic;
using System.Text;

namespace ITSupportTicketManagerApp
{
    internal class Ticket
    {
        //Class Variables
        private string _id = "";
        private string _description = "";
        private string _priority = "Low";
        private string _status = "Open";

        //Make 2 Arrays for Allowed Values for Priority and Status
        public static readonly string[] AllowedPriorities = { "Low", "Medium", "High" };
        public static readonly string[] AllowedStatuses = { "Open", "In Progress", "Closed" };


    }
}
