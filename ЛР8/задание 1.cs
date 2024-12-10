using System;

public class HelloWorld
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        string[] words = stroka.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        foreach (string slovo in words)
        {
            Console.Write(slovo);
            Console.Write(' ');
        }

    }
}
