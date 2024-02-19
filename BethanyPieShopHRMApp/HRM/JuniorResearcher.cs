using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShopHRMApp.HRM
{
    internal class JuniorResearcher : Researcher
    {
        public JuniorResearcher(string firstName, string lastName, string email, DateTime birthDay, 
            double? hourlyrate) : base(firstName, lastName, email, birthDay, hourlyrate)
        {
        }
    }
}
