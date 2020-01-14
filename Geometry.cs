using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Geometry
    {
        //точки тела
        private List<Coord2d> points;
        //левая граница тела
        private double leftBorder;
        //правая граница тела
        private double rightBorder;
        //верхняя граница тела
        private double upBorder;
        //нижняя граница тела
        private double bottomBorder;
        //количество точек в полигоне
        private int complexity;

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

        public void Add(Coord2d a)
        {
            this.points.Add(a);
            this.complexity++;
        }

        public void Add(List<Coord2d> a)
        {
            this.points.AddRange(a);
            this.complexity += a.Count;
        }


        //создание правильного n-угольника, вписаного в окружность радиуса rad
        public void RegularPolygon(int n, double rad)
        {
            points.Clear();

            for (int i = 0; i < n; i++)
            {
                points.Add(new Coord2d(rad * Math.Cos(i * 2 * Math.PI / n), rad * Math.Sin(i * 2 * Math.PI / n)));
            }

            RecountBorder();
            this.complexity = n;
        }

        //создание прямоугольника, с вектор-диаганалью point
        public void Square(Coord2d point) {
            points.Clear();

            points.Add(new Coord2d(point.X, point.Y));
            points.Add(new Coord2d(0, point.Y));
            points.Add(new Coord2d(0, 0));
            points.Add(new Coord2d(point.X, 0));
            RecountBorder();
            this.complexity = 4;
        }


        // возвращает n ближайших точек к заданной точки point
        public List<Coord2d> FindNearPoint(int n, Coord2d point)
        {
            List<Coord2d> nearPoint = new List<Coord2d>();

            List<Coord2d> sortedPoint = new List<Coord2d>();

            foreach(Coord2d currentPoint in this.Points)
            {
                sortedPoint.Add(currentPoint);
            }

            sortedPoint.Sort((Coord2d a, Coord2d b) => { if (a.len(point) > b.len(point)) return 1; else return 0; });


            for (int i = 0; i < n; i++)
            {
                nearPoint.Add(sortedPoint[i]);
            }

            return nearPoint;
        }

        // Находит ближайшую прямую к точке point со звигом move
        public List<Coord2d> FindNearStraight(Coord2d point, Coord2d move)
        {

            List<Coord2d> straight = new List<Coord2d>();
            double min = 2; 

            for (int i = 0, j = this.Complexity - 1; i < this.Complexity; j = i++)
            {
                double len = Math.Abs((Points[j].Y - Points[i].Y) * point.X  - (Points[j].X - Points[i].X) * point.Y + (Points[j].X + move.X) * (Points[i].Y + move.Y) - (Points[j].Y + move.Y) * (Points[i].X + move.X)) / Math.Sqrt((Points[j].Y - Points[i].Y) * (Points[j].Y - Points[i].Y) + (Points[j].X - Points[i].X) * (Points[j].X - Points[i].X));
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

        // Находит ближайшую прямую к точке point со звигом move и возвращает растояния межу точкой и прямой
        public List<Coord2d> FindNearStraight(Coord2d point, Coord2d move, out double leng)
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

            leng = min;

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



    }

}
