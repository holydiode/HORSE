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
        internal static GameObject CurrentObject { get => currentObject; set => currentObject = value; }
        internal static Scene MainScene { get => mainScene; set => mainScene = value; }
        public static GameWindow Window { get => window; set => window = value; }

        private static GameWindow window;

        public Core()
        {
            currentObject = null;
            mainScene = new Scene();
        }


        public void Run()
        {
            window = new GameWindow();
            

            window.RenderFrame += (sender, e) =>
            {
                foreach (Active curent in mainScene.DinamicObjects)
                {
                    currentObject = curent;
                    curent.Run();
                }

                foreach (GameObject curent in mainScene.StaticObjects)
                {
                    GL.ClearColor(Color4.Black);
                    GL.Clear(ClearBufferMask.ColorBufferBit);

                    currentObject = curent;
                    currentObject.Drow();
                }
                window.SwapBuffers();
            };

            window.Run();
        }
    }



}
