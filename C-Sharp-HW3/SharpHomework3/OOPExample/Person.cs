using OOPExample.Interfaces;

namespace OOPExample;

public abstract class Person: IPersonService
{
    public int Age;
    public string Name;
    public List<string> Addresses;
    
    public int GetAge()
    {
        return Age;
    }

    public string GetName()
    {
        return Name;
    }

    public List<string> GetAddresses()
    {
        return Addresses;}
    public abstract decimal GetSalary();
}

public class Student : Person, IStudentService
{
    private Dictionary<string, char> Courses;
    public Student(int age, string name)
    {
        Age = age;
        Name = name;
        Courses = new Dictionary<string, char>();
        Addresses = new List<string>();
    }
    public Student(int age, string name, Dictionary<string, char> courses)
    {
        Age = age;
        Name = name;
        Courses = courses;
    }
    
    public Student(int age, string name, List<string> address)
    {
        Age = age;
        Name = name;
        Courses = new Dictionary<string, char>();
        Addresses = address;
    }

    public override decimal GetSalary()
    {
        return 0;
    }

    public double GetGPA()
    {
        double res = 0;
        foreach (var keyValue in Courses)
        {
            char grade = keyValue.Value;
            switch (grade)
            {
                case 'A':
                    res += 4.0;
                    break;
                case 'B':
                    res += 3.0;
                    break;
                case 'C':
                    res += 2.0;
                    break;
                case 'D':
                    res += 1.0;
                    break;
                default:
                    break;
            }

        }
        return Courses.Count > 0 ? res / Courses.Count : 0;
    }
}

public class Instructor : Person, IInstructorService
{
    private decimal _salary;

    public Instructor(int age, string name, decimal salary)
    {
        Age = age;
        Name = name;
        _salary = salary;
    }

    public override decimal GetSalary()
    {
        return _salary;
    }

    public string GetDepartment()
    {
        throw new NotImplementedException();
    }
}