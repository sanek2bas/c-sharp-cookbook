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