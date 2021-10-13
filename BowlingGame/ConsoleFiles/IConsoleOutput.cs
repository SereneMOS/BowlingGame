using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public interface IConsoleOutput
    {
        public int display_score(List<Frame> frames);
    }
}
