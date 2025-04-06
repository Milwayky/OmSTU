using System;
public class HelloWorld
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        string[] words = stroka.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        string result = string.Join(" ", words);
        Console.WriteLine(result);

    }
}
