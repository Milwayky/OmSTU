//определить минимальный размер подпоследовательнсости состоящий из единичек
using System;
class HelloWorld
{
    static void Main() 
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int Mmin = n + 1;
        int Counter1 = 0;
        for (int i = 0; i < n; i++)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                Counter1 += 1;
            }
            else
            {
                if (Counter1 > 0)
                {
                    Mmin = Math.Min(Mmin, Counter1);
                    Counter1 = 0;
                }
            }
        }
        if (Counter1 > 0)
        {
            Mmin = Math.Min(Mmin, Counter1);
            Counter1 = 0;
        }
        Console.WriteLine(Mmin);
    }
}
