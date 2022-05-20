namespace OOPExample;

public class Course
{
    public List<string> Students;
    public readonly string Name;
    public Course(string name)
    {
        Name = name;
        Students = new List<string>();
    }

    public void AddStudent(string student)
    {
        Students.Add(student);
    }
    
    public void RemoveStudent(string student)
    {
        Students.Remove(student);
    }
}