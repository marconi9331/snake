using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Snake
    {
        private Arena arena;
        private int headX;
        private int headY;
        private int length;
        private Direction moveDir;
        private char blockChar;
        private ConsoleKey upKey;
        private ConsoleKey downKey;
        private ConsoleKey leftKey;
        private ConsoleKey rightKey;
        private Queue<Coords> segmentsCoords;
        private bool isAlive;

        // Construtor
        public Snake(Arena arena, int x, int y, char blockChar, ConsoleKey upKey, ConsoleKey downKey, ConsoleKey leftKey, ConsoleKey rightKey)
        {
            this.arena = arena;
            this.headX = x;
            this.headY = y;
            this.length = 1;
            this.moveDir = Direction.NONE;
            this.blockChar = blockChar;
            this.upKey = upKey;
            this.downKey = downKey;
            this.leftKey = leftKey;
            this.rightKey = rightKey;
            this.segmentsCoords = new Queue<Coords>(); //Chama construtor de Queue
            this.isAlive = true;

            //Coords coord = new Coords(); /* usado para caso o struct Coords não tenha um construtor implementado */
            //coord.x = x;
            //coord.y = y;
            this.segmentsCoords.Enqueue(new Coords(this.headX, this.headY));

            this.arena.Setblock(this.headX, this.headY, this.blockChar);
        }

        public void OnKeyPressed(ConsoleKey key)
        {
            if (key == this.upKey)
                this.moveDir = Direction.UP;

            else if (key == this.downKey)
                this.moveDir = Direction.DOWN;

            else if (key == this.leftKey)
                this.moveDir = Direction.LEFT;

            else if (key == this.rightKey)
                this.moveDir = Direction.RIGHT;
        }

        public void Move()
        {
            if (!this.isAlive || this.moveDir == Direction.NONE)
                return;
            int destX = this.headX, destY = this.headY;

            switch (this.moveDir)
            {
                case Direction.UP:
                    destY--;
                    break;
                case Direction.DOWN:
                    destY++;
                    break;
                case Direction.LEFT:
                    destX--;
                    break;
                case Direction.RIGHT:
                    destX++;
                    break;
                default:
                    break;
            }

            char nextBlock = this.arena.GetBlock(destX, destY);

            if (nextBlock != Program.EMPTY && nextBlock != Program.FOOD)
            {
                this.isAlive = false;
            }

            else
            {
                this.headX = destX;
                this.headY = destY;
                this.segmentsCoords.Enqueue(new Coords(this.headX, this.headY));

                this.arena.Setblock(this.headX, this.headY, this.blockChar);

                Coords tailCoords = this.segmentsCoords.Dequeue();
                this.arena.Setblock(tailCoords.x, tailCoords.y, Program.EMPTY);
            }
        }
    }
}
