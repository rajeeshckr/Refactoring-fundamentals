using System;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceCtorFactoryMethod.Best
{
    public enum EmployeeType
    {
        Engineer,
        Salesman,
        Manager
    }

    public abstract class Employee
    {
        public static Employee Create(EmployeeType employeeType)
        {
            switch (employeeType)
            {
                case EmployeeType.Engineer:
                    return new Engineer();
                case EmployeeType.Salesman:
                    return new Salesman();
                case EmployeeType.Manager:
                    return new Manager();
                default:
                    break;
            }
            throw new ArgumentOutOfRangeException("employeeType");
        }
    }

    public class Engineer : Employee { }
    public class Salesman : Employee { }
    public class Manager : Employee { }


}