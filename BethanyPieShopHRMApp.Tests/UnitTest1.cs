using BethanyPieShopHRMApp.HRM;
using Xunit;

namespace BethanyPieShopHRMApp.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void PerformWork_Adds_NumberOfHours()
        {
            //Following the AAA rule
            //Arrange
            Employee employee = new Employee("Nelson", "Osagie", "osagie@cloudg.com",
                new DateTime(1991, 08, 16), 30);

            int numberOfHours = 3;
            // Act
            employee.PerformWork(numberOfHours);

            // Assert
            Assert.Equal(numberOfHours, employee.NumberOfHoursWorked);
        }

        [Fact]
        public void PerformWork_Adds_DefaultNumberOfHours_IfNoValueIsSpecified()
        {
            //Following the AAA rule
            //Arrange
            Employee employee = new Employee("Nelson", "Osagie", "osagie@cloudg.com",
                new DateTime(1991, 08, 16), 30);

            // Act
            employee.PerformWork();

            // Assert
            Assert.Equal(1, employee.NumberOfHoursWorked);
        }
    }
}