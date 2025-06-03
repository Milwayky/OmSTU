using System;
using System.IO;

class Program
{
    static void Main()
    {
        string input_file = "input.txt";
        string output_file = "output.txt";

        if (!File.Exists(input_file))
        {
            Console.WriteLine("Файл input.txt не найден.");
            return;
        }

        string[] lines = File.ReadAllLines(input_file);
        StreamWriter writer = new StreamWriter(output_file);

        foreach (string line in lines)
        {
            string number = "";
            bool found_odd = false;

            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    if (number != "")
                    {
                        int n = int.Parse(number);
                        if (n % 2 == 1)
                        {
                            found_odd = true;
                            break;
                        }
                        number = "";
                    }
                }
            }


            if (!found_odd && number != "")
            {
                int n = int.Parse(number);
                if (n % 2 == 1)
                    found_odd = true;
            }

            if (found_odd)
                writer.WriteLine(line);
        }

        writer.Close();
        Console.WriteLine("Результат в output.txt");
    }
}
