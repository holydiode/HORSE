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

        public float LeftBorder { get => leftBorder; set => leftBorder = value; }
        public float RightBorder { get => rightBorder; set => rightBorder = value; }
        public float UpBorder { get => upBorder; set => upBorder = value; }
        public float BottomBorder { get => bottomBorder; set => bottomBorder = value; }

        public void Square(Coord2d point) {
            points.Add(new Coord2d(0, 0));
            points.Add(new Coord2d(0, point.Y));
            points.Add(new Coord2d(point.X, 0));
            points.Add(new Coord2d(point.X, point.Y));
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
