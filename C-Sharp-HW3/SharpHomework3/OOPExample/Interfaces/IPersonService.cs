namespace OOPExample.Interfaces;

public interface IPersonService
{
    int GetAge();
    string GetName();
    decimal GetSalary();
    
}

public interface IStudentService : IPersonService
{
    double GetGPA();
    
}

public interface IInstructorService : IPersonService
{
    string GetDepartment();

}

