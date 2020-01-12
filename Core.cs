using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace HORSE
{
    class Core
    {
        private static Scene mainScene;
        private static GameObject currentObject;


        private static int width;

        private static int height;

        internal static GameObject CurrentObject { get => currentObject; set => currentObject = value; }
        internal static Scene MainScene { get => mainScene; set => mainScene = value; }
        public static GameWindow Window { get => window; set => window = value; }
        public static int Width { get => width; set => width = value; }
        public static int Height { get => height; set => height = value; }

        private static GameWindow window;

        public Core()
        {
            currentObject = null;
            mainScene = new Scene();
        }


        public void Run()
        {


            Mouse.SetPosition(0, 0);

            height = 800;
            width = 800;

            window = new GameWindow(width, height);

            window.Load += (sender, e) =>
            {
                
            };


            window.RenderFrame += (sender, e) =>
            {

                foreach (Physics curent in mainScene.PhysicsObjects)
                {
                    currentObject = curent;
                    curent.Move();
                }

                foreach (Active curent in mainScene.DinamicObjects)
                {
                    currentObject = curent;
                    curent.Run();
                }

                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.ClearColor(Color4.Black);


                foreach (GameObject curent in mainScene.StaticObjects)
                {
                    currentObject = curent;
                    currentObject.Drow();
                }


                window.SwapBuffers();
            };

            window.Run();
        }
    }



}
