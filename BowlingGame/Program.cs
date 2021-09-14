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
                var game = new BowlingClass();
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
