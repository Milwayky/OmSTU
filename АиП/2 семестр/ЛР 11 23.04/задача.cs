using System;
using System.Collections.Generic;

struct Book
{
    public string author;
    public string name_of_book;
    public int year;
    public string publisher;

    public Book(string author, string name_of_book, int year, string publisher)
    {
        this.author = author;
        this.name_of_book = name_of_book;
        this.year = year;
        this.publisher = publisher;
    }
}

struct Form
{
    public Book book;
    public string issue_date;
    public string return_date; 
    public Form(Book book, string issue_date, string return_date)
    {
        this.book = book;
        this.issue_date = issue_date;
        this.return_date = return_date;
    }
}

class Program
{
    static List<Book> books;
    static List<Form> formularies;
    static void Main()
    {
        books = new List<Book>();
        formularies = new List<Form>();

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Показать книги, которые ни разу не выдавались");
            Console.WriteLine("3. Показать книги, которые не сданы");
            Console.WriteLine("4. Выход");
            Console.Write("Введите номер пункта: ");

            string input = Console.ReadLine();

            if (input == "4") break;

            switch (input)
            {
                case "1":
                    Console.Write("Автор: ");
                    string author = Console.ReadLine();
                    Console.Write("Название книги: ");
                    string name = Console.ReadLine();
            
                    Console.Write("Год выпуска: ");
                    int year;
                    while (!int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.Write("Введите корректный год: ");
                    }

                    Console.Write("Издательство: ");
                    string publisher = Console.ReadLine();

                    var new_book = new Book(author, name, year, publisher);
                    books.Add(new_book);
                    Console.WriteLine("Книга добавлена!");

                    Console.WriteLine("====Заполнение формуляра====");
                    Console.Write("Дата выдачи (например, 11.01.2001): ");
                    string issue_date = Console.ReadLine();

                    Console.Write("Дата возврата (оставьте пустым, если не сдана): ");
                    string return_date = Console.ReadLine();

                    formularies.Add(new Form(new_book, issue_date, return_date));
                    Console.WriteLine("Формуляр добавлен!");

                    break;




                case "2":
                    Console.WriteLine("Книги, которые ни разу не выдавались:");
                    bool found = false;
                    foreach (var book in books)
                    {
                        bool issued = false;
                        foreach (var form in formularies)
                        {
                            if (form.book.name_of_book == book.name_of_book && 
                                form.book.author == book.author &&
                                !string.IsNullOrWhiteSpace(form.issue_date))
                            {
                                issued = true;
                                break;
                            }
                        }
                        if (!issued)
                        {
                            Console.WriteLine($"{book.author} - \"{book.name_of_book}\" ({book.year}), {book.publisher}");
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Таких книг нет.");
                    }
                    break;



                case "3":
                    Console.WriteLine("Книги, которые не сданы:");

                    bool books_not_returned = false;

                    foreach (var form in formularies)
                    {
                        if (string.IsNullOrWhiteSpace(form.return_date))
                        {
                            Console.WriteLine($"{form.book.author} - \"{form.book.name_of_book}\" ({form.book.year}), {form.book.publisher} | Выдана: {form.issue_date}");
                            books_not_returned = true;
                        }
                    }

                    if (!books_not_returned)
                    {
                        Console.WriteLine("Все книги возвращены.");
                    }
                    break;


                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова");
                    break;
            }
        }
    }
}
