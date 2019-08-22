using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Arena
    {
        private int sizeX;
        private int sizeY;
        private char[,] blocks;

        public Arena(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.blocks = new char[sizeX, sizeY];

            int x, y; // inicialização de indices para as linhas "x" e colunas "y"

            //preenchimento de celulas da arena com blocos vazios usando "for" aninhados
            for (y = 1; y < sizeY - 1; y++)
                for (x = 1; x < sizeX - 1; x++)
                    this.blocks[x, y] = Program.EMPTY;
            //preenchimento de celulas da arena com blocos vazios usando "while" aninhados
            {
                //y = 0;
                //while (y < sizeY)
                //{
                //    x = 0;
                //    while (x < sizeX)
                //    {
                //        this.blocks[x, y] = Program.EMPTY;
                //        x++;
                //    }
                //    y++;
                //
            }

            for (x = 0; x < sizeX; x++)
            {
                this.blocks[x, 0] = Program.WALL;
                this.blocks[x, sizeY - 1] = Program.WALL;
            }
            for (y = 1; y < sizeY -1; y++)
            {
                this.blocks[0, y] = Program.WALL;
                this.blocks[sizeX - 1, y] = Program.WALL;
            }
        }
        public char GetBlock(int x, int y)
        {
            return (x < 0 || x > this.sizeX || y < 0 || y > this.sizeY) ? '\0' : this.blocks[x, y];
        }

        public void Setblock(int x, int y, char newBlock)
        {
            if (x < 0 || x > this.sizeX - 1 || y < 0 || y > this.sizeY -1)
                return;
            this.blocks[x, y] = newBlock;
        }

        public int GetSizeX()
        {
            return this.sizeX;
        }
        public int GetSizeY()
        {
            return this.sizeY;
        }
    }
}
