using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите математическое выражение: ");
        string? str = Console.ReadLine();
        if (str == null)
        {
            Console.WriteLine("Введена пустая строка");
            return;
        }

        Stack<char> st = new Stack<char>();
        bool check = true;

        foreach (char i in str)
        {
            if (i == '{' || i == '[' || i == '(')
            {
                st.Push(i);
            }
            else if (i == '}' || i == ']' || i == ')')
            {
                if (st.Count == 0)
                {
                    check = false;
                    break;
                }
                else
                {
                    char open_bracket = st.Pop();
                    if ((i == '}' && open_bracket == '{') || 
                        (i == ')' && open_bracket == '(') || 
                        (i == ']' && open_bracket == '['))
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }
        }

        if (st.Count > 0)
        {
            check = false;
        }

        if (check)
        {
            Console.WriteLine("Скобки расставлены верно");
        }
        else
        {
            Console.WriteLine("Неверно расставлены скобки");
        }
    }
}
