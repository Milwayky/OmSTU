using System;
class HelloWorld 
{
    static void Main() 
    {
        int m = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] massiv = new int[m, n];
    
        int mmax = 0, mmin = n + 1;
        for (int i = 0; i < m; i++) 
        {
            for (int j = 0; j < n; j++)
            {
                massiv[i, j] = Convert.ToInt32(Console.ReadLine());
                
                
                if (massiv[i, j] > mmax)
                {
                    mmax = massiv[i, j];
                }
                if (massiv[i, j] < mmin)
                {
                    mmin = massiv[i, j];
                }
            }
        }
        
        
        for (int i = 0; i < m; i++) 
        {
            for (int j = 0; j < n; j++)
            {
                if (massiv[i, j] == mmax)
                {
                    massiv[i, j] = mmin;
                }
                else if (massiv[i, j] == mmin)
                {
                    massiv[i, j] = mmax;
                }
            }
        }
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{massiv[i, j]} \t");
            }
                Console.WriteLine();
        }

        
    }
}
