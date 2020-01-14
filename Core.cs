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
        //главная сцена
        private static Scene mainScene;
        //текущий обрабатываемый объект
        private static GameObject currentObject;

        //длинна окна
        private static int width;
        //высота окна
        private static int height;

        internal static GameObject CurrentObject { get => currentObject; set => currentObject = value; }
        internal static Scene MainScene { get => mainScene; set => mainScene = value; }
        public static GameWindow Window { get => window; set => window = value; }
        public static int Width { get => width; set => width = value; }
        public static int Height { get => height; set => height = value; }

        private static GameWindow window;

        //создание окна поумолчанию размером 800px X 800px
        public Core()  
        {
            currentObject = null;
            mainScene = new Scene();

            height = 800;
            width = 800;
        }

        //создание окна заданного размера
        public Core(int weight, int height)
        {
            currentObject = null;
            mainScene = new Scene();

            Width = weight;
            Height = height;
        }

        //запуск игры
        public void Run()
        {

            Mouse.SetPosition(0, 0);

            window = new GameWindow(width, height);

            window.Load += (sender, e) =>
            {
                
            };

            window.RenderFrame += (sender, e) =>
            {
                //обработка физических объектов
                foreach (Physics curent in mainScene.PhysicsObjects)
                {
                    currentObject = curent;
                    curent.Move();
                }
                //выполнение всех функция динамических объектов
                foreach (Active curent in mainScene.DinamicObjects)
                {
                    currentObject = curent;
                    curent.Run();
                }
                //очистка буфера
                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.ClearColor(Color4.Black);

                //отрисовка объектов
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
