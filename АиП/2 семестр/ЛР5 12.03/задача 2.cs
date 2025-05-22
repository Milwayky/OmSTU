using System;
using System.Collections.Generic;

class Calculator
{
    public void Addition(ref int number_1, int number_2)
    {
        number_1 = number_1 + number_2;
    }

    public void Subtracion(ref int number_1, int number_2)
    {
        number_1 = number_1 - number_2;
    }

    public void Multiplication(ref int number_1, int number_2)
    {
        number_1 = number_1 * number_2;
    }

    public void Division(ref int number_1, int number_2)
    {
        if (number_2 == 0)
        {
            Console.WriteLine("Деление на 0 невозможно");
            number_1 = 0;
        }
        else
        {
            number_1 = number_1 / number_2;
        }
    }
}

class Program
{
    public delegate void Operation(ref int number_1, int number_2);

    static void Main()
    {
        Calculator calculator = new Calculator();

        Console.Write("Введите первое число: ");
        int num1;
        while (!int.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Некорректный ввод. Введите целое число:");
        }

        Console.Write("Введите второе число: ");
        int num2;
        while (!int.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Некорректный ввод. Введите целое число:");
        }

        // Первая группа операций
        Operation first_group = calculator.Addition;
        first_group += calculator.Subtracion;
        first_group += calculator.Multiplication;

        Console.WriteLine("\nВыполнение первой группы операций:");
        first_group(ref num1, num2);
        Console.WriteLine($"Результат первой группы операций: {num1}");


        // Вторая группа операций

        Console.Write("\nВведите первое число для второго объекта: ");
        int num3;
        while (!int.TryParse(Console.ReadLine(), out num3))
        {
            Console.WriteLine("Некорректный ввод. Введите целое число:");
        }

        Console.Write("Введите второе число для второго объекта: ");
        int num4;
        while (!int.TryParse(Console.ReadLine(), out num4))
        {
            Console.WriteLine("Некорректный ввод. Введите целое число:");
        }

        Operation second_group = calculator.Multiplication;
        second_group += calculator.Subtracion;
        second_group += calculator.Division;

        Console.WriteLine("\nВыполнение второй группы операций:");
        second_group(ref num3, num4);
        Console.WriteLine($"Результат второй группы операций: {num3}");
    }
}
