using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    internal class Program
    {
        static char[,] playField =
        {
            { '1', '2', '3' },
            { '4', '5', '6'},
            { '7', '8', '9' }
        };
        static char[,] playFieldInitial =
        {
            { '1', '2', '3' },
            { '4', '5', '6'},
            { '7', '8', '9' }
        };
        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;
            bool sociable = false;
            do
            {

                EnterXorO(player, input);
                setField();
                if (CheckWin(ref sociable))
                {
                    Console.WriteLine("\nPlayer {0}: WIN", player);
                    break;
                }
                if (sociable == true)
                {
                    Console.WriteLine("NOT FIND WINNER");
                    Console.WriteLine("Press to next game!");
                    Console.ReadKey();
                    playField = playFieldInitial;
                    player = 2;
                    input = 0;
                    inputCorrect = true;
                    sociable = false;
                    continue;
                }
                if (player == 2)
                {
                    player = 1;
                }
                else if (player == 1)
                {
                    player = 2;
                }
                do
                {
                    Console.Write("\nPlayer {0}: Choose your field!", player);
                    inputCorrect = int.TryParse(Console.ReadLine(), out input);
                    if (input < 0 || input > 9) inputCorrect = false;
                    int count = 1;
                    char check = ' ';
                    foreach ( char ch in playField)
                    {
                        if (count++ == input)
                        {
                            check = ch;
                            break;
                        }
                    }
                    if (check == 'X' || check == 'O') inputCorrect = false;
                } while (!inputCorrect);
                

            } while (true);
            


        }
        public static void setField()
        {
            Console.Clear();
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("       |       |       ");
        }
        public static void EnterXorO(int player, int input)
        {
            char playerSign = player == 1 ? 'X' : 'O';
            
            switch (input)
            {
                case 1:
                    playField[0, 0] = playerSign;
                    break;
                case 2:
                    playField[0, 1] = playerSign;
                    break;
                case 3:
                    playField[0, 2] = playerSign;
                    break;
                case 4:
                    playField[1, 0] = playerSign;
                    break;
                case 5:
                    playField[1, 1] = playerSign;
                    break;
                case 6:
                    playField[1, 2] = playerSign;
                    break;
                case 7:
                    playField[2, 0] = playerSign;
                    break;
                case 8:
                    playField[2, 1] = playerSign;
                    break;
                case 9:
                    playField[2, 2] = playerSign;
                    break;
            }
        }
        public static bool CheckWin(ref bool socible)
        {
            socible = true;
            foreach (char ch in playField)
            {
                if (ch != 'X' && ch != 'O')
                {
                    socible = false;
                    break;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (playField[i, 0] == playField[i, 1]  && playField[i, 1] == playField[i, 2]) return true;
                if (playField[0, i] == playField[1, i] && playField[1, i] == playField[2, i]) return true; ;
                
            }
            if (playField[0, 0] == playField[1, 1] && playField[1, 1] == playField[2, 2]) return true;
            if (playField[0, 2] == playField[1, 1] && playField[1, 1] == playField[2, 0]) return true;
            return false;
        }
    }
}
