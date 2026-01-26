// Module 2: Console Calculator
// Demonstrates variables types, operators, conditions, loops, and constants.
// Created by: Alex Scola

using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    //Constant for tax
    private const decimal TaxRate = 0.055m;
    static void Main()
    {
        Console.WriteLine("Module 2: Console Calculator");

     
        //Loop control boolean
        bool continueRunning = true;

        //Last result
        double lastResult = 0;
        bool hasLastResult = false;

        //counter dict
        Dictionary<string, int> operationCount = new()
        {
            ["add"] = 0,
            ["sub"] = 0,
            ["mul"] = 0,
            ["div"] = 0,
            ["avg"] = 0,
            ["tax"] = 0

        };

        //Do while loop to handle user input
        do
        {
            Console.WriteLine("Operations: + - * / avg tax at exit");
            Console.Write("Enter an operator: ");

            string choice = Console.ReadLine();
         

            switch (choice)
            {
                case "+":
                    lastResult = Add();
                    break;

                case "-":
                    lastResult = Subtract();
                    operationCount["add"]++;
                    hasLastResult = true;
                    break;

                case "*":
                    lastResult = Multiply();
                    operationCount["sub"]++;
                    hasLastResult = true;
                    break;

                case "/":
                    lastResult = Divide();
                    operationCount["div"]++;
                    hasLastResult = true;
                    break;

                case "avg":
                    lastResult = Average();
                    operationCount["avg"]++;
                    hasLastResult = true;
                    break;

                case "tax":
                    CalculateTax();
                    operationCount["tax"]++;
                    hasLastResult = false;
                    break;

                case "exit":
                    Console.WriteLine("Have a nice day.");
                    return;

                default:
                    Console.WriteLine("Unknown operation, please try again.");
                    break;

            }

            //Ternary to print last result
            string lastDisplay = hasLastResult ? lastResult.ToString("G", CultureInfo.InvariantCulture) : "N/A";
            Console.WriteLine($"Last numeric result: {lastDisplay}");

            //Control to break out of program
            Console.Write("Perform another operation? (y/n): ");
            string again = Console.ReadLine().Trim().ToLowerInvariant();
            continueRunning = (again == "y" || again == "yes");


        } while (continueRunning);

        //Dsiplay summary
        Console.WriteLine("===== Session Summary =====");
        int totalOps = 0;
        foreach (var kvp in operationCount)
            totalOps += kvp.Value;
        Console.WriteLine($"Total operations: {totalOps}");
        Console.WriteLine("Operation breakdown: ");

        var keys = new List<string>(operationCount.Keys);
        for (int i = 0; i < keys.Count; i++)
            Console.WriteLine($"{keys[i]} : {operationCount[keys[i]]}");

        Console.WriteLine("Thank you for using the calculator");


    }

    //HELPER METHODS
    
    //Method to validate user entered doubles
    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                return value;
            Console.WriteLine("Invalid number, please try again.");
        }

    }

    //Method to validate user decimals
    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
                string input = Console.ReadLine();
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
                return value;
            Console.WriteLine("Invalid number, please try again.");
        }
    }

    //Method to add two numbers
    public static double Add()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the second number");
        double result = a + b;
        Console.WriteLine($"Result: {a} + {b} = {result}");
        return result;
    }

    //Method to subtract 2 numbers
    private static double Subtract()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the second number");
        double result = a - b;
        Console.WriteLine($"Result: {a} - {b} = {result}");
        return result;
    }

    //Method to multiply 2 numbers
    private static double Multiply()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the second number");
        double result = a * b;
        Console.WriteLine($"Result: {a} * {b} = {result}");
        return result;
    }
    //method to divide 2 numbers
    private static double Divide()
    {
        double a = ReadDouble("Enter the first number");
        double b; //Variable is created but not assigned
        do
        {
            b = ReadDouble("Enter the second numbers(non-zero)");
            if (b == 0)
                Console.WriteLine("Cannot divide by zero");
         } while (b == 0);
      

        double result = a / b;
        Console.WriteLine($"Result: {a} / {b} = {result}");
        return result;
    }

    //Method to calculate avg
    private static double Average()
    {
        double a = ReadDouble("Enter the first number");
        double b = ReadDouble("Enter the second number");
        double result = (a + b) / 2.0;
        Console.WriteLine($"Average of {a} and {b} = {result}");
        return result;
    }
    //Method to calculate sales tax
    private static void CalculateTax()
    {
        decimal amount = ReadDecimal("Enter cost");
        decimal tax = amount * TaxRate;
        decimal total = amount + tax;
        Console.WriteLine($"Tax ({TaxRate}): {tax:C}");
        Console.WriteLine($"Total with tax: {total:C}");
    }
}
