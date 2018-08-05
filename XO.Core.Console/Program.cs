using System;
using System.Linq;
using System.Threading;

namespace XO.Core.Console
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {


            do
            {
                System.Console.Clear();
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Player 1 is the X tag, and RED like a Golf GTI.");

                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"Player 2 is the O tag,and GREEN like a Focus RS.");

                System.Console.WriteLine($"=====================================================");
                System.Console.ForegroundColor = ConsoleColor.Magenta;

                if (player % 2 == 0)
                {
                    System.Console.WriteLine("Player 2. Its your turn, Sir!");
                    System.Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    System.Console.WriteLine("Player 1. Its your turn, Sir!");
                    System.Console.ForegroundColor = ConsoleColor.Red;
                }

                System.Console.WriteLine($"=====================================================");

                Board();

                choice = int.Parse(System.Console.ReadLine());


                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                        System.Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                        System.Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                else
                {
                    System.Console.WriteLine($"Yo Bruh, the row you choose: {choice} is already marked with: {arr[choice]}");
                    System.Console.WriteLine($"=====================================================");
                    System.Console.WriteLine("We need to reload this board again.....");
                    Thread.Sleep(2000);
                }

                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);

            System.Console.Clear();
            Board();

            if (flag == 1)
            {
                var playerClac = (player % 2) + 1;
                System.Console.WriteLine($"Player {playerClac} has won, well done!");
                Animate();
            }
            else
                System.Console.WriteLine("Draw");

            System.Console.ReadLine();
        }

        private static void Board()
        {
            System.Console.WriteLine($"     |     |      ");
            System.Console.WriteLine($"  {arr[1]}  |  {arr[2]}  |  {arr[3]}");
            System.Console.WriteLine($"_____|_____|_____ ");
            System.Console.WriteLine($"     |     |      ");
            System.Console.WriteLine($"  {arr[4]}  |  {arr[5]}  |  {arr[6]}");
            System.Console.WriteLine($"_____|_____|_____ ");
            System.Console.WriteLine($"     |     |      ");
            System.Console.WriteLine($"  {arr[7]}  |  {arr[8]}  |  {arr[9]}");
            System.Console.WriteLine($"     |     |      ");
        }

        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            if (arr[1] == arr[2] && arr[2] == arr[3])
                return 1;
            else if (arr[4] == arr[5] && arr[5] == arr[6])
                return 1;
            else if (arr[6] == arr[7] && arr[7] == arr[8])
                return 1;
            #endregion

            #region vertical Winning Condtion    
            else if (arr[1] == arr[4] && arr[4] == arr[7])
                return 1;
            else if (arr[2] == arr[5] && arr[5] == arr[8])
                return 1;
            else if (arr[3] == arr[6] && arr[6] == arr[9])
                return 1;
            #endregion

            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
                return 1;
            else if (arr[3] == arr[5] && arr[5] == arr[7])
                return 1;
            #endregion  

            #region Checking For Draw 
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
                return -1;
            #endregion
            else
                return 0;
        }

        private static void Animate()
        {
            char[] anims = new char[] { '_', '/', '|', '\\', '_' };
            int animsIndex = 0;
            for (int n = 0; n < 60; n++)
            {
                var colors = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().ToArray();
                var random = new Random().Next(0, colors.Length);
                System.Console.ForegroundColor = colors[random];
                System.Console.Write(anims[animsIndex]);
                Thread.Sleep(100);
                System.Console.SetCursorPosition(System.Console.CursorLeft - 1, System.Console.CursorTop);
                animsIndex++;
                if (animsIndex >= anims.Length)
                    animsIndex = 0;
            }
        }
    }
}
