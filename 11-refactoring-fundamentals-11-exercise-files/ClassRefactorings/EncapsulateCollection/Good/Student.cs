using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassRefactorings.EncapsulateCollection.Good
{
    public class Class
    {
        public string Name { get; set; }
    }

public class Student
{
    private List<Class> _classes = new List<Class>();

    public string Name { get; set;}
    public IReadOnlyCollection<Class> Classes
    {
        get 
        {
            return _classes.AsReadOnly();
        }
    }

    public void EnrollIn(Class theClass)
    {
        // perform some logic to confirm the student can enroll in this class
        _classes.Add(theClass);
    }
}

public class RegistrationService
{
    public void RegisterStudent(Student student, Class theClass)
    {
        student.EnrollIn(theClass);
    }
}
}
