using BethanyPieShopHRMApp.HRM;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;


namespace BethanyPieShopHRMApp
{
    internal class Utilities
    {
        // Needed to check for file
        public static string directory = @"C:\Users\HP\Desktop\c# Pro";
        public static string fileName = "employees.txt";

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

        internal static void ViewAllEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].DisplayEmployeeDetails();
            }

        }

        internal static void CheckForExistingEmployeFile()
        {
            string path = $"{directory}{fileName}";
            bool existingFileFound = File.Exists(path);

            if (existingFileFound)
            {
                Console.WriteLine("An existing file with employee record has be found!");
            }
            else
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Directory is ready for saving files.");
                    Console.ResetColor();
                }
            }
        }

        internal static void SaveEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            StringBuilder sb = new StringBuilder();
            
            //Using a loop to convert each employee into a string
            foreach (Employee employee in employees)
            {
                // Calling the GetEmployee type
                string type = GetEmployeeType(employee);

                sb.Append($"firstName:{employee.FirstName};");
                sb.Append($"lastName:{employee.LastName};");
                sb.Append($"email:{employee.Email};");
                sb.Append($"birthDay:{employee.birthDay.ToShortDateString()};");
                sb.Append($"hourlyRate:{employee.HourlyRate};");
                sb.Append($"type:{type};");
                sb.Append(Environment.NewLine);
            }
            // Write text 
            File.WriteAllText(path, sb.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved employees successfully");
            Console.ResetColor();

        }

        // Senior Dev's Assist
        public static void LoadEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";

            try
            {
                if (File.Exists(path))
                {
                    employees.Clear();

                    //now read the file
                    string[] employeesAsString = File.ReadAllLines(path);
                    for (int i = 0; i < employeesAsString.Length; i++)
                    {
                        string[] employeeSplits = employeesAsString[i].Split(';');
                        string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);
                        string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1);
                        string email = employeeSplits[2].Substring(employeeSplits[2].IndexOf(':') + 1);
                        DateTime birthDay = DateTime.Parse(employeeSplits[3].Substring(employeeSplits[3].IndexOf(':') + 1));
                        double hourlyRate = double.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(':') + 1));
                        string employeeType = employeeSplits[5].Substring(employeeSplits[5].IndexOf(':') + 1);

                        Employee employee = null;

                        switch (employeeType)
                        {
                            case "1":
                                employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "2":
                                employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "3":
                                employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "4":
                                employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                            case "5":
                                employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                                break;
                        }


                        employees.Add(employee);

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
                    Console.ResetColor();

                }
            }

            // Multiple catch   
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something went wrong passiing file! please check the date.\n\n");
                // Display eroor message and location of error
                Console.WriteLine(iex.Message);
                //Console.ResetColor();
            }

            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The File could not be found!\n\n");
                // Display eroor message and location of error
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
                //Console.ResetColor();
            }

            // General catch exception
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something went wrong while loading the file!\n\n");
                // Display error message and location of error
                Console.WriteLine(ex.Message);
                
            }

            finally
            {
                Console.ResetColor();
            }

        }


        //To know the typr of employee een saved convert each saved emplyee tot type
        private static string GetEmployeeType(Employee employee)
        {
            // is checks if the obj is of a certain type
            if (employee is Manager)
                return "2";
            else if (employee is StoreManager)
                return "3";
            else if (employee is JuniorResearcher)
                return "5";
            else if (employee is Researcher)
                return "4";
            else if (employee is Employee)
                return "1";
            return "0";

        }

        internal static void LoadEmployeeById(List<Employee> employees)
        {
            try
            {
                Console.WriteLine("Enter the Employee ID you want to see.");

                int selectedId = int.Parse(Console.ReadLine());
                Employee selectedEmployee = employees[selectedId];
                selectedEmployee.DisplayEmployeeDetails();
            }
            catch (FormatException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Incorredt ID format!\n\n");
                Console.ResetColor();
            }
            
        }
    }
}
