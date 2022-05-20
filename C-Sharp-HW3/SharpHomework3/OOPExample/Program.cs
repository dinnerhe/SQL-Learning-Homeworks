// See https://aka.ms/new-console-template for more information

using OOPExample;

List<Person> PersonList = new List<Person>();
PersonList.Add(new Student(20, "Tony"));
PersonList.Add(new Instructor(20, "molly", 3000, new DateTime(2000, 1, 10)));
PersonList.Add(new Instructor(30, "Bob", 5000));
foreach (Person p in PersonList)
{
    Console.WriteLine(p.GetName());
    Console.WriteLine(p.GetSalary());
}