using System;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int total_score = 0;
            int frame_1 = 0;
            int frame_2 = 0;
            int frame_3 = 0;
            int frame_4 = 0;
            int frame_5 = 0;
            int frame_6 = 0;
            int frame_7 = 0;
            int frame_8 = 0;
            int frame_9 = 0;
            int frame_10 = 0;
            for (int i = 0; i < 10; i++)
            {
                bool strike = false;
                bool spare = false;
                Random rd = new Random();
                int rand_num_1 = rd.Next(0, 11);
                if (rand_num_1 == 10)
                {
                    strike = true;
                }
                else
                {
                    int rand_num_2 = rd.Next(0, (10 - rand_num_1) + 1);
                    Console.WriteLine($"{rand_num_1}  {rand_num_2}");
                    if (rand_num_1 + rand_num_2 == 10 && strike == false)
                    {
                        spare = true;
                    }
                    if (i == 0 && strike == false && spare == false)
                    {
                       frame_1 = rand_num_1 + rand_num_2; }
                    if (i == 1 && strike == false && spare == false)
                    {
                       frame_2 = rand_num_1 + rand_num_2; }
                    if (i == 2 && strike == false && spare == false)
                    {
                       frame_3 = rand_num_1 + rand_num_2; }
                    if (i == 3 && strike == false && spare == false)
                    {
                       frame_4 = rand_num_1 + rand_num_2; }
                    if (i == 4 && strike == false && spare == false)
                    {
                       frame_5 = rand_num_1 + rand_num_2; }
                    if (i == 5 && strike == false && spare == false)
                    {
                       frame_6 = rand_num_1 + rand_num_2; }
                    if (i == 6 && strike == false && spare == false)
                    {
                       frame_7 = rand_num_1 + rand_num_2; }
                    if (i == 7 && strike == false && spare == false)
                    {
                       frame_8 = rand_num_1 + rand_num_2; }
                    if (i == 8 && strike == false && spare == false)
                    {
                       frame_9 = rand_num_1 + rand_num_2; }
                    if (i == 9 && strike == false && spare == false)
                    {
                       frame_10 = rand_num_1 + rand_num_2; }
                }
                
            }
            total_score = frame_1 + frame_2 + frame_3 + frame_4 + frame_5 + frame_6 + frame_7 + frame_8 + frame_9 + frame_10;
            Console.WriteLine(total_score);
        }
    }
}
