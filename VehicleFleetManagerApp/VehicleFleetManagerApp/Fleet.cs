using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Manager
{
    internal class Fleet
    {
        //Create list to hold vehicles
        private readonly List<Vehicle> _vehicle = new();



        //Method to add vehicles
        public void AddVehicle(Vehicle v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));
            _vehicle.Add(v);
        }

        //Void to remove vehicles



        //Double to get average mileage



        //Void to display vehicles



        //Void to service all vehicles

    }
}
