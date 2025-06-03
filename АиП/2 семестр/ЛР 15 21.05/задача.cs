using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int product_id { get; set; }
    public string name { get; set; }

    public Product(int product_id, string name)
    {
        this.product_id = product_id;
        this.name = name;
    }
}

class Supplier
{
    public int supplier_id { get; set; }
    public string name { get; set; }
    public string phone { get; set; }

    public Supplier(int supplier_id, string name, string phone)
    {
        this.supplier_id = supplier_id;
        this.name = name;
        this.phone = phone;
    }
}

class Transaction
{
    public int product_id { get; set; }
    public int? supplier_id { get; set; }
    public string operation_type { get; set; }
    public int quantity { get; set; }
    public uint price { get; set; }
    public string date { get; set; }

    public Transaction(int product_id, int? supplier_id, string operation_type, int quantity, uint price, string date)
    {
        this.product_id = product_id;
        this.supplier_id = supplier_id;
        this.operation_type = operation_type;
        this.quantity = quantity;
        this.price = price;
        this.date = date;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product(1, "Телевизор"),
            new Product(2, "Холодильник"),
            new Product(3, "Микроволновка"),
        };

        List<Supplier> suppliers = new List<Supplier>
        {
            new Supplier(1, "Поставщик А", "8 900 000 0001"),
            new Supplier(2, "Поставщик Б", "8 900 000 0002")
        };

        List<Transaction> transactions = new List<Transaction>
        {
            new Transaction(1, 1, "поставка", 10, 20000, "10.01.2025"),
            new Transaction(1, null, "продажа", 4, 25000, "15.01.2025"),
            new Transaction(2, 2, "поставка", 5, 30000, "20.01.2025"),
            new Transaction(2, null, "продажа", 2, 35000, "01.02.2025"),
            new Transaction(3, 1, "поставка", 7, 15000, "10.02.2025"),
            new Transaction(3, null, "продажа", 3, 20000, "15.02.2025"),
            new Transaction(1, 1, "поставка", 3, 21000, "01.03.2025"),
            new Transaction(1, null, "продажа", 2, 26000, "10.03.2025"),
            new Transaction(2, 2, "списание", 1, 0, "12.03.2025")
        };

        while (true)
        {
            Console.WriteLine("\nВыберите запрос:");
            Console.WriteLine("1. Выручка за интервал времени");
            Console.WriteLine("2. Остатки на складе по каждому товару");
            Console.WriteLine("3. Списание товаров (отправлено обратно), отсортировано по товару");
            Console.WriteLine("4. Поставки, отсортированные по поставщику");
            Console.WriteLine("5. Продажи товаров, отсортированные по дате продажи");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер команды: ");

            string option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    Console.Write("Введите начальную дату (дд.мм.гггг): ");
                    string start_date = Console.ReadLine();
                    Console.Write("Введите конечную дату (дд.мм.гггг): ");
                    string end_date = Console.ReadLine();

                    var revenue = transactions
                        .Where(t => t.operation_type == "продажа" && String.Compare(t.date, start_date) >= 0 && String.Compare(t.date, end_date) <= 0)
                        .Sum(t => t.quantity * t.price);

                    Console.WriteLine($"Выручка за период с {start_date} по {end_date}: {revenue} руб.");
                    break;

                case "2":
                    var stock_balances = from p in products
                                         let supplies = transactions.Where(t => t.product_id == p.product_id && t.operation_type == "поставка").Sum(t => t.quantity)
                                         let sales = transactions.Where(t => t.product_id == p.product_id && t.operation_type == "продажа").Sum(t => t.quantity)
                                         let write_offs = transactions.Where(t => t.product_id == p.product_id && t.operation_type == "списание").Sum(t => t.quantity)
                                         select new { product_name = p.name, balance = supplies - sales - write_offs };

                    foreach (var item in stock_balances)
                        Console.WriteLine($"{item.product_name}: Остаток = {item.balance}");
                    break;

                case "3":
                    var write_offs_sorted = from t in transactions
                                            where t.operation_type == "списание"
                                            orderby products.First(p => p.product_id == t.product_id).name
                                            select new
                                            {
                                                product_name = products.First(p => p.product_id == t.product_id).name,
                                                quantity = t.quantity,
                                                date = t.date
                                            };

                    foreach (var item in write_offs_sorted)
                        Console.WriteLine($"{item.product_name}: Списано {item.quantity} шт, дата {item.date}");
                    break;

                case "4":
                    var supplies_by_supplier = from t in transactions
                                               where t.operation_type == "поставка"
                                               group t by t.supplier_id into g
                                               join s in suppliers on g.Key equals s.supplier_id
                                               orderby s.name
                                               select new { supplier_name = s.name, supplies = g };

                    foreach (var group in supplies_by_supplier)
                    {
                        Console.WriteLine($"\nПоставщик: {group.supplier_name}");
                        foreach (var t in group.supplies)
                        {
                            var product_name = products.First(p => p.product_id == t.product_id).name;
                            Console.WriteLine($"  {product_name}: {t.quantity} шт, цена {t.price}, дата {t.date}");
                        }
                    }
                    break;

                case "5":
                    var sales_by_date = from t in transactions
                                        where t.operation_type == "продажа"
                                        orderby t.date
                                        select new
                                        {
                                            date = t.date,
                                            product_name = products.First(p => p.product_id == t.product_id).name,
                                            quantity = t.quantity,
                                            price = t.price
                                        };

                    foreach (var item in sales_by_date)
                        Console.WriteLine($"{item.date}: {item.product_name}, {item.quantity} шт, цена {item.price}");
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
