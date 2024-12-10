using System;
class HelloWorld
{
  static void Main() 
  {
    int len = Convert.ToInt32(Console.ReadLine());
    if (len < 3) Console.WriteLine("Слишком мало элементов в массиве");
    bool ravnomernostVozrastania = true;
    bool ravnomernostUbyvania = true;
    
    int[] massiv = new int[len];
    
    for (int i = 0; i < len; i++)
    {
      massiv[i] = Convert.ToInt32(Console.ReadLine());
    }
    
    for (int i = 2; i < len; i++)
    {
      if ((massiv[i-1] - massiv[i-2]) != (massiv[i] - massiv[i-1]))
      {
        ravnomernostVozrastania = false;
        break;
      }
    }
    
    for (int i = 2; i < len; i++)
    {
      if ((massiv[i-2] - massiv[i-1]) != (massiv[i-1] - massiv[i]))
      {
        ravnomernostUbyvania = false;
      }
    }
    
    
    
    
    if (ravnomernostVozrastania == true && ravnomernostUbyvania == false)
    {
      Console.WriteLine("равномерновозрастающая последовательность");
    }
    else
    {
      Console.WriteLine("НЕравномерновозрастающая последовательность");
    }
  }
}
