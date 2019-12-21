using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Coord2d
    {
        protected float x;
        protected float y;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public Coord2d(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public Coord2d() {
            this.x = x;
            this.y = y;
        }

        public static Coord2d operator +(Coord2d a, Coord2d b)
        {
            return new Coord2d(a.X + b.X, a.Y + b.Y);
        } 
    }
}
