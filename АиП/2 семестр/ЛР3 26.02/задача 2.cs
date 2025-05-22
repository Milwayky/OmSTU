using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите постфиксное выражение: ");
        string? str = Console.ReadLine();
        if (str == null)
        {
            Console.WriteLine("Введена пустая строка");
            return;
        }
        string[] elements = str.Split(' ');
        Stack<int> st = new Stack<int>();
        foreach (var element in elements)
        {
            if (int.TryParse(element, out int number))
            {
                st.Push(number);
            }
            else if (element == "+" || element == "-" || element == "*" || element == "/")
            {
                if (st.Count < 2)
                {
                    Console.WriteLine("Неверная запись");
                    return;
                }
                int number_1 = st.Pop();
                int number_2 = st.Pop();
                int result = 0;


                switch(element)
                {
                    case "+":
                        result = number_2 + number_1;
                        break;
                    case "*":
                        result = number_2 * number_1;
                        break;
                    case "-":
                        result = number_2 - number_1;
                        break;
                    case "/":
                        if (number_1 == 0)
                        {
                            Console.WriteLine("Деление на 0 невозможно");
                            Console.WriteLine("Неверная запись");
                            return;
                        }
                        result = number_2 / number_1;
                        break;
                }
                st.Push(result);
            }
            else
            {
                Console.WriteLine("Неверная запись");
                return;
            }
        }
        
        if (st.Count == 1)
        {
            Console.WriteLine($"Результат: {st.Pop()}");
        }
        else
        {
            Console.WriteLine("Неверная запись");
        }
    }
}
