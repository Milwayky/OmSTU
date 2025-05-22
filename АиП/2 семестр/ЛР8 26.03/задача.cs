using System;

class Participant
{
    public string name { get; set; }
    public int speed { get; set; }
    public int distance { get; private set; }
    public Participant(string name, int speed)
    {
        this.name = name;
        this.speed = speed;
        distance = 0;
    }

    public void Move(int time_interval)
    {
        distance += speed * time_interval;
    }

    private static Random rand = new Random();
    public void Change_speed(int min_speed, int max_speed)
    {
        speed = rand.Next(min_speed, max_speed + 1);
        Console.WriteLine($"{name} изменил скорость на {speed}");
    }

    public void Print_status()
    {
        Console.WriteLine($"Имя: {name}, Скорость: {speed}, Расстояние: {distance}");
    }
}


class Program
{
    static void Check_winner(Participant[] participants, int finish_line)
    {
        bool has_winner = false;

        foreach (var participant in participants)
        {
            if (participant.distance >= finish_line)
            {
                Console.WriteLine($"{participant.name} пересёк финишную линию!");
                has_winner = true;
            }
        }

        if (!has_winner)
        {
            Console.WriteLine("Никто ещё не достиг финиша.");
        }
    }

    static void Main()
    {
        Console.Write("Введите дистанцию до финиша: ");
        int finish_line = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите интервал времени (сек): ");
        int time_interval = Convert.ToInt32(Console.ReadLine());

        Participant[] participants = new Participant[3];
        for (int i = 0; i < participants.Length; i++)
        {
            Console.Write($"\nВведите имя участника {i + 1}: ");
            string name = Console.ReadLine();

            Console.Write($"Введите начальную скорость участника {i + 1}: ");
            int speed = Convert.ToInt32(Console.ReadLine());

            participants[i] = new Participant(name, speed);
        }
        Console.WriteLine("\nНачальные данные участников:");

        foreach (var participant in participants)
        {
            participant.Print_status();
        }


        Console.WriteLine("\n--- Гонка началась! ---\n");
        bool race_over = false;

        while (!race_over)
        {
            foreach (var participant in participants)
            {
                participant.Move(time_interval);
                participant.Print_status();
            }

            Console.WriteLine("\n--- Проверка на пересечение финиша ---");

            race_over = false;

            foreach (var participant in participants)
            {
                if (participant.distance >= finish_line)
                {
                    Console.WriteLine($"Участник с именем {participant.name} пересёк финишную линию!");
                    race_over = true;
                }
            }
            
            if (!race_over)
            {
                Console.WriteLine("\n--- Смена скорости участников ---");
                foreach (var participant in participants)
                {
                    participant.Change_speed(3, 25);
                }
                Console.WriteLine();
            }

        }


    }
}
