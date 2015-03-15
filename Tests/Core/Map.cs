using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Map : IMap
    {
        private int WIDTH = 100;
        private int HEIGHT = 100;

        public int Width
        {
            get { return WIDTH; }
        }

        public int Height
        {
            get { return HEIGHT; }
        }
    }
}
