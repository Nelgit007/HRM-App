using BethanyPieShopHRMApp.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShopHRMApp
{
    internal class Utilities
    {
        public static string directoy = @"C:\Users\HP 840 G3\Desktop\c# Pro\BethanyPieShopHRMApp";
        public static string fileNsme = "employees.xt";

        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.WriteLine("Registering an employee.....");

            Console.WriteLine("What type of employee do you want to register?");
            Console.WriteLine("1. Employee\n2. Manager\n3. Store manager\n4. Researcher\n5. Junior researcher");
            Console.Write("Your selection: ");
            string employeeType = Console.ReadLine();

            if (employeeType != "1" && employeeType != "2" && employeeType != "3"
                && employeeType != "4" && employeeType != "5")
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Console.Write("Enter the first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            Console.Write("Enter the birth day: ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());//example. 2/16/2008

            Console.Write("Enter the hourly rate: ");
            string hourlyRate = Console.ReadLine();
            double rate = double.Parse(hourlyRate);//Assuming input is in the correct format

            // Creating an Employee Reference
            Employee employee = null;

            switch (employeeType)
            {
                case "1":
                    employee = new Employee(firstName, lastName, email, birthDay, rate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, email, birthDay, rate);
                    break;
                case "3":
                    employee = new StoreManager(firstName, lastName, email, birthDay, rate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, email, birthDay, rate);
                    break;
                case "5":
                    employee = new JuniorResearcher(firstName, lastName, email, birthDay, rate);
                    break;
            }

            // Add the Employee to the generic list
            employees.Add(employee);

            Console.WriteLine("Employee created!\n\n");
        }

    }
}
