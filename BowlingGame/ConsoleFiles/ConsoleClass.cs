using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    class ConsoleClass : IConsoleOutput
    {
        public int display_score(List<Frame> frames)  //runs through a loop of printing the scores for each frame before giving the total score
        {
            Console.Clear();
            Console.WriteLine("    1st   2nd   3rd   Frame   Total");
            Console.WriteLine("-----------------------------------------------");
            int total_score = 0;
            for (var j = 0; j < 10; j++)
            {
                var f_rame = frames.ElementAt(j);
                total_score += f_rame.frame_score;
                if (j != 9)
                {
                    Console.Write($"{j + 1}) ");
                    Console.WriteLine($"{f_rame.roll_1}     {f_rame.roll_2}            {f_rame.frame_score}         {total_score}");
                }
                else
                {
                    Console.Write($"{j + 1}) ");
                    Console.WriteLine($"{f_rame.roll_1}     {f_rame.roll_2}     {f_rame.roll_3}      {f_rame.frame_score}           {total_score}");
                }
            }
            Console.WriteLine(total_score);
            return 0;
        }
    }
}
