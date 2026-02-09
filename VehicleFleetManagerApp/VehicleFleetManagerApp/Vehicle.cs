using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Manager
{
    public class Vehicle
    {
        //Private fields
        private string _make;
        private string _model;
        private int _year;
        private double _mileage;
        private double _lastServiceMileage;

        //Public properties
        public string Make
        {
            get => _make; //accessor method to get the value of _make
            set => _make = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Make cannot be empty.")
                : value.Trim();
        }
        public string Model
        {
            get => _model;
            set => _model = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Model cannot be empty.")
                : value.Trim();
        }
        public int Year
        {
            get => _year;
            set => _year = (value <1884 || value > DateTime.Now.Year + 1)
                ? throw new ArgumentOutOfRangeException(nameof(value), "Year is out of range.")
                : value;
        }
        public double Mileage
        {
            get => _mileage;
            set => _mileage = (value >= 0)
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "Mileage cannot be negative.");
        }
        public double LastServiceMileage
            {
            get => _lastServiceMileage;
            set => _lastServiceMileage = value >= 0
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "Last service mileage must be between 0 and current mileage.");
        }

        //CONSTRUCTORS:
        //Default constructor
        public Vehicle() { }
        public Vehicle(string make, string model, int year, double mileage)
        {
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
            LastServiceMileage = mileage; //Initial service at creation
        }


        //METHODS:
        //Adding mileage



        //Boolean for needs service
        public bool NeedsService() => (Mileage - LastServiceMileage) >= 10000;




        //Void for perfornm service



        //String for get summary
        public string GetSummary()
        {
            string status = NeedsService() ? "Service Due" : "Good";
            return $"{Year} {Make} {Model} - {Mileage:N0}, mi - (status)";
        }

    }
}
