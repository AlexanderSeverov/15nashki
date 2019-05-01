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
        static Random rand = new Random();

        public GameProc(int size)
        {
        //    if (size < 2)
        //        size = 2;
        //    if (size > 5)
        //        size = 5;

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

        public void smeshmnoghod()
        {
            //   smeshen(rand.Next(0, size * size));

            int a = rand.Next(0, 4);
            int x = emptyX;
            int y = emptyY;

            switch(a)
            {
                case 0: x--;break;
                case 1: x++;break;
                case 2: y--;break;
                case 3: y++;break;
            }

            smeshen(coordTOposition(x, y));
        }


        public void smeshen(int position)
        {
            int x, y;

            positionTOcoord(position, out x, out y);

            if (Math.Abs(emptyX-x)+Math.Abs(emptyY-y)!=1)
            {
                return;
            }
            map[emptyX, emptyY] = map[x, y];
            map[x, y] = 0;
            emptyX = x;
            emptyY = y;
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
        
        public bool maybeWin()
        {
            if (!(emptyX==size -1 && emptyY==size-1))
                return false;

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1))          
                     if (map[x, y] != coordTOposition(x, y) + 1)
                        return false;

            return true;
        }

        private int coordTOposition(int x,int y)
        {
            if (x < 0)
                x = 0;

            if (x > size - 1)
                x = size - 1;

            if (y > size - 1)
                y = size - 1;

            return y * size + x;
        }

        private void positionTOcoord(int position, out int x,out int y)
        {
            if (position < 0)
                position = 0;

            if (position > size * size - 1)
                position = size - 1;

            x = position % size;
            y = position / size;
        }
    }
}
