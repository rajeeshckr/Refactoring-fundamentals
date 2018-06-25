using System;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceCtorFactoryMethod.Good
{
    public enum EmployeeType
    {
        Engineer,
        Salesman,
        Manager
    }

    public class Employee
    {
        private readonly EmployeeType _employeeType;

        private Employee(EmployeeType employeeType)
        {
            this._employeeType = employeeType;
        }

        public static Employee Create(EmployeeType employeeType)
        {
            return new Employee(employeeType);
        }
    }
}