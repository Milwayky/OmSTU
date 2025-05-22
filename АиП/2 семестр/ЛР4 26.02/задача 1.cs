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

        HashSet<int> hashset = new HashSet<int>(numbers);
        List<int> sorted_list = new List<int>(hashset);
        sorted_list.Sort();
        Console.WriteLine("Уникальные элементы списка:");
        foreach (int number in sorted_list)
        {
            Console.Write(number + " ");
        }
    }
}
