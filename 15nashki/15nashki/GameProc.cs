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
