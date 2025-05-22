using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Вводите целые числа по одному. Введите нецелочисленный элемент для завершения ввода");
        while(true)
        {
            Console.Write("Введите число: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Ввод завершён.");
                break;
            }
        }

        Dictionary<int, int> lst = new Dictionary<int, int>();
        int counter = 0;
        foreach (int number in numbers)
        {
            if (lst.ContainsKey(number))
            {
                lst[number] += 1;
                if (lst[number] > counter)
                {
                    counter = lst[number];
                }
            }
            else
            {
                lst[number] = 1;
            }
        }

        Console.WriteLine("\nЭлементы с наибольшей частотой появления:");
        foreach (var frequency in lst)
        {
            if (frequency.Value == counter)
            {
                Console.WriteLine($"Элемент {frequency.Key} встречается {frequency.Value} раз(а)");
            }
        }
    }
}
