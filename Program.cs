using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;

using System.Drawing;



namespace HORSE  
{
    class Platform : Physics
    {
        public static Physics linkBall;

        protected HPbar HPBar;
        protected UPbar UPBar;


        public Platform() : base()
        {

            this.Hitbox.RegularPolygon(3, 0.13);
            this.Texture = new TextureFigure(this.Hitbox);
            this.SetSolidBoderRule();
            this.Mass = 0;

            HPBar = new HPbar();
            UPBar = new UPbar();

            this.SetBehavior(new Colission(linkBall, () =>
            {
                if (this.HPBar.HP < 100)
                {
                    this.HPBar.HP += 5;
                }
            }
            ));


            this.SetChild(HPBar);
            this.SetChild(UPBar);
        }
    }

    class Barrow : Platform
    {
        public Barrow() : base()
        {
           this.Hitbox.RegularPolygon(32, 0.13);


           this.children.Clear();
        }
    }


    class Player: Platform{
        public Player() : base()
        {
            this.SetArcanoidBehaivor(0.01f);
            this.Position = new Coord3d(0, -0.70f, 0);

            this.SetBehavior(new KeyHold("w", () => this.Rotate(0.1)));
            this.SetBehavior(new KeyHold("s", () => this.Rotate(-0.1)));

            this.SetBehavior(new KeyHold("e", () => { if (UPBar.UP >= 20) { UPBar.UP -= 20; linkBall.Speed *= (linkBall.Speed.len() + 0.001) / linkBall.Speed.len(); } }));
            this.SetBehavior(new KeyHold("q", () => { if (UPBar.UP >= 20) { UPBar.UP -= 20; linkBall.Speed *= (linkBall.Speed.len() - 0.001) / linkBall.Speed.len(); } }));


        }
    }


    class Enemy : Platform
    {
        public Enemy() : base()
        {
            this.SetBehavior(new FrameActivity(() => { if (this.Position.X > linkBall.Position.X) this.Position.X -= 0.01; else this.Position.X += 0.01; }, 9));
            this.SetBehavior(new FrameActivity(() => { Random rand = new Random((int)(this.Position.X * 100)); if (rand.Next(100) <= 10) this.Rotate(0.1); },  9));
            this.SetBehavior(new FrameActivity(() => { Random rand = new Random((int)(this.Position.X * 100)); if (rand.Next(100) <= 2) this.Rotate(-0.1); },  9));
            this.Position = new Coord3d(0, 0.70f, 0);
        }
    }


    class Ball: Physics
    {
        public Ball() : base() {

            Geometry cheracter = new Geometry();
            cheracter.Square(new Coord2d(0.02f, 0.02f));
            this.Texture = new TextureFigure(cheracter);

            this.Hitbox.Square(new Coord2d(0.02f, 0.02f));
            this.Position = new Coord3d(-0.5, -0.5, 0);

            this.Speed = new Coord2d(-0.015f, -0.016f);

            Console.Out.WriteLine(Speed.len());

            this.Mass = 1;
        }
    }


    class HPbar : Active
    {
        private double hP;

        public HPbar() : base()
        {
            this.Position = new Coord3d(0.15, 0.15, 0);
            HP = 100;


            this.Hitbox.Square(new Coord2d(0.005, -0.15 * HP/100));
            this.Texture = new TextureFigure(this.Hitbox);
            ((TextureFigure)this.Texture).FillColor = Color.Green;
            ((TextureFigure)this.Texture).BorderColor = Color.Green;



            this.SetBehavior(new FrameActivity(() => { this.Hitbox.Square(new Coord2d(0.005, -0.15 * HP / 100)); if (HP > 0) HP -= 0.01; }));


        }

        public double HP { get => hP; set => hP = value; }
    }


    class UPbar : Active
    {

        public static Physics linkball;

        protected double up;

        public double UP { get => up; set => up = value; }

        public UPbar() : base()
        {
            this.Position = new Coord3d(0.20, 0.15, 0);
            UP = 100;


            this.Hitbox.Square(new Coord2d(0.005, -0.15 * UP / 100));
            this.Texture = new TextureFigure(this.Hitbox);
            ((TextureFigure)this.Texture).FillColor = Color.Orange;
            ((TextureFigure)this.Texture).BorderColor = Color.Orange;

            this.SetBehavior(new FrameActivity(() => { this.Hitbox.Square(new Coord2d(0.005, -0.15 * UP / 100)); if (UP < 100) UP+= 0.05; }));

        }
    }



    class Center: GravityPoint
    {
        public Center()
        {
            this.Position = new Coord3d(0, 0, 0);
            this.power = 0.0003;
        }
    }


    class Program
    {

        static void Main(string[] args)
        {


            Core game = new Core();

            Ball ball = new Ball();
            Platform.linkBall = ball;
            UPbar.linkball = ball;

            Barrow barrow = new Barrow();


            Player player = new Player();
            Enemy enemy = new Enemy();

            Center center = new Center();
            

            Core.MainScene.Add(ball);
            Core.MainScene.Add(player);
            Core.MainScene.Add(enemy);
            Core.MainScene.Add(center);
            Core.MainScene.Add(barrow);

            game.Run();
        }
    }



    }
