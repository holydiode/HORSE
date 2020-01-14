using System;
using System.Collections.Generic;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HORSE
{
    abstract class Texture
    {
        //точка отрисовки
        protected Coord2d startPoint;

        //нарисовать текстуру
        public virtual void Drow()
        {  
        }

        //поврнуть текстуру
        public virtual void Rotate(double rad)
        {
        }
    }
}
