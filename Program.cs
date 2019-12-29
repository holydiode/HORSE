using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Platform : Physics
    {
        public Platform() : base()
        {
            Geometry cheracter = new Geometry();
            cheracter.Square(new Coord2d(0.2f, 0.02f));
            this.Texture = new TextureFigure(cheracter);
            this.Hitbox.Square(new Coord2d(0.2f, 0.02f));
        }
    };

    class Player: Platform{
        public Player() : base()
        {

            this.SetArcanoidBehaivor(0.05f);
            this.SetSolidBoderRule();
            this.Position = new Coord3d(0, -0.90f, 0);
        }
    }

    class Enemy : Platform
    {
        public Enemy() : base()
        {
            this.Position = new Coord3d(0, 0.90f, 0);
        }
    }


    class Ball: Physics
    {
        public Ball() : base() {


            Geometry cheracter = new Geometry();
            cheracter.Square(new Coord2d(0.02f, 0.02f));
            this.Texture = new TextureFigure(cheracter);

            this.Hitbox.Square(new Coord2d(0.02f, 0.02f));
            this.Position = new Coord3d(0, 0, 0);

            this.Speed = new Coord2d(-0.008f, -0.005f);

            this.SetBallBorderRule();

        }
    }




    class Program
    {



        static void Main(string[] args)
        {
            Core game = new Core();
            Player player = new Player();
            Enemy enemy = new Enemy();
            Ball ball = new Ball();
            

            
            Core.MainScene.Add(ball);
            Core.MainScene.Add(player);
            Core.MainScene.Add(enemy);

            game.Run();
        }
    }
}
