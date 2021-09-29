using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public interface IPlayerInput //player input interface
    {
        int get_roll(int NumPinsRemaining);
    }
}
