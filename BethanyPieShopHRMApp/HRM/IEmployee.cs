using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShopHRMApp.HRM
{
    internal interface IEmployee
    {
        double ReceiveWage(bool resetHours = true);
        void GiveBonus();
        void PerformWork();
        void PerformWork(int numberOfHours);
        void DisplayEmployeeDetails();
    }
}
