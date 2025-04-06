using System;

public class HelloWorld
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        int counter = 0;
        string[] words = stroka.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string slovo in words)
        {
            bool proverka = true;
        
            for (int i = 1; i < slovo.Length; i += 2) 
            {
                if (!"aeiouyAEIOUY".Contains(slovo[i]))
                {
                    proverka = false;
                    break;
                }
            }

            if (proverka)
            {
                counter += 1;
            }
        }
        
        Console.WriteLine(counter);
    }
}
