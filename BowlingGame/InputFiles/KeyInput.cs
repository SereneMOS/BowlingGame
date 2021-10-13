using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class KeyInput : IPlayerInput    //logic for player generated inputs
    {
        public int get_roll(int NumPinsRemaining)
        {
            int roll = 0;
            while (roll <= 0 || roll >= 11 || roll !> NumPinsRemaining) //ensures the user cannot input a value below 0, above 10, or a value that is 
            {                                                              //larger than the first roll and the second combined
                string get_roll = Console.ReadLine();
                roll = Int16.Parse(get_roll);
            }
            return roll;
        }
    }
}
