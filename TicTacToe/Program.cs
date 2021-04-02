using System;

namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            PlayingTicTacToe();
        }

        static void PrintBoard(char[,] location)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(location[row, col]);
                }
                Console.WriteLine();
            }
        }

        static int CheckInputRow(int value)
        {
            bool player = true;
            while (player == true)
            {
                try
                {
                    while (value < 0 || value > 2)
                    {
                        Console.WriteLine("Please enter valid number. 0, 1, 2 ");
                        value = int.Parse(Console.ReadLine());
                    }

                    player = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    player = true;
                }
            }
            return value;
        }

        static int CheckInputCol(int value)
        {
            bool player = true;
            while (player == true)
            {
                try
                {
                    while (value < 0 || value > 2)
                    {
                        Console.WriteLine("Please enter valid number. 0, 1, 2 ");
                        value = int.Parse(Console.ReadLine());
                    }

                    player = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    player = true;
                }
            }
            return value;
        }

        static bool Check(char[,] location, int r, int c)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (location[row, col] == location[r, c])
                    {
                        if (location[row, col] == 'X' || location[row, col] == 'O')
                        {
                            Console.WriteLine("This spot is already taken. Try again.");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        static void PlayingTicTacToe()
        {
            bool result = false;
            int r = 0;
            int c = 0;
            char[,] ticTacToeBoard = new char[,] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };

            for (int turns = 0; turns < 9; turns++)
            {
                while (result == false)
                {
                    try
                    {
                        Console.Write("Player 'X' Row: ");
                        r = CheckInputRow(int.Parse(Console.ReadLine()));
                        Console.Write("Player 'X' Col: ");
                        c = CheckInputCol(int.Parse(Console.ReadLine()));

                        result = Check(ticTacToeBoard, r, c);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                ticTacToeBoard[r, c] = 'X';
                bool boardStatus = BoardIsFull(ticTacToeBoard);
                if (boardStatus == true)
                {
                    break;
                }
                PrintBoard(ticTacToeBoard);
                result = false;

                bool winnerCheck = Winner(ticTacToeBoard);
                if (winnerCheck == true)
                {
                    break;
                }

                while (result == false)
                {
                    try
                    {
                        Console.Write("Player 'O' Row: ");
                        r = CheckInputRow(int.Parse(Console.ReadLine()));
                        Console.Write("Player 'O' Col: ");
                        c = CheckInputCol(int.Parse(Console.ReadLine()));

                        result = Check(ticTacToeBoard, r, c);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                ticTacToeBoard[r, c] = 'O';
                boardStatus = BoardIsFull(ticTacToeBoard);
                if (boardStatus == true)
                {
                    break;
                }
                PrintBoard(ticTacToeBoard);
                result = false;
                winnerCheck = Winner(ticTacToeBoard);
                if(winnerCheck == true)
                {
                    break;
                }
            }
        }

        static bool BoardIsFull(char[,] location)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if(location[row, col] == '-')
                    {
                        return false;
                    }
                }
            }
            Console.WriteLine("The board is full, no one wins. Game Over.");
            return true; ;
        }

        static bool Winner(char[,] location)
        {
            if(location[0, 0] == 'X' && location[0, 1] == 'X' && location[0, 2] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }
            else if (location[1, 0] == 'X' && location[1, 1] == 'X' && location[1, 2] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }
            else if (location[2, 0] == 'X' && location[2, 1] == 'X' && location[2, 2] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }

            else if (location[0, 0] == 'X' && location[1, 0] == 'X' && location[2, 0] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }
            else if (location[0, 1] == 'X' && location[1, 1] == 'X' && location[2, 1] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }
            else if (location[0, 2] == 'X' && location[1, 2] == 'X' && location[2, 2] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }

            else if (location[0, 0] == 'X' && location[1, 1] == 'X' && location[2, 2] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }
            else if (location[2, 0] == 'X' && location[1, 1] == 'X' && location[0, 2] == 'X')
            {
                Console.WriteLine("Congratulations, Player 1 Wins!!!");
                return true;
            }



            else if (location[0, 0] == 'O' && location[0, 1] == 'O' && location[0, 2] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }
            else if (location[1, 0] == 'O' && location[1, 1] == 'O' && location[1, 2] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }
            else if (location[2, 0] == 'O' && location[2, 1] == 'O' && location[2, 2] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }

            else if (location[0, 0] == 'O' && location[1, 0] == 'O' && location[2, 0] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }
            else if (location[0, 1] == 'O' && location[1, 1] == 'O' && location[2, 1] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }
            else if (location[0, 2] == 'O' && location[1, 2] == 'O' && location[2, 2] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }

            else if (location[0, 0] == 'O' && location[1, 1] == 'O' && location[2, 2] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }
            else if (location[2, 0] == 'O' && location[1, 1] == 'O' && location[0, 2] == 'O')
            {
                Console.WriteLine("Congratulations, Player 2 Wins!!!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
