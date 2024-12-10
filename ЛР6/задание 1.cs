using System;
class HelloWorld 
{
  static void Main() 
  {
    int m = Convert.ToInt32(Console.ReadLine());
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] massiv = new int[m, n];
    
    
    for (int i = 0; i < m; i++) 
    {
      for (int j = 0; j < n; j++)
      {
        massiv[i, j] = Convert.ToInt32(Console.ReadLine());
      }
    }
    
    
    for (int column1 = 0; column1 < n - 1; column1++) 
        {
            for (int column2 = column1 + 1; column2 < n; column2++) 
            {
                int sum1 = 0, sum2 = 0;
                int prod1 = 1, prod2 = 1;
                int zero_counter_1 = 0, zero_counter_2 = 0;

                for (int row = 0; row < m; row++) 
                {
                    int perevemuty_massiv_1 = massiv[row, column1];
                    int perevemuty_massiv_2 = massiv[row, column2];

                    sum1 += perevemuty_massiv_1;
                    sum2 += perevemuty_massiv_2;


                    if (perevemuty_massiv_1 != 0)
                    {
                        prod1 *= perevemuty_massiv_1;
                    }
                    if (perevemuty_massiv_2 != 0)
                    {
                        prod2 *= perevemuty_massiv_2;
                    }


                    if (perevemuty_massiv_1 == 0) 
                    {
                        zero_counter_1 += 1;
                    }
                    if (perevemuty_massiv_2 == 0)
                    {
                        zero_counter_2 += 1;
                    }
                    

                }


                if ((sum1 == sum2) && (prod1 == prod2) && (zero_counter_1 == zero_counter_2)) 
                {
                    Console.WriteLine($"Совпадают столбцы: {column1 + 1} и {column2 + 1}");
                }
            }   
        }
    }
}
