using BethanyPieShopHRMApp.HRM;
using BethanyPieShopHRMApp;


List<Employee> employees = new List<Employee>();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("**********************************");
Console.WriteLine("** The Cloud Group Employee App **");
Console.WriteLine("**********************************");
Console.ForegroundColor = ConsoleColor.White;

string userSelection;
Console.ForegroundColor = ConsoleColor.Blue;


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
    Console.WriteLine("9: Quit application");
    Console.Write("Your selection: ");

    userSelection = Console.ReadLine();

    switch (userSelection)
    {
        case "1":
            Utilities.RegisterEmployee(employees);
            break;
        case "9": break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
}
while (userSelection != "9");

Console.WriteLine("Thanks for using the console App.");
