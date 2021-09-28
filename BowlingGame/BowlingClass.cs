using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingClass
    {
        private IPlayerInput _player;
        public BowlingClass (IPlayerInput Input)
        {
            _player = Input;
        }
        public void Play()
        {
            //string are_we_rand = "";
            /*
            while (are_we_rand != "I" && are_we_rand != "R")
            {
                Console.WriteLine("Would you like to use random rolls or input rolls? (R/I)");
                are_we_rand = Console.ReadLine();
            }
            */
            Console.Clear();
            var frames = new List<Frame>();
            for (var i = 0; i < 10; i++)
            {
                var frame = new Frame();
                frames.Add(frame);
                //Random rd = new Random();
                /*
                if (are_we_rand == "I")
                {
                    roll_ball_1(frame);
                    roll_ball_2(frame);
                }

                if (are_we_rand == "R")
                {
                    frame.roll_1 = rd.Next(0, 11);
                    frame.roll_2 = rd.Next(0, (10 - frame.roll_1) + 1);
                }
                */
                frame.roll_1 = _player.get_roll(10);
                frame.roll_2 = _player.get_roll(frame.roll_1);
                if (frame.roll_1 == 10)
                {
                    frame.roll_2 = 0;
                }
                if (i != 0)
                {
                    sparestrike(frame, frames.ElementAt(i - 1));
                }
                if (i == 9)
                {
                    finalspare(frame);
                    finalstrike(frame);
                }
                frame.frame_score = frame.roll_1 + frame.roll_2 + frame.roll_3;
            }
            Console.Clear();
            Console.WriteLine("    1st   2nd   3rd   Frame");
            Console.WriteLine("-----------------------------");
            display_score(frames);
        }


        int sparestrike(Frame frame, Frame previous_frame)
        {
            
            if (previous_frame.roll_1 + previous_frame.roll_2 == 10 && previous_frame.roll_1 != 10)
            {
                previous_frame.frame_score += frame.roll_1;
            } 
            if (previous_frame.roll_1 == 10)
            {
                Console.WriteLine(previous_frame.frame_score);
                previous_frame.frame_score += frame.roll_1 + frame.roll_2;
                Console.WriteLine(previous_frame.frame_score);
            }
            return 0;
        }

        private int finalspare(Frame frame)
        {
          //  Random rd = new Random();
            if (frame.roll_1 + frame.roll_2 == 10 && frame.roll_1 != 10) //final frame spare
            {
                /*
                if (que_rand == "I")
                {
                    string get_roll = "";
                    while (frame.roll_3 <= 0 || frame.roll_3 >= 11)
                    {
                        get_roll = Console.ReadLine();
                        frame.roll_3 = Int16.Parse(get_roll);
                    }
                }
                if (que_rand == "R")
                {
                    frame.roll_3 = rd.Next(0, 11);
                }
                */
                frame.roll_3 = _player.get_roll(10);
            }
            return 0;
        }

        private int finalstrike(Frame frame)
        {
            //Random rd = new Random();
            if (frame.roll_1 == 10) //final frame strike
            {
                /*
                if (que_rand == "I")
                {
                    string get_roll = "";
                    while (frame.roll_2 <= 0 || frame.roll_2 + frame.roll_1 >= 11)
                    {
                        get_roll = Console.ReadLine();
                        frame.roll_2 = Int16.Parse(get_roll);
                    }
                    while (frame.roll_3 <= 0 || frame.roll_3 >= 11)
                    {
                        get_roll = Console.ReadLine();
                        frame.roll_3 = Int16.Parse(get_roll);
                    }
                }
                if (que_rand == "R")
                {
                    frame.roll_2 = rd.Next(0, 11);
                    frame.roll_3 = rd.Next(0, 11);
                }
                */
                frame.roll_2 = _player.get_roll(frame.roll_1);
                frame.roll_3 = _player.get_roll(10);
            }
            return 0;
        }

        int roll_ball_1(Frame frame)
        {
            string get_roll = "";
            while (frame.roll_1 <= 0 || frame.roll_1 >= 11)
            {
                get_roll = Console.ReadLine();
                frame.roll_1 = Int16.Parse(get_roll);
            }
            return 0;
        }

        int roll_ball_2(Frame frame)
        {
            
            if (frame.roll_1 != 10)
            {
                string get_roll = "";
                while (frame.roll_2 <= 0 || frame.roll_2 + frame.roll_1 >= 11)
                {
                    get_roll = Console.ReadLine();
                    frame.roll_2 = Int16.Parse(get_roll);
                }
            }
            return 0;
        }

        int display_score(List <Frame> frames)
        {
            int total_score = 0;
            for (var j = 0; j < 10; j++)
            {
                var f_rame = frames.ElementAt(j);
                total_score += f_rame.frame_score;
                if (j != 9)
                {
                    Console.Write($"{j + 1}) ");
                    Console.WriteLine($"{f_rame.roll_1}     {f_rame.roll_2}            {f_rame.frame_score}");
                }
                else
                {
                    Console.Write($"{j + 1}) ");
                    Console.WriteLine($"{f_rame.roll_1}     {f_rame.roll_2}     {f_rame.roll_3}      {f_rame.frame_score}");
                }
            }
            Console.WriteLine(total_score);
            return 0;
        }
    }
}

