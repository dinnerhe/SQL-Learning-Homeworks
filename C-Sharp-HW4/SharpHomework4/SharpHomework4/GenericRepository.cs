namespace SharpHomework4;

public class GenericRepository<T>: IRepository<T> where T : class, Generictype
{
    private List<T> _list;

    public GenericRepository()
    {
        _list = new List<T>();
    }

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Remove(T item)
    {
        _list.Remove(item);
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        return _list;
    }

    public T GetById(int id)
    {
        foreach (T item in _list)
        {
            if (item.Id == id) return item;
        }

        throw new Exception("No Such Element");
    }
}