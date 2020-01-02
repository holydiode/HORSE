using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Geometry
    {
        private List<Coord2d> points;

        private double leftBorder;
        private double rightBorder;
        private double upBorder;
        private double bottomBorder;
        private double middleBorder;

        private int complexity;
        private readonly float X;

        public double LeftBorder { get => leftBorder; set => leftBorder = value; }
        public double RightBorder { get => rightBorder; set => rightBorder = value; }
        public double UpBorder { get => upBorder; set => upBorder = value; }
        public double BottomBorder { get => bottomBorder; set => bottomBorder = value; }
        public int Complexity { get => complexity; set => complexity = value; }
        internal List<Coord2d> Points { get => points; set => points = value; }

        public Geometry()
        {
            points = new List<Coord2d>();
        }
        public void Square(Coord2d point) {
            points.Clear();
            points.Add(new Coord2d(point.X, point.Y));
            points.Add(new Coord2d(point.X, 0));
            points.Add(new Coord2d(0, 0));
            points.Add(new Coord2d(0, point.Y));


            RecountBorder();

            this.complexity = 4;
        }


        public List<Coord2d> FindNearPoint(int count, Coord2d point)
        {
            List<Coord2d> nearPoint = new List<Coord2d>();

            List<Coord2d> sortedPoint = new List<Coord2d>();

            foreach(Coord2d currentPoint in this.Points)
            {
                sortedPoint.Add(currentPoint);
            }

            sortedPoint.Sort((Coord2d a, Coord2d b) => { if (a.len(point) > b.len(point)) return 1; else return 0; });


            for (int i = 0; i < count; i++)
            {
                nearPoint.Add(sortedPoint[i]);
            }

            return nearPoint;
        }


        public List<Coord2d> FindNearStraight(Coord2d point, Coord2d move)
        {

            List<Coord2d> straight = new List<Coord2d>();
            double min = 2; 

            for (int i = 0, j = this.Complexity - 1; i < this.Complexity; j = i++)
            {
                double len = Math.Abs((Points[j].Y - Points[i].Y) * point.X - (Points[j].X - Points[i].X) * point.Y + (Points[j].X + move.X) * (Points[i].Y + move.Y) - (Points[j].Y + move.Y) * (Points[i].X + move.X)) / Math.Sqrt((Points[j].Y - Points[i].Y) * (Points[j].Y - Points[i].Y) + (Points[j].X - Points[i].X) * (Points[j].X - Points[i].X));
                if (len < min)
                {
                    min = len;
                    straight.Clear();
                    straight.Add(Points[i]);
                    straight.Add(Points[j]);
                }
            }

            return straight;
        }



        public void RecountBorder()
        {
            if (points.Count != 0) {

                leftBorder = points[0].X;
                rightBorder = points[0].X;
                upBorder = points[0].Y;
                bottomBorder = points[0].Y;
                foreach (Coord2d current in points) {
                    if(current.X < leftBorder)
                    {
                        leftBorder = current.X;
                    }
                    if(current.X > rightBorder)
                    {
                        rightBorder = current.X;
                    }
                    if (current.Y < bottomBorder)
                    {
                        bottomBorder = current.Y;
                    }
                    if (current.X > upBorder)
                    {
                        upBorder = current.Y;
                    }
                }
            }
        }

        public double[] GeometryToArrat()
        {
            double[] array = new double[this.complexity * 3];
            int i = 0;
            foreach (Coord2d point in this.points){
                array[i*3] = point.X;
                array[i*3 + 1] = point.Y;
                array[i*3 + 2] = 0;
                i++;
            }
            return array;
        }

    }
}
