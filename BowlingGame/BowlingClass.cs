using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingClass
    {
        public void Play()
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
            int roll_3 = -1;
            int i;
            for (i = 0; i < 10; i++)
            {
                Random rd = new Random();
                if (are_we_rand == "I")
                {
                    roll_ball_1(roll_1, i);
                    roll_ball_2(roll_1, roll_2, i);
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
                sparestrike(i, roll_1, roll_2, frame_score);
                finalspare(i, roll_1, roll_2, are_we_rand, roll_3);
                finalstrike(i, roll_1, roll_2, are_we_rand, roll_3);
                /*
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
                */
                /*
                if (i == 9 && roll_1[i] == 10) //final frame strike
                {
                    if (are_we_rand == "I")
                    {
                        roll_ball_2(roll_1, roll_2, i);
                        string get_roll = "";
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
                */
                total_score += roll_1[i] + roll_2[i] + roll_3;
                frame_score[i] = roll_1[i] + roll_2[i] + roll_3;
            }
            Console.Clear();
            Console.WriteLine("    1st   2nd   3rd   Frame");
            Console.WriteLine("-----------------------------");
            display_score(i, roll_1, roll_2, frame_score, roll_3);
            Console.WriteLine(total_score);
            //again(playing);
        }


        int sparestrike(int j, int[] roll1, int[] roll2, int[] frame)
        {
            if (j != 0 && roll1[j - 1] + roll2[j - 1] == 10 && roll1[j - 1] != 10)
            {
                frame[j - 1] += roll1[j];
            }
            if (j != 0 && roll1[j - 1] == 10)
            {
                frame[j - 1] += roll1[j] + roll2[j];
            }
            return 0;
        }
        static int finalspare(int j, int[] roll1, int[] roll2, string que_rand, int roll3)
        {
            Random rd = new Random();
            if (j == 9 && roll1[j] + roll2[j] == 10 && roll1[j] != 10) //final frame spare
            {
                if (que_rand == "I")
                {
                    string get_roll = "";
                    while (roll3 <= -1 || roll3 >= 11)
                    {
                        get_roll = Console.ReadLine();
                        roll3 = Int16.Parse(get_roll);
                    }
                }
                if (que_rand == "R")
                {
                    roll3 = rd.Next(0, 11);
                }
            }
            return 0;
        }

        static int finalstrike(int j, int[] roll1, int[] roll2, string que_rand, int roll3)
        {
            Random rd = new Random();
            if (j == 9 && roll1[j] == 10) //final frame strike
            {
                if (que_rand == "I")
                {
                    string get_roll = "";
                    while (roll2[j] <= -1 || roll2[j] + roll1[j] >= 11)
                    {
                        get_roll = Console.ReadLine();
                        roll2[j] = Int16.Parse(get_roll);
                    }
                    while (roll3 <= -1 || roll3 >= 11)
                    {
                        get_roll = Console.ReadLine();
                        roll3 = Int16.Parse(get_roll);
                    }
                }
                if (que_rand == "R")
                {
                    roll2[j] = rd.Next(0, 11);
                    roll3 = 5; //rd.Next(0, 11);
                }
            }
            return 0;
        }

        int roll_ball_1(int[] roll1, int j)
        {
            string get_roll = "";
            while (roll1[j] <= -1 || roll1[j] >= 11)
            {
                get_roll = Console.ReadLine();
                roll1[j] = Int16.Parse(get_roll);
            }
            return 0;
        }

        int roll_ball_2(int[] roll1, int[] roll2, int j)
        {
            if (roll1[j] != 10)
            {
                string get_roll = "";
                while (roll2[j] <= -1 || roll2[j] + roll1[j] >= 11)
                {
                    get_roll = Console.ReadLine();
                    roll2[j] = Int16.Parse(get_roll);
                }
            }
            return 0;
        }

        int display_score(int j, int[] a, int[] b, int[] c, int d)
        {
            for (j = 0; j < 10; j++)
            {
                if (j != 9)
                {
                    Console.Write($"{j + 1}) ");
                    Console.WriteLine($"{a[j]}     {b[j]}            {c[j]}");
                }
                else
                {
                    Console.Write($"{j + 1}) ");
                    Console.WriteLine($"{a[j]}     {b[j]}     {d}      {c[j]}");
                }
            }
            return 0;
        }
    }
}

