using System;

class Program
{
    static void Main()
    {
        int counterNechet = 0;
        int n = Convert.ToInt32(Console.ReadLine());
        int counter5 = 0;
        for (int i = 0; i < n; i++)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            if (Math.Abs(a) % 10 == 5)
            {
            counter5 += 1 ;
            }
        
        }
        Console.WriteLine(counter5);
    }
}
