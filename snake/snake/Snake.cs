using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Snake
    {
        private int headX;
        private int headY;
        private Direction moveDir;
        private char blockChar;
        private ConsoleKey upKey;
        private ConsoleKey downKey;
        private ConsoleKey leftKey;
        private ConsoleKey rightKey;
        private Queue<Coords> segments;
        private bool isAlive;

        // Construtor
        public Snake(int x, int y, char blockChar, ConsoleKey upKey, ConsoleKey downKey, ConsoleKey leftKey, ConsoleKey rightKey)
        {
            this.headX = x;
            this.headY = y;
            this.moveDir = Direction.NONE;
            this.blockChar = blockChar;
            this.upKey = upKey;
            this.downKey = downKey;
            this.leftKey = leftKey;
            this.rightKey = rightKey;
            this.segments = new Queue<Coords>(); //Chama construtor de Queue
            this.isAlive = true;

        }
    }
}
