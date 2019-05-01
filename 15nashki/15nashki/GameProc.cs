using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15nashki
{
    class GameProc
    {
        int size;
        int[,] map;
        int emptyX, emptyY;

        public GameProc(int size)
        {
            if (size < 2)
                size = 2;
            if (size > 5)
                size = 5;

            this.size = size;
            map = new int [size, size];

        }

        public void zapoln()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = coordTOposition(x, y) + 1;
            emptyX = size - 1;
            emptyY = size - 1;
            map [emptyX, emptyY] = 0;
        }

        public void smeshen(int position)
        {
            int x, y;

            positionTOcoord(position, out x, out y);
            map[emptyX, emptyY] = map[x, y];
            map[x, y] = 0;
        }


        public int facingNum(int position)
        {
            int x, y;
            positionTOcoord(position, out x,out y);

            if (x < 0 || x >= size)
                return 0;
            if (y < 0 || y >= size)
                return 0;

            return map[x, y];

        }

        private int coordTOposition(int x,int y)
        {
            return y * size + x;
        }

        private void positionTOcoord(int position, out int x,out int y)
        {
            x = position % size;
            y = position / size;
        }
    }
}
