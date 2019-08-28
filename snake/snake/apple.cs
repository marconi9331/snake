using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class apple
    {
        private Arena arena;
        private Random randomCoords;
        private char appleChar;
        private Coords applesCoords;
        private int RndPosX = -1, RndPosY = -1;

        public apple(Arena arena)
        {
            this.arena = arena;
            this.randomCoords = new Random();
            this.appleChar = Program.FOOD;
            this.applesCoords = new Coords();
        }

        public void spawnApple()
        {
            if (arena.GetBlock(RndPosX, RndPosY) == Program.FOOD)
                return;

            RndPosX = randomCoords.Next(1, Program.ARENA_SIZE_X-1);
            RndPosY = randomCoords.Next(1, Program.ARENA_SIZE_Y-1);

            if (arena.GetBlock(RndPosX, RndPosY) == Program.EMPTY)
            {
                applesCoords = new Coords(RndPosX, RndPosY);
                arena.Setblock(applesCoords.x, applesCoords.y, appleChar);
            }
            else
                spawnApple();
        }
    }
}
