using System;
using System.Collections.Generic;

class Car
{
    public string brand { get; set; }
    public string owner_name { get; set; }
    public int year { get; set; }
    public bool is_clean { get; set; }
    public Car(string brand, string owner_name, int year, bool is_clean)
    {
        this.brand = brand;
        this.owner_name = owner_name;
        this.year = year;
        this.is_clean = is_clean;
    }
}

class Garage
{
    public List<Car> cars { get; set; }
    public Garage(List<Car> cars)
    {
        this.cars = cars;
    }
}

class Car_Wash
{
    public static void WashCar(Car car)
    {
        if (car.is_clean == true)
        {
        
            Console.WriteLine($"{car.brand} {car.year} года выпуска уже чистая.");
        }
        else
        {
            car.is_clean = true;
            Console.WriteLine($"{car.brand} {car.year} года выпуска теперь помыта.");
        }
    }
}

class Program
{
    delegate void CarWashDelegate(Car car);
    static void Main()
    {
        List<Car> cars = new List<Car>();
        Console.Write("Введите количество машин: ");
        int number_of_cars;
        while (!int.TryParse(Console.ReadLine(), out number_of_cars) || number_of_cars <= 0)
        {
            Console.Write("Введите корректное количество машин: ");
        }
        for (int i = 0; i < number_of_cars; i++)
        {
            Console.WriteLine($"Ввод данных машины с номером {i+1}");
            Console.Write("Введите марку автомобиля: ");
            string brand = Console.ReadLine();

            Console.Write("Введите ФИО владельца: ");
            string owner_name = Console.ReadLine();

            Console.Write("Введите год выпуска автомобиля: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Машина помыта? (Введите 'да' или 'нет'): ");
            string temp = Console.ReadLine();
            temp = temp.ToLower();
            bool is_clean = false;
            if (temp == "да")
            {
                is_clean = true;
            }
            Car car = new Car(brand, owner_name, year, is_clean);
            cars.Add(car);
            Console.WriteLine();
        }

        Garage garage = new Garage(cars);
        CarWashDelegate carWashDelegate = Car_Wash.WashCar;

        foreach (Car car in garage.cars)
        {
            carWashDelegate(car);
        }
    }
}
