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
                IPlayerInput Input = null;
                while (are_we_rand != "I" && are_we_rand != "R")
                {
                    Console.WriteLine("Would you like to use random rolls or input rolls? (R/I)");
                    are_we_rand = Console.ReadLine();
                }
                if (are_we_rand == "R")
                {
                    Input = new RandomInput();
                }
                if (are_we_rand == "I")
                {
                    Input = new KeyInput();
                }
                var game = new BowlingClass(Input);
                game.Play();
                playing = ask_to_play_again();
            }
        }
        static bool ask_to_play_again()
        {
            string play_again = "";
            while (play_again != "Y" && play_again != "N")
            {
                Console.WriteLine("Would you like to play again? (Y/N)");
                play_again = Console.ReadLine();
                Console.Clear();
            }
            if (play_again == "N")
            {
                return false;
            }
            return true;
            
        }
    }
}
