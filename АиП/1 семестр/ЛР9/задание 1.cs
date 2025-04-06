using System;

public class HelloWorld
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        int maxlen = 0;
        int len = 0;
        int letter = 0;  // 0 - x, 1 - y, 2 - z
        foreach (char i in stroka)
        {
            if (letter == 0)
            {
                if (i == 'X')
                {
                    letter = 1;
                    len += 1;
                }
                else
                {
                    maxlen = Math.Max(maxlen, len);
                    len = 0;
                }
            }
            
            else if (letter == 1)
            {
                if (i == 'Y')
                {
                    letter = 2;
                    len += 1;
                }
                else if (i == 'X')
                {
                    maxlen = Math.Max(maxlen, len);
                    len = 1;
                    letter = 1;
                }
                else
                {
                    maxlen = Math.Max(maxlen, len);
                    len = 0;
                    letter = 0;
                }
            }
            
            else if (letter == 2)
            {
                if (i == 'Z')
                {
                    letter = 0;
                    len += 1;
                }
                else if (i == 'X')
                {
                    maxlen = Math.Max(maxlen, len);
                    len = 1;
                    letter = 1;
                }
                else
                {
                    maxlen = Math.Max(maxlen, len);
                    len = 0;
                    letter = 0;
                }
            }
        }
        maxlen = Math.Max(maxlen, len);
        Console.WriteLine(maxlen);
    }
}
