using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;


namespace HORSE  
{
    class Platform : Physics
    {
        public static Physics linkBall;

        public Platform() : base()
        {
            Geometry cheracter = new Geometry();
            cheracter.Square(new Coord2d(0.2f, 0.02f));
            this.Texture = new TextureFigure(cheracter);
            this.Hitbox.Square(new Coord2d(0.2f, 0.02f));
            this.SetSolidBoderRule();
            this.mass = 0;
            // this.SetBehavior(new Colission(linkBall, () => { linkBall.Speed.Y = -1 * (linkBall.Speed.Y + 0.0001f); }));
        }
    };

    class Player: Platform{
        public Player() : base()
        {
            this.SetArcanoidBehaivor(0.03f);
            this.Position = new Coord3d(0, -0.90f, 0);
        }
    }

    class Enemy : Platform
    {
        public Enemy() : base()
        {
            this.SetBehavior(new FrameActivity(() => { this.Position.X = linkBall.Position.X - 0.1f;}, 9));
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
            this.mass = 1;
        }
    }




    class Program
    {



        static void Main(string[] args)
        {
            Core game = new Core();

            Ball ball = new Ball();
            Platform.linkBall = ball;


            Player player = new Player();
            Enemy enemy = new Enemy();
            

           

            Core.MainScene.Add(ball);
            Core.MainScene.Add(player);
            Core.MainScene.Add(enemy);

            game.Run();
        }
    }
}
