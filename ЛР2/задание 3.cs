using System;
class Program
{
    static void Main()
    {
        int counterNechet = 0;
        int n = Convert.ToInt32(Console.ReadLine());
        int mmax1 = 0;
        int mmax2 = 0;
        for (int i = 0; i < n; i++)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            if (i == 0)
            {
                mmax2 = a;
                mmax1 = a;
            }
            else if (a > mmax1)
            {
                mmax2 = mmax1;
                mmax1 = a;
            }
            else if (a > mmax2 && a < mmax1) 
            {
                mmax2 = a;
            }
     
        }
        Console.WriteLine(mmax2);
    }
}
