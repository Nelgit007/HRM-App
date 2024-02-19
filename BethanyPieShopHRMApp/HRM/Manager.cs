using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShopHRMApp.HRM
{
    internal class Manager : Employee
    {
        public Manager(string firstName, string lastName, string email, DateTime birthDay, 
            double? hourlyrate) : base(firstName, lastName, email, birthDay, hourlyrate)
        {

        }

        public void AttendMeetings()
        {
            NumberOfHoursWorked += 10;
            Console.WriteLine($"Manager {LastName} {FirstName} is now in an important meeting");
        }

        public override void GiveBonus()
        {
            if (NumberOfHoursWorked > 5)
            {
                Console.WriteLine($"{FirstName} {LastName} received a management bonus of $5000");
            }
            else
            {
                Console.WriteLine($"{FirstName} {LastName} received a management bonus of $2500");
            }
        }
    }
}
