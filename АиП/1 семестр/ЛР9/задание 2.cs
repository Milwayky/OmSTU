using System;

public class HelloWorld
{
    static void Main()
    {
        string stroka = Console.ReadLine();
        char[] letters = new char[stroka.Length];
        int index_a = stroka.IndexOf('a');
	    if (index_a == -1)
	    {
    	     index_a = stroka.IndexOf('A');
	    }

	    int index_b = stroka.IndexOf('b');
	    if (index_b == -1)
	    {
	        index_b = stroka.IndexOf('B');
	    }


	    if (index_a == -1 || index_b == -1 || index_a >= index_b)
	    {
	        Console.WriteLine("Неправильный ввод");
	        return;
	    }

        int kol_vo_simvolov = 0;
        for (int i = index_a + 1; i < index_b; i++)
        {
            letters[kol_vo_simvolov] = stroka[i];
            kol_vo_simvolov += 1;
        }




        for (int i = 0; i < kol_vo_simvolov - 1; i++)
        {
            for (int j = i + 1; j < kol_vo_simvolov; j++)
            {
                if (letters[i] > letters[j])
                {
                    char letters_1 = letters[i];
                    letters[i] = letters[j];
                    letters[j] = letters_1;
                }
            }
        }








        int min_counter = int.MaxValue;
        int counter = 1;
        char current_letter = letters[0];
        char[] results = new char[kol_vo_simvolov];
        int result_count = 0;

        for (int i = 1; i < kol_vo_simvolov; i++)
        {
            if (letters[i] == current_letter)
            {
                counter++;
            }
            else
            {
                if (counter < min_counter)
                {
                    min_counter = counter;
                    result_count = 0;
                    results[result_count] = current_letter;
		    result_count += 1;
                }
                else if (counter == min_counter)
                {
                    results[result_count] = current_letter;
		    result_count += 1;
                }

                current_letter = letters[i];
                counter = 1;
            }
        }




        if (counter < min_counter)
        {
            min_counter = counter;
            result_count = 0;
            results[result_count] = current_letter;
	    result_count += 1;
        }
        else if (counter == min_counter)
        {
            results[result_count] = current_letter;
	    result_count += 1;
        }





        for (int i = 0; i < result_count; i++)
        {
            Console.Write(results[i] + " ");
        }
    }
}
