using System;
class HelloWorld 
{
  static void Main() 
  {
    int len = Convert.ToInt32(Console.ReadLine());
    int counter = 0;
    int[] massiv = new int[len];
    
    for (int i = 0; i < len; i++)
    {
      massiv[i] = Convert.ToInt32(Console.ReadLine());
    }
    
    for (int i = 0; i < len; i++)
    {
      if (massiv[i] % 10 == 3)
      {
        counter += 1;
      }
    }
    Console.WriteLine(counter);
  }
}
