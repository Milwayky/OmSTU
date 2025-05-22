using System;

class MyArray<T>
{
    private T[] items;
    private int count;

    public MyArray(int capacity = 10)
    {
        items = new T[capacity];
        count = 0;
    }


    public void Add(T item)
    {
        if (count == items.Length)
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
        }


        items[count] = item;
        count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Индекс вне диапазона");
            return default(T);
        }

        return items[index];
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Индекс вне диапазона");
            return;
        }
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        count--;
    }

    public int Count
    {
        get { return count; }
    }

}


class Program
{
    static void Main()
    {
        var array = new MyArray<string>();

        Console.WriteLine("Введите элементы массива по одному. Чтобы завершить, нажмите Enter на пустой строке:");

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;
            array.Add(input);
        }

        Console.WriteLine("\nСодержимое массива:");
        for (int i = 0; i < array.Count; i++)
        {
            var item = array.Get(i);
            if (item != null)
                Console.WriteLine(item);
        }
    }
}
