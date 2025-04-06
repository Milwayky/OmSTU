using System;

public class HelloWorld
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        string[] words = stroka.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int counter = 0;

        foreach (string slovo in words)
        {
            if (slovo.Length % 2 != 0)
            {
                if (slovo.ToLower(slovo[0]) == slovo.ToLower(slovo[slovo.Length - 1]))
                {
                    counter += 1;
                }
            }
        }
        Console.WriteLine(counter);
    }
}
