using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;

namespace HORSE
{



    class TextTexture : Texture
    {
        private string title;
        private int size;
        private int ID;

        private Color textColor;
        private Color fillColor;


        public TextTexture() {
            ID = 0;
            title = "boopa and loopa";
            size = 25;
            startPoint = new Coord2d();

            textColor = Color.Black;
            fillColor = Color.White;
        }

        public TextTexture(string title, int size)
        {
            ID = 0;
            this.title = title;
            this.size = size;
            startPoint = new Coord2d();

            textColor = Color.Black;
            fillColor = Color.White;
        }


        public TextTexture(string title, int size, Color textColor, Color fillColor)
        {
            ID = 0;
            this.title = title;
            this.size = size;
            startPoint = new Coord2d();

            this.textColor = textColor;
            this.fillColor = fillColor;

        }



        public override void Drow()
        {
            while(this.ID == 0)
            {
                this.load();
            }

            
            
            GL.Enable(EnableCap.Texture2D);



            if (Core.CurrentObject.Parent != null && Core.CurrentObject.Parent.Texture is TextureFigure)
            {
                GL.Color3(((TextureFigure)Core.CurrentObject.Parent.Texture).FillColor);
            }

            GL.BindTexture(TextureTarget.Texture2D, ID);

            GL.Begin(PrimitiveType.Quads);
            
            GL.Vertex3(0 + startPoint.X + Core.CurrentObject.GetPosition().X, 0 + startPoint.Y + Core.CurrentObject.GetPosition().Y, 0);
            GL.TexCoord2(1, 1);

            GL.Vertex3(title.Length * (size * 0.75)/ Core.Width + startPoint.X + Core.CurrentObject.GetPosition().X, 0 + startPoint.Y + Core.CurrentObject.GetPosition().Y, 0);
            GL.TexCoord2(1, 0);


            GL.Vertex3(title.Length * (size * 0.75) / Core.Width + startPoint.X + Core.CurrentObject.GetPosition().X, (size * 1.2) / Core.Height + startPoint.Y + Core.CurrentObject.GetPosition().Y, 0);
            GL.TexCoord2(0, 0);

            GL.Vertex3(0 + startPoint.X + Core.CurrentObject.GetPosition().X, (size * 1.2) / Core.Height + startPoint.Y + Core.CurrentObject.GetPosition().Y, 0);
            GL.TexCoord2(0, 1);
        
            GL.End();
            GL.Disable(EnableCap.Texture2D);


        }


        public void load()
        {
            Bitmap imagine = new Bitmap(title.Length * (int)(size * 0.85), (int)(size * 1.2));
            Graphics graphic = Graphics.FromImage(imagine);
            graphic.Clear(Color.White);

            graphic.DrawString(this.title, new Font("Tempus Sans ITC", size, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, -size/4);


            ID = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, ID);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            BitmapData bmp_data = imagine.LockBits(new Rectangle(0, 0, imagine.Width, imagine.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);


            imagine.UnlockBits(bmp_data);
        }



    }

    
}
