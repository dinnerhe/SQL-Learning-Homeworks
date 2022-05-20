namespace OOPExample;

public class Department
{
    public string Instructor;
    public string DeptName;
    public int Budget;
    public List<Course> Courses { get; set; }

    public Department(string dept_name, string instructor, int budget)
    {
        DeptName = dept_name;
        Instructor = instructor;
        Budget = budget;
        Courses = new List<Course>();
    }
    
}