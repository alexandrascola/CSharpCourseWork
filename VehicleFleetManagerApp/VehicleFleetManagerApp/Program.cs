using System.Xml.Serialization;

namespace Vehicle_Fleet_Manager
{
    public static class Program
    {
        //Main method

        public static void Main(string[] args) { 
        
            Console.WriteLine("===Vehicle Fleet Manager==");


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
                    case "6":
                        running = false;
                        break;
                    

                }
            }
            //Goodbye message
            Console.WriteLine("Exiting Fleet Manager. Goodbye!");
        }

        //Method to add vehicle


        //Method to remove vehicle
    }
}