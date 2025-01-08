using System; 
class HelloWorld  
{ 
    static void Main()  
    { 
        int len = Convert.ToInt32(Console.ReadLine()); 
        int[] massiv = new int[len]; 
     
        for (int i = 0; i < len; i++) 
        { 
            massiv[i] = Convert.ToInt32(Console.ReadLine()); 
        } 
     
        int minInd = 0; 
        int maxInd = 0; 
     
        for (int i = 0; i < len; i++) 
        { 
            if (massiv[i] < massiv[minInd]) 
            { 
                minInd = i; 
            } 
            else if (massiv[i] > massiv[maxInd]) 
            { 
                maxInd = i; 
            } 
        } 
     
        int a = massiv[minInd]; 
        massiv[minInd] = massiv[maxInd]; 
        massiv[maxInd] = a; 
     
        for (int i = 0; i < len; i++) 
        { 
            Console.Write(massiv[i] + " "); 
        } 
    } 
}
