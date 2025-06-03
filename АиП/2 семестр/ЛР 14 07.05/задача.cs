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
            new Transaction(1, null, "продажа", 2, 26000, "10.03.2025")
        };

        while (true)
        {
            Console.WriteLine("\nВыберите запрос:");
            Console.WriteLine("1. Остатки по каждому товару");
            Console.WriteLine("2. Поставки товаров по поставщикам");
            Console.WriteLine("3. Продажи товаров по дате");
            Console.WriteLine("4. Общая выручка от продаж");
            Console.WriteLine("5. Поставщик с максимальной поставкой");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер команды: ");

            string option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    var stock_balances = from p in products
                                         let supplies = transactions.Where(t => t.product_id == p.product_id && t.operation_type == "поставка").Sum(t => t.quantity)
                                         let sales = transactions.Where(t => t.product_id == p.product_id && t.operation_type == "продажа").Sum(t => t.quantity)
                                         select new { product_name = p.name, balance = supplies - sales };

                    foreach (var item in stock_balances)
                        Console.WriteLine($"{item.product_name}: Остаток = {item.balance}");
                    break;

                case "2":
                    var supplies_by_supplier = from t in transactions
                                               where t.operation_type == "поставка"
                                               group t by t.supplier_id into g
                                               join s in suppliers on g.Key equals s.supplier_id
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

                case "3":
                    var sales_by_date = from t in transactions
                                        where t.operation_type == "продажа"
                                        group t by t.date into g
                                        select g;

                    foreach (var group in sales_by_date)
                    {
                        Console.WriteLine($"\nДата: {group.Key}");
                        foreach (var t in group)
                        {
                            var product_name = products.First(p => p.product_id == t.product_id).name;
                            Console.WriteLine($"  {product_name}: {t.quantity} шт, цена {t.price}");
                        }
                    }
                    break;

                case "4":
                    var total_revenue = transactions
                                        .Where(t => t.operation_type == "продажа")
                                        .Sum(t => t.quantity * t.price);

                    Console.WriteLine($"Общая выручка от продаж: {total_revenue} руб.");
                    break;

                case "5":
                    var max_supplier = transactions
                                        .Where(t => t.operation_type == "поставка")
                                        .GroupBy(t => t.supplier_id)
                                        .Select(g => new
                                        {
                                            supplier_id = g.Key,
                                            total_quantity = g.Sum(t => t.quantity)
                                        })
                                        .OrderByDescending(x => x.total_quantity)
                                        .FirstOrDefault();

                    if (max_supplier != null)
                    {
                        var supplier = suppliers.First(s => s.supplier_id == max_supplier.supplier_id);
                        Console.WriteLine($"Поставщик с максимальной поставкой: {supplier.name} — {max_supplier.total_quantity} шт.");
                    }
                    else
                    {
                        Console.WriteLine("Данные о поставках отсутствуют.");
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
