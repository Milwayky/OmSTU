using System;

public class Phone
{
    public int number { get; set; }
    public string mobile_operator { get; set; }
    public int date { get; set; }

    public Phone(int number, string mobile_operator, int date)
    {
        this.number = number;
        this.mobile_operator = mobile_operator;
        this.date = date;
    }

    public void Print()
    {
        Console.WriteLine("Номер телефона: " + number);
        Console.WriteLine("Оператор мобильной связи: " + mobile_operator);
        Console.WriteLine("Год заключения договора: " + date);
    }
}

public class Person
{
    public string name { get; set; }
    public string city { get; set; }
    public Phone[] phones;

    public Person(string name, string city, Phone[] phones)
    {
        this.name = name;
        this.city = city;
        this.phones = phones;
    }

    public void Print()
    {
        Console.WriteLine("ФИО: " + name);
        Console.WriteLine("Город: " + city);
        Console.WriteLine("Телефоны:");
    }
}

public class Program
{
    public static void Search_by_name(Person[] persons, string name)
    {
        bool needed_name = false;
        foreach (var person in persons)
        {
            if (name == person.name)
            {
                person.Print();
                foreach (var phone in person.phones)
                {
                    phone.Print();
                    Console.WriteLine("-----");
                }
                Console.WriteLine("==========");
                needed_name = true;
            }
        }
        if (!needed_name)
        {
            Console.WriteLine("С данным именем никого не найдено");
        }
    }

    public static void Search_by_city(Person[] persons, string city)
    {
        bool needed_city = false;
        foreach (var person in persons)
        {
            if (city == person.city)
            {
                person.Print();
                foreach (var phone in person.phones)
                {
                    phone.Print();
                    Console.WriteLine("-----");
                }
                Console.WriteLine("==========");
                needed_city = true;
            }
        }
        if (!needed_city)
        {
            Console.WriteLine("В этом городе никого не найдено");
        }
    }

    public static void Search_by_operator(Person[] persons, string mobile_operator_name)
    {
        bool found = false;

        foreach (var person in persons)
        {
            bool person_printed = false;

            foreach (var phone in person.phones)
            {
                if (phone.mobile_operator == mobile_operator_name)
                {
                    if (!person_printed)
                    {
                        person.Print();
                        person_printed = true;
                    }
                    phone.Print();
                    Console.WriteLine("-----");
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("С данным оператором связи никого не найдено");
        }
    }

    public static void Search_by_phone_number(Person[] persons, int phone_number)
    {
        bool found = false;

        foreach (var person in persons)
        {
            bool person_printed = false;

            foreach (var phone in person.phones)
            {
                if (phone.number == phone_number)
                {
                    if (!person_printed)
                    {
                        person.Print();
                        person_printed = true;
                    }
                    phone.Print();
                    Console.WriteLine("-----");
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("С данным номером телефона никого не найдено");
        }
    }

    public static void Search_by_year(Person[] persons, int year)
    {
        bool found = false;

        foreach (var person in persons)
        {
            bool person_printed = false;

            foreach (var phone in person.phones)
            {
                if (phone.date == year)
                {
                    if (!person_printed)
                    {
                        person.Print();
                        person_printed = true;
                    }
                    phone.Print();
                    Console.WriteLine("-----");
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("С данным годом никого не найдено");
        }
    }

    public static void Main()
    {
        Person[] persons = new Person[]
        {
            new Person("Alice", "New York", new Phone[]
            {
                new Phone(123456789, "OperatorA", 2021),
                new Phone(987654321, "OperatorB", 2022)
            }),
            new Person("Bob", "Los Angeles", new Phone[]
            {
                new Phone(111111111, "OperatorA", 2023),
                new Phone(222222222, "OperatorC", 2021)
            })
        };

        Console.WriteLine("Поиск по имени 'Alice':");
        Search_by_name(persons, "Alice");
        Console.WriteLine();

        Console.WriteLine("Поиск по городу 'Los Angeles':");
        Search_by_city(persons, "Los Angeles");
        Console.WriteLine();

        Console.WriteLine("Поиск по оператору 'OperatorA':");
        Search_by_operator(persons, "OperatorA");
        Console.WriteLine();

        Console.WriteLine("Поиск по номеру '123456789':");
        Search_by_phone_number(persons, 123456789);
        Console.WriteLine();

        Console.WriteLine("Поиск по году '2021':");
        Search_by_year(persons, 2021);
    }
}
