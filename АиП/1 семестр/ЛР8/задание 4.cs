using System;

public class HelloWorld
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        string[] words = stroka.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string slovo in words)
        {
            if (slovo.ToLower().Contains('a'))
            {
                Console.Write(slovo);
                Console.Write(' ');
            }
        }
    }
}
