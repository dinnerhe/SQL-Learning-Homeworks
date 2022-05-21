namespace SharpHomework4;

public class MyStack<T>
{
    private List<T> stack;

    public MyStack()
    {
        stack = new List<T>();
    }

    public T Pop()
    {
        if (stack.Count == 0) throw new Exception("No Element");
        T element = stack[0];
        stack.RemoveAt(0);
        return element;
    }

    public int Count()
    {
        return stack.Count;
    }

    public void Insert(T element)
    {
        stack.Insert(0, element);
    }

}