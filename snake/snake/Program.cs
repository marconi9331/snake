using System;

namespace snake
{
    enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
    struct Coords
    {
        public int x, y;
    }
    class Program
    {
        public const char WALL = '#';
        public const char EMPTY = ' ';
        public const char FULL = '+';
               
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
