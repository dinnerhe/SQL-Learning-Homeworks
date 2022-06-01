using System.Collections;

namespace ConsoleApp1;

public class EmployeeRepository : IEmployeeRepo<Employee> 
{
    private List<Employee> _list;
    public EmployeeRepository(){
        _list = new List<Employee>();
    }

    public void Insert(Employee element)
    {
        _list.Add(element);
    }

    public void Update(Employee element)
    {
        foreach (Employee d in _list)
        {
            if (d.Id == element.Id)
            {
                d.Name = element.Name;
                d.Salary = element.Salary;
                d.DepartmentId = element.DepartmentId;
            }
        }
    }

    public void Delete(int id)
    {
        foreach (Employee d in _list)
        {
            if (d.Id == id)
            {
                _list.Remove(d);
                return;
            }
        }
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> GetAll()
    {
        return _list;
    }

    public Employee GetById(int id)
    {
        foreach (Employee d in _list)
        {
            if (d.Id == id) { return d; }
        }
        return null;

    }

}


public class Employee
{
    public Employee()
    {
    }

    public Employee(int id, string name, int salary, int departmentId)
    {
        Id = id;
        Name = name;
        Salary = salary;
        DepartmentId = departmentId;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public int DepartmentId { get; set; }
}