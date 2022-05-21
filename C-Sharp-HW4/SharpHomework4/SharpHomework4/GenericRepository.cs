namespace SharpHomework4;

public class GenericRepository<TProducts>: IRepository<TProducts> where TProducts : Products
{
    private List<TProducts> _list;

    public GenericRepository()
    {
        _list = new List<TProducts>();
    }

    public void Add(TProducts item)
    {
        _list.Add(item);
    }

    public void Remove(TProducts item)
    {
        _list.Remove(item);
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TProducts> GetAll()
    {
        return _list;
    }

    public TProducts GetById(int id)
    {
        foreach (TProducts item in _list)
        {
            if (item.Id == id) return item;
        }

        throw new Exception("No Such Element");
    }
}