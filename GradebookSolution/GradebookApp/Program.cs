

using System.Linq.Expressions;

namespace GradebookApp
{
    internal static class Program
    {
        public static void Main()
        {
            //Instantiate an instance of Gradebook
            var book = new Gradebook();

            Console.WriteLine("*** Gradebook Utility ***");

            bool running = true;

            //While loop to handle user input continuously

            while (running)
            {
                Console.WriteLine("/nMenu:");
                Console.WriteLine("1. Add a grade");
                Console.WriteLine("2. View summary");
                Console.WriteLine("3. Clear all grades");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");

                //String to capture user choice
                string choice = Console.ReadLine();


            }
        }

        //Method to add grades from user input
        private static void AddGrades(Gradebook book)
        {
            //Get input and reject empty strings
            Console.Write("Enter grades separated by spaces: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return;

            //foreach to create a list from user input
            var grades = new List<double>();
            foreach(var part in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (double.TryParse(part, out double g))
                    grades.Add(g);
                else
                    Console.WriteLine($"'{part}' is not a valid number");
            }

            //Validate and add grades
            try {
                book.AddGrade(grades);
                Console.WriteLine($"{grades.Count} grades(s) added.");
            }
            catch(ArgumentOutOfRangeException ex)
                {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


    }
}