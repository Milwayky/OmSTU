using System;

public class Calculator
{
    private int number_1;
    private int number_2;


    public Calculator()
    {
        number_1 = 0;
        number_2 = 0;
    }


    public Calculator(int numb_1)
    {
        number_1 = numb_1;
        number_2 = 0;
    }


    public Calculator(int numb_1, int numb_2)
    {
        number_1 = numb_1;
        number_2 = numb_2;
    }


    public int Addition()
    {
        return number_1 + number_2;
    }


    public int Subtraction()
    {
        return number_1 - number_2;
    }


    public int Multiplication()
    {
        return number_1 * number_2;
    }


    public void Dividing()
    {
        if (number_2 == 0)
            Console.WriteLine("Ошибка: деление на ноль невозможно");
        else
        {
            double result = (double)number_1 / number_2;
            Console.WriteLine(result);
        }
    }
}

public class Result
{
    static void Main()
    {

        Calculator constructor_1 = new Calculator();
        Console.WriteLine("Конструктор 1:");
        Console.WriteLine("Сложение: " + constructor_1.Addition());
        Console.WriteLine("Разность: " + constructor_1.Subtraction()); 
        Console.WriteLine("Умножение: " + constructor_1.Multiplication());
        Console.Write("Деление: ");
        constructor_1.Dividing();
        Console.WriteLine();


        Console.WriteLine("Введите значение 1 для конструктора 2:");
        int number_1_constructor_2 = Convert.ToInt32(Console.ReadLine());
        Calculator constructor_2 = new Calculator(number_1_constructor_2);
        Console.WriteLine("Конструктор 2:");
        Console.WriteLine("Сложение: " + constructor_2.Addition());
        Console.WriteLine("Разность: " + constructor_2.Subtraction());
        Console.WriteLine("Умножение: " + constructor_2.Multiplication());
        Console.Write("Деление: ");
        constructor_2.Dividing();
        Console.WriteLine();


        Console.WriteLine("Введите значение 1 для конструктора 3:");
        int number_1_constructor_3 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите значение 2 для конструктора 3:");
        int number_2_constructor_3 = Convert.ToInt32(Console.ReadLine());
        Calculator constructor_3 = new Calculator(number_1_constructor_3, number_2_constructor_3);
        Console.WriteLine("Конструктор 3:");
        Console.WriteLine("Сложение: " + constructor_3.Addition());
        Console.WriteLine("Разность: " + constructor_3.Subtraction());
        Console.WriteLine("Умножение: " + constructor_3.Multiplication());
        Console.Write("Деление: ");
        constructor_3.Dividing();
    }
}
