using System;
using System.Collections.Generic;

namespace Maze.Model
{
    public class Cell
    {
        public int x;
        public int y;
        public bool hasVisited = false;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Dictionary<string, bool> walls = new Dictionary<string, bool>
            {{"top", true},
             {"bottom", true},
             {"left", true},
             {"right", true} };

    }
}
