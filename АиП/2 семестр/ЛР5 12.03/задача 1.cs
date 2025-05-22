using System;
using System.Collections.Generic;

class Phone
{
    public string? phone_number { get; set; }
    public string? mobile_operator { get; set; }
}

class Program
{
    static void Main()
    {
        List<Phone> phone_book = new List<Phone>();
        while (true)
        {
            Console.Write("Введите номер телефона и мобильный оператор через пробел (или нажмите Enter для завершения): ");
            string? str = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(str))
                break;

            string[] phone_array = str.Split(' ');

            if (phone_array.Length == 2)
            {
                Phone entry = new Phone
                {
                    phone_number = phone_array[0],
                    mobile_operator = phone_array[1]
                };
                phone_book.Add(entry);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите номер и оператор через пробел.");
            }
        }


        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (Phone entry in phone_book)
        {
            string? mobile_operator = entry.mobile_operator;

            if (dict.ContainsKey(mobile_operator))
            {
                dict[mobile_operator] += 1;
            }
            else
            {
                dict.Add(mobile_operator, 1);
            }
        }
        
        Console.WriteLine("\nКоличество телефонов у каждого оператора:");
        foreach (var entry in dict)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

    }
}
