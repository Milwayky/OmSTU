using System;

class Calculator<T>
{
    private T value_1;
    private T value_2;

    public Calculator(T value_1, T value_2)
    {
        this.value_1 = value_1;
        this.value_2 = value_2;
    }

    public T Addition()
    {
        dynamic a = value_1;
        dynamic b = value_2;
        return a + b;
    }

    public T Subtraction()
    {
        dynamic a = value_1;
        dynamic b = value_2;
        return a - b;
    }

    public T Multiplication()
    {
        dynamic a = value_1;
        dynamic b = value_2;
        return a * b;
    }

    public T Division()
    {
        dynamic a = value_1;
        dynamic b = value_2;
        if (b == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль");
            return default(T);
        }
        return a / b;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        var calc = new Calculator<double>(num1, num2);

        Console.WriteLine($"\nСложение: {calc.Addition()}");
        Console.WriteLine($"Вычитание: {calc.Subtraction()}");
        Console.WriteLine($"Умножение: {calc.Multiplication()}");
        Console.WriteLine($"Деление: {calc.Division()}");
    }
}

