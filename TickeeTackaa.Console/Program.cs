using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TickeeTackaa.Console
{
    class Program
    {
        static char[] arr = {'0','1','2','3','4','5','6','7','8','9'};
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                System.Console.Clear(); 
                System.Console.WriteLine($"Player 1 is X");
                System.Console.WriteLine($"Player 2 is 0");
                System.Console.WriteLine($"=====================================================");

                if (player % 2 == 0)  
                    System.Console.WriteLine("Player 2 Chance");
                else
                    System.Console.WriteLine("Player 1 Chance");

                System.Console.WriteLine($"=====================================================");

                Board();

                choice = int.Parse(System.Console.ReadLine()); 

                  
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) 
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else   
                {
                    System.Console.WriteLine($"Sorry the row {choice} is already marked with {arr[choice]}");
                    System.Console.WriteLine($"=====================================================");
                    System.Console.WriteLine("Please wait 2 second board is loading again.....");
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
                System.Console.WriteLine($"Player {playerClac} has won");
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
    }
}

