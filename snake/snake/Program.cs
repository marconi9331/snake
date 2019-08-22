using System;

namespace snake
{
    enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
    struct Coords
    {
        public int x, y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        public const char WALL = '#';
        public const char EMPTY = ' ';
        public const char FOOD = '+';
        public const char PLAYER1 = '@';
        public const char PLAYER2 = '&';

        private static bool isGameOn;

        static void Main(string[] args)
        {
            Arena arena = new Arena(30, 17);
            Snake[] snakes = new Snake[2];
            snakes[0] = new Snake(arena, 10, 8, PLAYER1, ConsoleKey.W, ConsoleKey.S, ConsoleKey.A, ConsoleKey.D);
            snakes[1] = new Snake(arena, 20, 8, PLAYER2, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow);

            DrawArena(arena);

            ConsoleKeyInfo keyInfo;

            int snakeIndex;

            isGameOn = true;
            while (isGameOn)
            {
                if (Console.KeyAvailable) /* só lê a tecla se ela já foi pressionada */
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)
                        isGameOn = false;
                    else
                    {
                        for (snakeIndex = 0; snakeIndex < 2; snakeIndex++)
                            snakes[snakeIndex].OnKeyPressed(keyInfo.Key);
                    }
                }

                for (snakeIndex = 0; snakeIndex < 2; snakeIndex++)
                    snakes[snakeIndex].Move();

                DrawArena(arena);
            }
        }

        static void DrawArena(Arena arena)
        {
            int sizeX = arena.GetSizeX();
            int sizeY = arena.GetSizeY();
            int x, y;
            char c;

            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;


            for (y = 0; y < sizeY; y++)
            {
                for (x = 0; x < sizeX; x++)
                {
                    c = arena.GetBlock(x, y);
                    switch (c)
                    {
                        case WALL:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            break;
                        case EMPTY:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case FOOD:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case PLAYER1:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            break;
                        case PLAYER2:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            break;
                    }
                    Console.Write(c);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
