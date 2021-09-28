using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class RandomInput : IPlayerInput
    {
        private Random _rand = new Random();
        public int get_roll(int NumPinsRemaining)
        {
            var roll = _rand.Next(0, NumPinsRemaining + 1);
            return roll;
        }
    }
}
