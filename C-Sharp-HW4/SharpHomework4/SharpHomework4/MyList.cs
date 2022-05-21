namespace SharpHomework4;

public class MyList<T> 
{
    private List<T> sList;

    public MyList()
    {
        sList = new List<T>();
    }

    public void Add(T element)
    {
        sList.Add(element);
    }
    

    public T Remove(int index)
    {
        T element = sList[index];
        sList.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        return sList.Contains(element);
    }

    public void Clear()
    {
        sList.Clear();
    }
    
    

    public void InsertAt(T element, int index)
    {
        sList.Insert(index, element);
    }
    public void DeleteAt( int index)
    {
        sList.RemoveAt(index);
    }

    public T Find(int index)
    {
        return sList[index];
    }
}