using System;

class Program
{
    static void Main()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        while (a > 0)
        {
            int n = 0;
            bool Chet = false;
            while (a != 0)
            {
                int LastDigit = a % 10;
                
                if (LastDigit % 2 == 0)
                {
                    n = n * 10 + (a % 10);
                    Chet = true;
                }
                a = a / 10;
            }
            
            if (Chet == false)
            {
                Console.WriteLine("Чётных цифр в числе нет");
            }
            
            else
            {
                if (n == 0)
                    {
                        Console.WriteLine(n);
                    }
                if (n != 0)
                {
                    Console.WriteLine(n);
                }
            }
            a = Convert.ToInt32(Console.ReadLine());
            
        }
    }
}
