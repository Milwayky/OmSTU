using System;

class Point
{
    public int x { get; set; }
    public int y { get; set; }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Move(int a, int b, Rectangle rect)
    {
        this.x += a;
        this.y += b;
        if (!rect.Is_inside(this.x, this.y))
        {
            Console.WriteLine($"Точка вышла за границы прямоугольника! ({x}, {y})");
        }
        else
        {
            Console.WriteLine($"Точка перемещена в ({x}, {y})");
        }

    }

    public void Print()
    {
        Console.WriteLine($"Текущие координаты точки: ({x}, {y})");
    }

    private static Random rand = new Random();
    public void Random_Move(Rectangle rect, int range)
    {
        int a = rand.Next(-range, range + 1);
        int b = rand.Next(-range, range + 1);

        Console.WriteLine($"Смещение: ({a}, {b})");
        Move(a, b, rect);
    }

}

class Rectangle
{
    public int x1 { get; set; }
    public int x2 { get; set; }
    public int y1 { get; set; }
    public int y2 { get; set; }

    public Rectangle(int x1, int x2, int y1, int y2)
    {
        this.x1 = Math.Min(x1, x2);
        this.x2 = Math.Max(x1, x2);
        this.y1 = Math.Min(y1, y2);
        this.y2 = Math.Max(y1, y2);
    }

    public bool Is_inside(int x, int y)
    {
        return (x >= this.x1 && x <= this.x2) && (y >= this.y1 && y <= this.y2);
    }

}



class Program
{
    static void Main()
    {
        int x1, y1, x2, y2;

        while (true)
        {
            Console.Write("Введите x1: ");
            x1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите y1: ");
            y1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите x2: ");
            x2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите y2: ");
            y2 = Convert.ToInt32(Console.ReadLine());
                if (x1 != x2 && y1 != y2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректные координаты. Прямоугольник не может иметь одинаковые стороны.");
                }
        }
        Rectangle rect = new Rectangle(x1, x2, y1, y2);
        int x, y;
        while (true)
        {
            Console.Write("Введите координату x точки: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите координату y точки: ");
            y = Convert.ToInt32(Console.ReadLine());

            if (rect.Is_inside(x, y))
            {
                break;
            }
            else
            {
                Console.WriteLine("Точка должна быть внутри прямоугольника.");
            }
        }

        Point point = new Point(x, y);


        Console.Write("Введите диапазон перемещения: ");
        int range = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nПеремещение точки...");
        point.Random_Move(rect, range);
        point.Print();
    }
}
