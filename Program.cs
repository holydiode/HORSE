using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Program
    {
        static void Main(string[] args)
        {
            Core game = new Core();
            GameObject pix = new GameObject();
            GameObject pix2 = new GameObject();
            pix.Position = new Coord3d(0.2f, 0.5f, 0.3f);
            pix2.Position = new Coord3d(-0.2f, -0.5f, -0.3f);
            Core.MainScene.Add(pix);
            Core.MainScene.Add(pix2);
            game.Run();
        }
    }
}
