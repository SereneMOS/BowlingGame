using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This class rolls the values of both balls for all 10 frames. It has special logic for strikes and spares with an exception for the final frame. At the
/// end it tallies and displays all the scores for each individual roll, frame, and the final score.
/// </summary>
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
            var frames = new List<Frame>();
            var scores = new ConsoleClass();
            for (var i = 0; i < 10; i++)    //loops 10 times, once for each frame
            {
                var frame = new Frame();
                frames.Add(frame);
                frame.roll_1 = _player.get_roll(10);         //calls upon the Input class in the IPlayerInput interface and rolls for the values of this frame.
                if (frame.roll_1 != 10) //nullifies the value of the second roll on a strike
                {
                    frame.roll_2 = _player.get_roll(10 - frame.roll_1);
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
            scores.display_score(frames);
        }


        int sparestrike(Frame frame, Frame previous_frame)  //spare and strike logic
        {
            
            if (previous_frame.roll_1 + previous_frame.roll_2 == 10 && previous_frame.roll_1 != 10)
            {
                previous_frame.frame_score += frame.roll_1;
            } 
            if (previous_frame.roll_1 == 10)
            {
                previous_frame.frame_score += frame.roll_1 + frame.roll_2;
            }
            return 0;
        }

        private int finalspare(Frame frame)
        {
            if (frame.roll_1 + frame.roll_2 == 10 && frame.roll_1 != 10) //final frame spare
            {
                frame.roll_3 = _player.get_roll(10);
            }
            return 0;
        }

        private int finalstrike(Frame frame)
        {
            if (frame.roll_1 == 10) //final frame strike
            {
                frame.roll_2 = _player.get_roll(frame.roll_1);
                frame.roll_3 = _player.get_roll(10);
            }
            return 0;
        }

    }
}
