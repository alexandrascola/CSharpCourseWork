using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Manager
{
    internal class Fleet
    {
        //Create list to hold vehicles
        private readonly List<Vehicle> _vehicles = new();



        //Method to add vehicles
        public void AddVehicle(Vehicle v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));
            _vehicles.Add(v);
        }

        //Void to remove vehicles
        


        //Double to get average mileage



        //Void to display vehicles
        public void DisplayAllVehicles()
        {
            //Control for empty list
            if (_vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles in the fleet.");
                return;

            }

            //Foreach through list of vehicles
            Console.WriteLine("\n--- Fleet Summary ---");
            foreach (var v in _vehicles)
            {
                Console.WriteLine(v.GetSummary());

            }

        }


        //Void to service all vehicles

    }
}
