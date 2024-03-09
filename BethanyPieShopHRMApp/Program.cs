using BethanyPieShopHRMApp.HRM;
using BethanyPieShopHRMApp;
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("**********************************");
        Console.WriteLine("** The Cloud Group Employee App **");
        Console.WriteLine("**********************************");
        Console.ForegroundColor = ConsoleColor.White;

        string userSelection;
        Console.ForegroundColor = ConsoleColor.Blue;

        Utilities.CheckForExistingEmployeFile();


        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Loaded {employees.Count} employee(s)\n\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("********************");
            Console.WriteLine("* Select an action *");
            Console.WriteLine("********************");

            Console.WriteLine("1: Register employee");
            Console.WriteLine("2: View all employees");
            Console.WriteLine("3: Save data");
            Console.WriteLine("4: Load data");
            Console.WriteLine("5: Load specific employee");
            Console.WriteLine("9: Quit application");
            Console.Write("Your selection: ");

            userSelection = Console.ReadLine();

            // Pass into the methods the list declared above to register and create
            switch (userSelection)
            {
                case "1":
                    Utilities.RegisterEmployee(employees);
                    break;
                case "2":
                    Utilities.ViewAllEmployees(employees);
                    break;
                case "3":
                    Utilities.SaveEmployees(employees);
                    break;
                case "5":
                    Utilities.LoadEmployeeById(employees);
                    break;
                case "9": break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
        while (userSelection != "9");

        Console.WriteLine("Thanks for using the console App.");
    }

}