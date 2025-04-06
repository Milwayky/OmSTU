using System;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] massiv = new int[n][];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите количество элементов в строке {i + 1}: ");
            int m = Convert.ToInt32(Console.ReadLine());
            massiv[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                massiv[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        
        
        
        for (int i = 0; i < n; i++)
        {
            int mmax = massiv[i][0];
            int mmin = massiv[i][0]; 
            // ищем макс и мин
            for(int j = 0; j < massiv[i].Length; j++)
            {
                if (massiv[i][j] > mmax)
                {
                    mmax = massiv[i][j];
                }
                if (massiv[i][j] < mmin)
                {
                    mmin = massiv[i][j];
                }
            }
            // меняем местами макс и мин элементы
            for(int k = 0; k < massiv[i].Length; k++)
            {
                if (massiv[i][k] == mmax)
                {
                    massiv[i][k] = mmin;
                }
                else if (massiv[i][k] == mmin)
                {
                    massiv[i][k] = mmax;
                }
            }
        }
        
        
        Console.WriteLine("Зубчатый массив:");
        for (int i = 0; i < massiv.Length; i++)
        {
            for (int j = 0; j < massiv[i].Length; j++)
            {
                Console.Write(massiv[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
