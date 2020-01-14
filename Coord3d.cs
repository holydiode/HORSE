using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Coord3d:Coord2d
    {
        private double z;
        public double Z { get => z; set => z = value; }

        public Coord3d(double x, double y, double z):base(x , y)
        {
            this.z = z;
        }

        public Coord3d(double x, double y) : base(x, y)
        {
            this.z = 0;
        }

        public Coord3d() : base()
        {
            this.z = 0;
        }

        public Coord2d LowerDegree()
        {
            return new Coord2d(this.x, this.y);
        }


        public static Coord3d operator +(Coord3d a, Coord2d b)
        {
            return new Coord3d(a.X + b.X, a.Y + b.Y, a.Z);
        }

        public double len()
        {
            return (Math.Sqrt(x * x + y * y + z * z));
        }


        public double len(Coord3d point)
        {
            return (Math.Sqrt((x - point.x) * (x - point.x) + (y - point.y) * (y - point.y) + (z - point.z)));
        }


        public static Coord2d operator +(Coord3d a, Coord3d b)
        {
            return new Coord3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Coord2d operator -(Coord3d a, Coord3d b)
        {
            return new Coord3d(a.X - b.X, a.Y - b.Y, a.Y - b.Y);
        }


        public static Coord2d operator /(Coord3d a, double b)
        {
            return new Coord3d(a.X / b, a.Y / b, a.Z/b);
        }


        public static Coord3d operator *(Coord3d a, double b)
        {
            return new Coord3d(a.X * b, a.Y * b, a.Z * b);
        }

        public static Coord3d operator *(double b, Coord3d a)
        {
            return new Coord3d(a.X * b, a.Y * b, a.Z * b );
        }


        public static double operator *(Coord3d a, Coord3d b)
        {
            return (a.X * b.X + a.Y * b.Y + a.Z * b.Z);
        }


    };


}
