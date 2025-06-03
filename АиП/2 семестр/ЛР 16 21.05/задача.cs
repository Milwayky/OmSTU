using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите длину массива: ");
        int length = Convert.ToInt32(Console.ReadLine());

        unsafe
        {
            int* array = stackalloc int[length];

            for (int i = 0; i < length; i++)
            {
                Console.Write($"Введите элемент с индексом {i}: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Палиндромы из массива:");

            for (int i = 0; i < length; i++)
            {
                int num = array[i];
                int original = num;
                int reversed = 0;

                while (num > 0)
                {
                    int digit = num % 10;
                    reversed = reversed * 10 + digit;
                    num /= 10;
                }

                if (original == reversed)
                {
                    Console.WriteLine(original);
                }
            }
        }
    }
}
