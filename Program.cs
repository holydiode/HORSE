using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Drawing;



namespace HORSE
{
    //класс платформы
    class Platform : Physics
    {
        //подключаем к платформам мяч
        public static Physics linkBall;
        //создаём поле для HP-бара
        protected HPbar HPBar;
        //создаём поле для UP-бфра
        protected UPbar UPBar;

        
        public Platform() : base()
        {
            this.Status = false;
            //устанавливаем треугольную форму
            this.Hitbox.RegularPolygon(3, 0.13);
            this.Texture = new TextureFigure(this.Hitbox);
            //запрещаем выходить за пределы экрана
            this.SetSolidBoderRule();
            //делаем объект недвижимым
            this.Mass = 0;

            HPBar = new HPbar();
            UPBar = new UPbar();

            //устанавливаем свойство востановления здаровья при соударении с мячом
            this.SetBehavior(new Colission(linkBall, () =>
            {
                if (this.HPBar.HP < 100)
                {
                    this.HPBar.HP += 5;
                }
            }
            ));
            //Устанавливаем связь с барами
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


    class Player : Platform {
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

    class PlayerTwo : Platform
    {
        public PlayerTwo() : base()
        {
            this.SetArcanoidBehaivor(0.01f, "j", "l");
            this.Position = new Coord3d(0, 0.70f, 0);

            this.SetBehavior(new KeyHold("i", () => this.Rotate(0.1)));
            this.SetBehavior(new KeyHold("k", () => this.Rotate(-0.1)));

            this.SetBehavior(new KeyHold("o", () => { if (UPBar.UP >= 20) { UPBar.UP -= 20; linkBall.Speed *= (linkBall.Speed.len() + 0.001) / linkBall.Speed.len(); } }));
            this.SetBehavior(new KeyHold("u", () => { if (UPBar.UP >= 20) { UPBar.UP -= 20; linkBall.Speed *= (linkBall.Speed.len() - 0.001) / linkBall.Speed.len(); } }));
        }
    }


    class Enemy : Platform
    {
        public Enemy() : base()
        {
            this.SetBehavior(new FrameActivity(() => { if (this.Position.X > linkBall.Position.X) this.Position.X -= 0.01; else this.Position.X += 0.01; }, 9));
            this.SetBehavior(new FrameActivity(() => { Random rand = new Random((int)(this.Position.X * 100)); if (rand.Next(100) <= 10) this.Rotate(0.1); }, 9));
            this.SetBehavior(new FrameActivity(() => { Random rand = new Random((int)((linkBall.Position.X + this.Position.X) * 100)); if (rand.Next(100) <= 2) this.Rotate(-0.1); }, 9));
            this.Position = new Coord3d(0, 0.70f, 0);
        }
    }


    class Ball : Physics
    {
        public Ball() : base() {

            this.Status = false;

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

        public static Finish finish;

        public HPbar() : base()
        {
            this.Position = new Coord3d(0.15, 0.15, 0);
            HP = 100;

            this.Hitbox.Square(new Coord2d(0.005, -0.15 * HP / 100));
            this.Texture = new TextureFigure(this.Hitbox);
            ((TextureFigure)this.Texture).FillColor = Color.Green;
            ((TextureFigure)this.Texture).BorderColor = Color.Green;
            this.SetBehavior(new FrameActivity(() => { this.Hitbox.Square(new Coord2d(0.005, -0.15 * HP / 100)); if (HP >= 0) HP -= 0.05; }));

            this.SetBehavior(new FrameActivity(() => { if (HP <= 0) { finish.Status = true; } }));
            this.SetBehavior(new ShowActivity(() => { this.HP = 100; }));
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
            this.SetBehavior(new FrameActivity(() => { this.Hitbox.Square(new Coord2d(0.005, -0.15 * UP / 100)); if (UP < 100) UP += 0.05; }));
            this.SetBehavior(new ShowActivity(() => { this.UP = 100; }));
            
        }
    }



    class Center : GravityPoint
    {
        public Center()
        {
            this.Position = new Coord3d(0, 0, 0);
            this.power = 0.0003;
        }
    }

    class Menu : Active {

        public List<GameObject> OnePlayerColections;
        public List<GameObject> TwoPlayerColections;


        public Menu() : base()
        {

            OnePlayerColections = new List<GameObject>();
            TwoPlayerColections = new List<GameObject>();
            this.Position = new Coord3d(-0.5, 0.5, 0);
            this.Hitbox.Square(new Coord2d(1, -1));
            this.Texture = new TextureFigure(this.Hitbox);
            for (int i = 0; i < 3; i++)
            {
                this.SetChild(new Button());
                this.children[i].Position = new Coord3d(0.1, -0.5 - 0.22 * i, 0);

            }
            this.SetChild(new Text("POLIBIUS", 100));
            this.children[3].Position = new Coord3d(0.1, -0.2, 0);
            ((Active)this.children[0]).SetBehavior(new OnClick("left", () =>
            {
                foreach (GameObject currentObject in OnePlayerColections)
                {
                    currentObject.Status = true;
                }
                this.Status = false;
            }));
            this.children[0].SetChild(new Text("1 игрок", 90, Color.White, Color.Salmon));
            ((Active)this.children[1]).SetBehavior(new OnClick("left", () =>
            {
                foreach (GameObject currentObject in TwoPlayerColections)
                {
                    currentObject.Status = true;
                }
                this.Status = false;
            }));
            this.children[1].SetChild(new Text("2 игрока", 90, Color.White, Color.Salmon));
            ((Active)this.children[2]).SetBehavior(new OnClick("left", () =>
            {
                Core.Window.Close();
            }));

            this.children[2].SetChild(new Text("выход", 90, Color.White, Color.Salmon));
        }
    }


    class Finish : Active{
        public static Menu startmenu;

        public Finish():base()
        {
            this.Status = false;
            this.Position = new Coord3d(-0.5, 0.5, 0);
            this.Hitbox.Square(new Coord2d(1, -1));
            this.Texture = new TextureFigure(this.Hitbox);

            for (int i = 0; i < 2; i++)
            {
                this.SetChild(new Button());
                this.children[i].Position = new Coord3d(0.1, -0.77 - 0.22 * i, 0);
            }

            this.SetBehavior(new ShowActivity(() =>
            {
                foreach(GameObject  currentObject in Core.MainScene.StaticObjects)
                {
                    currentObject.Status = false;
                }
                this.Status = true;
            }));

            ((Active)this.children[0]).SetBehavior(new OnClick("left", () =>
            {
                this.Status = false;
                startmenu.Status = true;
            }));

            this.children[0].SetChild(new Text("далее", 90, Color.White, Color.Salmon));

            ((Active)this.children[1]).SetBehavior(new OnClick("left", () =>
            {
                Core.Window.Close();
            }));
            this.children[1].SetChild(new Text("выход", 90, Color.White, Color.Salmon));

            this.SetChild(new Text("Конец игры", 100));
            this.children[2].Position = new Coord3d(0.05, -0.2, 0);

        }
    }   

    class Button : Active
    {
        public Button(){
            this.Hitbox.Square(new Coord2d(0.8, 0.2));
            this.Texture = new TextureFigure(this.Hitbox);
            ((TextureFigure)this.Texture).FillColor = Color.Salmon;
        }
    }


    class Text : GameObject
    {
        public Text(string title, int size) : base( )
        {
            this.Texture = new TextTexture(title, size);
        }
        public Text(string title, int size, Color textColor, Color fillColor) : base()
        {
            this.Texture = new TextTexture(title, size, textColor, fillColor);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Core game = new Core(800, 800);
            Menu menu = new Menu();
            Core.MainScene.Add(menu);

            Finish.startmenu = menu;
            Finish finish = new Finish();

            HPbar.finish = finish;

            Ball ball = new Ball();
            Platform.linkBall = ball;
            UPbar.linkball = ball;

            Barrow barrow = new Barrow();
            Player player = new Player();
            Enemy enemy = new Enemy();
            Center center = new Center();
            PlayerTwo playerTwo = new PlayerTwo();


            Core.MainScene.Add(ball);
            Core.MainScene.Add(player);
            Core.MainScene.Add(enemy);
            Core.MainScene.Add(center);
            Core.MainScene.Add(barrow);
            Core.MainScene.Add(playerTwo);
            Core.MainScene.Add(finish);
            menu.OnePlayerColections.Add(ball);
            menu.OnePlayerColections.Add(player);
            menu.OnePlayerColections.Add(center);
            menu.OnePlayerColections.Add(enemy);
            menu.OnePlayerColections.Add(barrow);
            menu.TwoPlayerColections.Add(ball);
            menu.TwoPlayerColections.Add(player);
            menu.TwoPlayerColections.Add(center);
            menu.TwoPlayerColections.Add(playerTwo);
            menu.TwoPlayerColections.Add(barrow);
            game.Run();
        }
    }


}

