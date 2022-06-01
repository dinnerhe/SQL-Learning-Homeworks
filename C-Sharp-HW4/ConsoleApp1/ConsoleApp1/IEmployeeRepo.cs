namespace ConsoleApp1;

public interface IEmployeeRepo<T> where T: Employee
{
    public void Insert(T element);
    public void Update(T element);
    public void Delete(int id);
    public IEnumerable<T> GetAll();
    public T GetById(int id);
}