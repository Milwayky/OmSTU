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
        
        
        int[] massiv_zero = new int[m];
        for (int i = 0; i < m; i++)
        {
            int counter = 0;
            for (int j = 0; j < n; j++)
            {
                if (massiv[i, j] == 0)
                {
                    counter += 1;
                }
            }
            massiv_zero[i] = counter;
        }
        
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = i + 1; j < m; j++)
            {
                if (massiv_zero[i] < massiv_zero[j])
                {
                    for (int k = 0; k < n; k++)
                    {
                        int vrenemennyi_massiv = massiv[i, k];
                        massiv[i, k] = massiv[j, k];
                        massiv[j, k] = vrenemennyi_massiv;
                    }
                    int vrenemennyi_massiv_zero = massiv_zero[i];
                    massiv_zero[i] = massiv_zero[j];
                    massiv_zero[j] = vrenemennyi_massiv_zero;
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
