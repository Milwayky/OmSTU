using System;
class Program
{
    static void Main()
    {

        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int mmin = (a + b - Math.Abs(a - b)) / 2;
        int mmax = (a + b + Math.Abs(a - b)) / 2;
        Console.WriteLine(mmax);
        Console.WriteLine(mmin);
    }
}
