public class CircularQueue
{
    private int current = 0;
    private int last = 0;
    private object[] items;

    public CircularQueue(int size)
    {
        items = new object[size];
    }

    public void Add(object obj)
    {
        if (last >= items.Length)
            throw new IndexOutOfRangeException();
        items[last++] = obj;
    }

    public object Next()
    {
        current %= last;
        object item = items[current];
        current++;
        return item;
    }
}

public class CircularQueue<T>
{
    int current = 0;
    int last = 0;
    T[] items;

    public CircularQueue(int size)
    {
        items = new T[size];
    }

    public void Add(T obj)
    {
        if (last >= items.Length)
            throw new IndexOutOfRangeException();
        items[last++] = obj;
    }

    public T Next()
    {
        current %= last;
        T item = items[current];
        current++;
        return item;
    }
}