using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace HORSE
{
    class Coord2d
    {
        protected double x;
        protected double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Coord2d(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public Coord2d() {
            this.x = x;
            this.y = y;
        }

        public void ScreenToScene() {



            //Console.WriteLine("{0} {1}", X, Y);

            Point transfer = Core.Window.PointToClient(new Point((int)x, (int)y));

            //Console.WriteLine("{0} {1}", transfer.X, transfer.Y);




            this.x = (float)transfer.X / Core.Width * 2 - 1;
            this.y = 1 - (float)transfer.Y / Core.Height * 2;


        }
        public double len()
        {
            return (Math.Sqrt(x * x + y * y));
        } 
        
        
        
        public double len(Coord2d point)
        {
            return (Math.Sqrt((x - point.x ) * (x - point.x) + (y - point.y) * (y - point.y)));
        }


        public static Coord2d operator +(Coord2d a, Coord2d b)
        {
            return new Coord2d(a.X + b.X, a.Y + b.Y);
        }

        public static Coord2d operator -(Coord2d a, Coord2d b)
        {
            return new Coord2d(a.X - b.X, a.Y - b.Y);
        }


        public static Coord2d operator /(Coord2d a, double b)
        {
            return new Coord2d(a.X / b, a.Y / b);
        }


        public static Coord2d operator *(Coord2d a, double b)
        {
            return new Coord2d(a.X * b, a.Y * b);
        }

        public static Coord2d operator *( double b, Coord2d a)
        {
            return new Coord2d(a.X * b, a.Y * b);
        }


        public static double operator *(Coord2d a, Coord2d b)
        {
            return (a.X * b.X + a.Y * b.Y);
        }

    }
}
