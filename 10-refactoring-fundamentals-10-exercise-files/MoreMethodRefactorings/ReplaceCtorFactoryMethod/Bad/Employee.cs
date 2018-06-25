using System;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceCtorFactoryMethod.Bad
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

    public Employee(EmployeeType employeeType)
    {
        this._employeeType = employeeType;
    }
}
}