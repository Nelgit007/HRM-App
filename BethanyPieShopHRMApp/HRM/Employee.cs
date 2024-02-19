using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShopHRMApp.HRM
{
    public class Employee
    {
        // Class Fields
        private string firstName;
        private string lastName;
        private string email;

        private int numberOfHoursWorked;
        private double wage;
        private double? hourlyRate;

        public DateTime birthDay;

        private const int minimalWorkingHours = 1;

        public static double taxRate = 0.15;

        // Creating Propertises to enforce encapsulation
        public string FirstName
        {
            get
            {
                return firstName;
            }
            // Write the logic that retunrs the data above 
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            // Write the logic that retunrs the data above 
            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            // Write the logic that retunrs the data above 
            set
            {
                email = value;
            }
        }

        public int NumberOfHoursWorked
        {
            get
            {
                return numberOfHoursWorked;
            }
            // Write the logic that retunrs the data above 
            protected set
            {
                numberOfHoursWorked = value;
            }
        }

        public double Wage
        {
            get
            {
                return wage;
            }
            // Write the logic that retunrs the data above 
            private set
            {
                wage = value;
            }
        }

        public double? HourlyRate
        {
            get
            {
                return hourlyRate;
            }
            // Write the logic that returns the data above
            set
            {
                if (hourlyRate < 0)
                {
                    hourlyRate = 0;
                }
                else
                {
                    hourlyRate = (double)value;
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthDay;
            }
            // Write the logic that retunrs the data above 
            private set
            {
                birthDay = value;
            }
        }

       /* public EmployeeType EmployeeType
        {
            get
            {
                return EmployeeType;
            }
            // Write the logic that retunrs the data above 
            private set
            {
                EmployeeType = value;
            }
        }*/


        public Employee(string firstName, string lastName, string email, DateTime birthDay) : this(firstName,
            lastName, email, birthDay, 0)
        {
        }

        // Creating a Construcutor
        public Employee(string firstName, string lastName, string email, DateTime birthDay, 
            double? hourlyrate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthDay;
            HourlyRate = hourlyrate ?? 10;
            //EmployeeType = employeeType;

        }

        public void PerformWork()
        {
            PerformWork(minimalWorkingHours);

        }

        public void PerformWork(int numberOfHours)
        {
            numberOfHoursWorked += numberOfHours;
            Console.WriteLine($"{FirstName} {LastName} has worked for {NumberOfHoursWorked} " +
                $"hour(s)!");
        }

        public double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
            double taxAmount = wageBeforeTax - taxRate;

            wage = wageBeforeTax - taxAmount;

            Console.WriteLine($"{FirstName} {LastName} has received a wage of {Wage} for {NumberOfHoursWorked} " +
                $"hour(s) worked");

            // Reset hours worked to zero  
            if (resetHours)
                NumberOfHoursWorked = 0;

            return Wage;

        }

        public virtual void GiveBonus()
        {
            Console.WriteLine($"{FirstName} {LastName} received a generic bonus of $1000");
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirstname: \t{FirstName} \nLastname: \t{LastName}\n Email: \t{Email}\n" +
                $"Birthday: {birthDay.ToShortDateString()}\n TaxRate: {taxRate}\n");
        }
    }
}
