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

        private float leftBorder;
        private float rightBorder;
        private float upBorder;
        private float bottomBorder;
        private float middleBorder;

        private int complexity;



        public float LeftBorder { get => leftBorder; set => leftBorder = value; }
        public float RightBorder { get => rightBorder; set => rightBorder = value; }
        public float UpBorder { get => upBorder; set => upBorder = value; }
        public float BottomBorder { get => bottomBorder; set => bottomBorder = value; }
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

            this.complexity = 4;
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

        public float[] GeometryToArrat()
        {
            float[] array = new float[this.complexity * 3];
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
