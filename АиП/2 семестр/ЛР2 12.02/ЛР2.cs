using System;

public class Figure
{
    public string Name { get; set; }
    public Figure(string name)
    {
        Name = name;
    }
}

public interface IFigure
{
    double Calculate_area_of_figure();
    double Calculate_perimetr_of_figure();
}

class Circle: Figure, IFigure
{
    public double radius { get; set; }
    public Circle(double radius) : base("Circle")
    {
        this.radius = radius;
    }
    public double Calculate_area_of_figure()
    {
        return Math.PI * radius * radius;
    }
    public double Calculate_perimetr_of_figure()
    {
        return 2 * Math.PI * radius;
    }
}


class Square: Figure, IFigure
{
    public double length_square { get; set; }
    public Square(double length_square) : base("Square")
    {
        this.length_square = length_square;
    }
    public double Calculate_area_of_figure()
    {
        return length_square * length_square;
    }
    public double Calculate_perimetr_of_figure()
    {
        return 4 * length_square;
    }
}

class Triangle: Figure, IFigure
{
    public double length_triangle { get; set; }
    public Triangle(double length_triangle) : base("Triangle")
    {
        this.length_triangle = length_triangle;
    }
    public double Calculate_area_of_figure()
    {
        return (Math.Sqrt(3) / 4) * length_triangle * length_triangle;
    }
    public double Calculate_perimetr_of_figure()
    {
        return 3 * length_triangle;
    }
}

class Program
{
    public static void Main()
    {
        IFigure[] figures = new IFigure[3];
        int figure_count = 0;
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Создание объекта");
            Console.WriteLine("2. Вывод результатов");
            Console.WriteLine("3. Выход из программы");

            Console.Write("Введите номер опции (от 1 до 3): ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=======================");

            if (option <= 3 && option >= 1)
            {
                switch (option)
                {
                    case 1:
                        if (figure_count >= 3)
                        {
                            Console.WriteLine("Все 3 объекта уже созданы");
                            break;
                        }

                        Console.Write("Введите номер фигуры (1 - Круг, 2 - Квадрат, 3 - Треугольник): ");
                        int figure_type = Convert.ToInt32(Console.ReadLine());

                        switch (figure_type)
                        {
                            case 1:
                                Console.Write("Введите радиус круга: ");
                                double radius = Convert.ToDouble(Console.ReadLine());
                                figures[figure_count] = new Circle(radius);
                                Console.WriteLine("Круг создан");
                                figure_count++;
                                break;

                            case 2:
                                Console.Write("Введите длину стороны квадрата: ");
                                double length_square = Convert.ToDouble(Console.ReadLine());
                                figures[figure_count] = new Square(length_square);
                                Console.WriteLine("Квадрат создан");
                                figure_count++;
                                break;

                            case 3:
                                Console.Write("Введите длину стороны треугольника: ");
                                double length_triangle = Convert.ToDouble(Console.ReadLine());
                                figures[figure_count] = new Triangle(length_triangle);
                                Console.WriteLine("Треугольник создан");
                                figure_count++;
                                break;

                            default:
                                Console.WriteLine("Некорректный номер фигуры.");
                                break;
                        }

                        break;

                    case 2:
                        if (figure_count == 0)
                        {
                            Console.WriteLine("Фигуры не созданы. Сначала выберите опцию 1");
                        }
                        else
                        {
                            Console.WriteLine("\n===== Результаты =====");
                            Console.WriteLine("Результаты:");
                            for (int i = 0; i < figure_count; i++)
                            {
                                Figure figure = (Figure)figures[i];
                                 Console.WriteLine($"\n=== Фигура {i + 1}: {figure.Name} ===");
                                Console.WriteLine($"Площадь: {figures[i].Calculate_area_of_figure()}");
                                Console.WriteLine($"Периметр: {figures[i].Calculate_perimetr_of_figure()}");
                                Console.WriteLine("=======================");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Выход из программы");
                        running = false;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введен некорректный номер опции. Пожалуйста, выберите от 1 до 3.");
            }
        }
    }
}
