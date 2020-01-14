using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


namespace HORSE
{
    class TextureFigure:Texture
    {
        //граница
        private Geometry border;
        //цвет заливки
        private Color fillColor;
        //цвет обводки
        private Color borderColor;

        internal Geometry Border { get => border; set => border = value; }
        public Color FillColor { get => fillColor; set => fillColor = value; }
        public Color BorderColor { get => borderColor; set => borderColor = value; }

        public TextureFigure()
        {
            startPoint = new Coord2d(0, 0);
            border = new Geometry();
        }
       
        public TextureFigure(Geometry border){
                startPoint = new Coord2d(0, 0);
                this.border = border;
                fillColor = Color.White;
                borderColor = Color.Red;
        }

        public TextureFigure(Geometry border, Color fillColor, Color borderColor)
        {
            startPoint = new Coord2d(0, 0);
            this.border = border;
            this.fillColor = fillColor;
            this.borderColor = borderColor;
        }

        public override void Drow() {

            if (this.fillColor != null)
            {
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Color3(this.fillColor);
                foreach (Coord2d point in border.Points)
                {
                    Coord2d finish = point + startPoint + Core.CurrentObject.GetPosition();
                    GL.Vertex3(finish.X, finish.Y, 0);
                }
                GL.End();
            }



            if (this.borderColor != null) { 
                GL.Begin(PrimitiveType.LineLoop);
                GL.Color3(this.borderColor);
                foreach (Coord2d point in border.Points)
                {
                    Coord2d finish = point + startPoint + Core.CurrentObject.GetPosition();
                    GL.Vertex3(finish.X, finish.Y, 0);
                }
                GL.End();
            }
        }

        //поворот текстуры
        public override void Rotate(double rad)
        {
            foreach (Coord2d currentPoint in this.border.Points)
            {
                currentPoint.X = currentPoint.X * Math.Cos(rad) - currentPoint.Y * Math.Sin(rad);
                currentPoint.Y = currentPoint.X * Math.Sin(rad) + currentPoint.Y * Math.Cos(rad);
            }
        }


    }
}
