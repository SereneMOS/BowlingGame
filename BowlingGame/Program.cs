using System;

namespace BowlingGame
{
    class Program
    {
        static void Main()
        {
            bool playing = true;
            while (playing)
            {
                string are_we_rand = "";
                while (are_we_rand != "I" && are_we_rand != "R")
                {
                    Console.WriteLine("Would you like to use random rolls or input rolls? (R/I)");
                    are_we_rand = Console.ReadLine();
                }
                Console.Clear();
                int total_score = 0;
                int[] roll_1 = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                int[] roll_2 = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                int[] frame_score = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int roll_3 = 0;
                for (int i = 0; i < 10; i++)
                {
                    Random rd = new Random();
                    if (are_we_rand == "I")
                    {
                        string get_roll = "";
                        while (roll_1[i] <= -1 || roll_1[i] >= 11)
                        {
                            get_roll = Console.ReadLine();
                            roll_1[i] = Int16.Parse(get_roll);
                        }
                        if (roll_1[i] != 10)
                        {
                            while (roll_2[i] <= -1 || roll_2[i] + roll_1[i] >= 11)
                            {
                                get_roll = Console.ReadLine();
                                roll_2[i] = Int16.Parse(get_roll);
                            }
                        }
                    }
                    if (are_we_rand == "R")
                    {
                        roll_1[i] = rd.Next(0, 11);
                        roll_2[i] = rd.Next(0, (10 - roll_1[i]) + 1);
                    }

                    if (roll_1[i] == 10)
                    {
                        roll_2[i] = 0;
                    }
                    if (i != 0 && roll_1[i - 1] + roll_2[i - 1] == 10 && roll_1[i - 0] != 10) //spare logic
                    {
                        frame_score[i - 1] += roll_1[i];
                    }
                    if (i != 0 && roll_1[i - 1] == 10) //strike logic
                    {
                        frame_score[i - 1] += roll_1[i] + roll_2[i];
                    }

                    if (i == 9 && roll_1[i] + roll_2[i] == 10 && roll_1[i] != 10) //final frame spare
                    {
                        if (are_we_rand == "I")
                        {
                            string get_roll = "";
                            while (roll_3 <= -1 || roll_3 >= 11)
                            {
                                get_roll = Console.ReadLine();
                                roll_3 = Int16.Parse(get_roll);
                            }
                        }
                        if (are_we_rand == "R")
                        {
                            roll_3 = rd.Next(0, 11);
                        }
                    }
                    if (i == 9 && roll_1[i] == 10) //final frame strike
                    {
                        if (are_we_rand == "I")
                        {
                            string get_roll = "";
                            while (roll_2[i] <= -1 || roll_2[i] + roll_1[i] >= 11)
                            {
                                get_roll = Console.ReadLine();
                                roll_2[i] = Int16.Parse(get_roll);
                            }
                            while (roll_3 <= -1 || roll_3 >= 11)
                            {
                                get_roll = Console.ReadLine();
                                roll_3 = Int16.Parse(get_roll);
                            }
                        }
                        if (are_we_rand == "R")
                        {
                            roll_2[i] = rd.Next(0, 11);
                            roll_3 = rd.Next(0, 11);
                        }
                    }
                    total_score += roll_1[i] + roll_2[i] + roll_3;
                    frame_score[i] = roll_1[i] + roll_2[i] + roll_3;
                }
                Console.Clear();
                Console.WriteLine("    1st   2nd   3rd   Frame");
                Console.WriteLine("-----------------------------");
                for (int j = 0; j < 10; j++)
                {
                    if (j != 9)
                    {
                        Console.Write($"{j + 1}) ");
                        Console.WriteLine($"{roll_1[j]}     {roll_2[j]}            {frame_score[j]}");
                    }
                    else
                    {
                        Console.Write($"{j + 1}) ");
                        Console.WriteLine($"{roll_1[j]}     {roll_2[j]}     {roll_3}      {frame_score[j]}");
                    }
                }
                Console.WriteLine(total_score);
                string play_again = "";
                while (play_again != "Y" && play_again != "N")
                {
                    Console.WriteLine("Would you like to play again? (Y/N)");
                    play_again = Console.ReadLine();
                    Console.Clear();
                }
                if (play_again == "N")
                {
                    playing = false;
                }
            }
        }
    }
}
