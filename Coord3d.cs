using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Coord3d:Coord2d
    {
        private float z;

        public Coord3d(float x, float y, float z):base(x , y)
        {
            this.z = z;
        }

        public float Z { get => z; set => z = value; }

        public Coord2d LowerDegree()
        {
            return new Coord2d(this.x, this.y);
        }


        public static Coord3d operator +(Coord3d a, Coord2d b)
        {
            return new Coord3d(a.X + b.X, a.Y + b.Y, a.Z);
        }


    };


}
