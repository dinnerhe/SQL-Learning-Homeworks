// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Employee a = new Employee(1, "Amy", 1234, 1);
Employee b = new Employee(2, "Tony", 2222, 2);
Employee c = new Employee(3, "Bob", 22, 1);
EmployeeRepository repo = new EmployeeRepository();
repo.Insert(a);
repo.Insert(b);
repo.Insert(c);
repo.Delete(a.Id);
b.Salary = 88888;
foreach (var employee in repo.GetAll())
{
    Console.WriteLine($"Name: {employee.Name}   Salary:{employee.Salary}");
}
