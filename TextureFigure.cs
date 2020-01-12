﻿using System;
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
        private Geometry border;
        private int borderWidth;
        private Color fillColor;
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
                borderWidth = 100;
        }

        public override void Drow() {


            GL.Begin(PrimitiveType.TriangleFan);

            GL.Color3(this.fillColor);

            foreach (Coord2d point in border.Points)
            {
                Coord2d finish = point + startPoint + Core.CurrentObject.GetPosition();
                GL.Vertex3(finish.X, finish.Y, 0);
            }

            GL.End();


            GL.Begin(PrimitiveType.LineLoop);

            GL.Color3(this.borderColor);

            GL.LineWidth(this.borderWidth);

            foreach (Coord2d point in border.Points)
            {
                Coord2d finish = point + startPoint + Core.CurrentObject.GetPosition();
                GL.Vertex3(finish.X, finish.Y, 0);
            }

            GL.End();
        }

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
