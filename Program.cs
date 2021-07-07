using System;

namespace BasicX_O
{
    class Program
    {
        static bool checkMove(string pmove)
        {
            if (pmove != "1" && pmove != "2" && pmove != "3" &&
                pmove != "4" && pmove != "5" && pmove != "6" &&
                pmove != "7" && pmove != "8" && pmove != "9")
                return false;
            return true;
        }
        static bool condition(string[] opts)
        {
            if ((opts[0].Equals(opts[1])) && (opts[1].Equals(opts[2]))) //first line
                return true;
            if ((opts[3].Equals(opts[4])) && (opts[4].Equals(opts[5]))) //middle line
                return true;
            if ((opts[6].Equals(opts[7])) && (opts[7].Equals(opts[8]))) //last line
                return true;
            if ((opts[0].Equals(opts[4])) && (opts[4].Equals(opts[8]))) //left to right diagonal
                return true;
            if ((opts[2].Equals(opts[4])) && (opts[4].Equals(opts[6]))) //right to left diagonal
                return true;
            if ((opts[0].Equals(opts[3])) && (opts[3].Equals(opts[6])))
                return true;
            if ((opts[1].Equals(opts[4])) && (opts[4].Equals(opts[7])))
                return true;
            if ((opts[2].Equals(opts[5])) && (opts[5].Equals(opts[8])))
                return true;

            return false;
        }
        static void play_sheet(string[] opts)
        {
            Console.Clear();
            Console.Write("\n      " + opts[0] + "   |   " + opts[1] + "   |   " + opts[2] + "\n" +
                          "   _______|_______|_______" +
                          "\n      " + opts[3] + "   |   " + opts[4] + "   |   " + opts[5] + "\n" +
                          "   _______|_______|_______" +
                          "\n      " + opts[6] + "   |   " + opts[7] + "   |   " + opts[8] + "\n" +
                          "          |       |     \n\n");

        }
        static void Main(string[] args)
        {
            string[] options = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool wincondition = false;
            string playermove = "";
            bool token = true;
            int turn=1;
            while (wincondition != true)
            {
                play_sheet(options);
                if (token == true)
                    Console.Write("Turn " + turn + "\nPlayer 1(O) input: ");
                else Console.Write("Turn " + turn + "\nPlayer 2(X) input: ");
                playermove = Console.ReadLine();
                while(checkMove(playermove)==false)
                {
                    Console.Write("Option unavailable!Try another: ");
                    playermove = Console.ReadLine();
                }
                if(token==true)
                options[Int32.Parse(playermove)-1] = "O";
                else options[Int32.Parse(playermove) - 1] = "X";
                turn++;
                if (condition(options) == true)
                    if (token == true)
                    {
                        wincondition = true;
                        play_sheet(options);
                        Console.WriteLine("Player 1 WON!");
                    }
                    else
                    {
                        wincondition = true;
                        play_sheet(options);
                        Console.WriteLine("Player 2 WON!");
                    }
                if (turn == 10)
                {
                    play_sheet(options);
                    Console.WriteLine(" -Draw- ");
                    break;
                }
                if (turn % 2 == 0)
                    token = false;
                else token = true;

            }
        }
    }
}
