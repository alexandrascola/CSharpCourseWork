using System.Xml.Serialization;

namespace Vehicle_Fleet_Manager
{
    public static class Program
    {
        //Main method

        public static void Main(string[] args) { 
        
            Console.WriteLine("===Vehicle Fleet Manager==");

            //Create fleet
            var fleet = new Fleet();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                Console.WriteLine("3. Display Fleet");
                Console.WriteLine("4. Show Average Mileage");
                Console.WriteLine("5. Service Due Vehicles");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                    case "1":
                        AddVehicleMenu(fleet);
                        break;
                    case "2":
                        RemoveVehicleMenu(fleet);
                        break;
                    case "3":
                        fleet.DisplayAllVehicles();
                        break;
                    case "6":
                        running = false;
                        break;

                }
            }
            //Goodbye message
            Console.WriteLine("Exiting Fleet Manager. Goodbye!");
        }

        //Method to add vehicle
        private static void AddVehicleMenu(Fleet fleet)
        {
            Console.Write("Enter make: ");
            string make = Console.ReadLine() ?? "";

            Console.Write("Enter model: ");
            string model = Console.ReadLine() ?? "";

            Console.Write("Enter year: ");
            int year = int.TryParse(Console.ReadLine(), out int y) ? y : 0;

            Console.Write("Enter mileage: ");
            double mileage = double.TryParse(Console.ReadLine(), out double m) ? m : 0;

            var v = new Vehicle(make, model, year, mileage);
            fleet.AddVehicle(v);
            Console.WriteLine("Vehicle Added Successfully.");
        }

        //Method to remove vehicle
        private static void RemoveVehicleMenu(Fleet fleet)
        {
            Console.Write("Enter models to remove: ");
            string model = Console.ReadLine() ?? "";
            fleet.RemoveVehicle(model);
        }
    }
}