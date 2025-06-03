using System;
using System.Collections.Generic;
using System.Linq;

class Phone
{
    public uint phone_number { get; set; }
    public string owner { get; set; }
    public uint year { get; set; }
    public string mobile_operator { get; set; }

    public Phone(uint phone_number, string owner, uint year, string mobile_operator)
    {
        this.phone_number = phone_number;
        this.owner = owner;
        this.year = year;
        this.mobile_operator = mobile_operator;
    }
}

class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>
        {
            new Phone(880055535, "Иванов", 2020, "МТС"),
            new Phone(888888888, "Петров", 2021, "Билайн"),
            new Phone(777777777, "Сидоров", 2020, "МегаФон"),
            new Phone(666666666, "Козлов", 2022, "МТС"),
            new Phone(123, "Смирнова", 2021, "МегаФон"),
            new Phone(987654111, "Лебедев", 2023, "Tele2"),
            new Phone(888845534, "Фёдоров", 2020, "МТС"),
            new Phone(890909090, "Матвеев", 2023, "Билайн")
        };

        while (true)
        {
            Console.WriteLine("\nВыберите запрос:");
            Console.WriteLine("1. Выдать все телефоны по заданному оператору связи");
            Console.WriteLine("2. Выдать данные по телефонам за заданный год");
            Console.WriteLine("3. Выдать все данные, сгрупированные по оператору связи");
            Console.WriteLine("4. Выдать все данные, сгрупированные по году выпуска");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер команды: ");

            string option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    Console.Write("Введите оператора связи: ");
                    string op = Console.ReadLine();
                    var by_operator = from p in phones
                                      where p.mobile_operator == op
                                      select p;
                    foreach (var phone in by_operator)
                        Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.year}, {phone.mobile_operator}");
                    break;

                case "2":
                    Console.Write("Введите год выпуска: ");
                    if (uint.TryParse(Console.ReadLine(), out uint year))
                    {
                        var by_year = from p in phones
                                      where p.year == year
                                      select p;
                        foreach (var phone in by_year)
                            Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.year}, {phone.mobile_operator}");
                    }
                    else
                        Console.WriteLine("Неверный формат года.");
                    break;

                case "3":
                    var grouped_by_operator = from p in phones
                                              group p by p.mobile_operator into g
                                              select g;

                    foreach (var group in grouped_by_operator)
                    {
                        Console.WriteLine($"\nОператор: {group.Key}");
                        foreach (var phone in group)
                            Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.year}, {phone.mobile_operator}");
                    }
                    break;

                case "4":
                    var grouped_by_year = from p in phones
                                          group p by p.year into g
                                          select g;

                    foreach (var group in grouped_by_year)
                    {
                        Console.WriteLine($"\nГод: {group.Key}");
                        foreach (var phone in group)
                            Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.year}, {phone.mobile_operator}");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }
}
