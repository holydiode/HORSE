using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Physics : Active
    {
        protected float mass;
        private Coord2d speed;
        protected float inertia;
        protected Coord2d massCenter;
        protected int layerColision;

        internal Coord2d Speed { get => speed; set => speed = value; }

        public Physics():base(){
            speed = new Coord2d();
            layerColision = 0;
            inertia = 1;
        }

        public void Move() {
            this.Position = this.Position + speed;
            this.Hit();
        }



        public void Hit() {
            foreach (Physics currentObject in Core.MainScene.PhysicsObjects) {
                if (this.layerColision == currentObject.layerColision && this != currentObject)
                {
                    foreach (Coord2d currentPoint in currentObject.Hitbox.Points)
                    {
                        if (this.PointInObject(currentPoint + currentObject.GetPosition()))
                        {
                            double impulsX = this.speed.X * this.mass + currentObject.speed.X * currentObject.mass;
                            double impulsY = this.speed.Y * this.mass + currentObject.speed.Y * currentObject.mass;

                            List<Coord2d> near = currentObject.Hitbox.FindNearStraight(currentPoint, currentObject.GetPosition());

                            Coord2d moveFirst = new Coord2d(-1 * (near[1].Y - near[0].Y), near[1].X - near[0].X);
                            Coord2d moveSecond = moveFirst * -1;


                            if (this.mass != 0)
                            {
                                this.speed = moveSecond / moveSecond.len() / this.mass;
                                this.speed.X *= impulsX;
                                this.speed.Y *= impulsY;
                            }

                            if (currentObject.mass != 0)
                            {
                                currentObject.speed = moveFirst / moveFirst.len() / currentObject.mass;

                                currentObject.speed.X *= impulsX;
                                currentObject.speed.Y *= impulsY;
                            }

                        }
                    }
                }
            }
        }


        public void SetBallBorderRule()
        {
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.RightBorder + this.GetPosition().X > 1) { this.speed.X = -1 * this.speed.X; } }));
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.LeftBorder + this.GetPosition().X < -1) { this.speed.X = -1 * this.speed.X; } }));
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.UpBorder + this.GetPosition().Y > 1)     {this.speed.Y = -1 * this.speed.Y; } }));
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.BottomBorder + this.GetPosition().Y < -1) { this.speed.Y = -1 * this.speed.Y; } }));
        }


        public new void SetTopDownBehaivor(float speed)
        {
            this.Activities.Add(new KeyHold("w", () => this.Speed.Y += speed));
            this.Activities.Add(new KeyHold("s", () => this.Speed.Y -= speed));
            this.Activities.Add(new KeyHold("a", () => this.Speed.X -= speed));
            this.Activities.Add(new KeyHold("d", () => this.Speed.X += speed));

            this.Activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }


        public new void SetArcanoidBehaivor(float speed)
        {
            this.Activities.Add(new KeyUp("a", () => this.Speed.X = 0));
            this.Activities.Add(new KeyUp("d", () => this.Speed.X = 0));
            this.Activities.Add(new KeyHold("a", () => this.Speed.X = -speed));
            this.Activities.Add(new KeyHold("d", () => this.Speed.X = speed));

            this.Activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }

        public new void SetSolidBoderRule()
        {
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.RightBorder + this.GetPosition().X > 1) { this.Position.X -= this.GetPosition().X + this.Hitbox.RightBorder - 1; speed.X = 0; } }));
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.LeftBorder + this.GetPosition().X < -1) { this.Position.X -= this.Hitbox.LeftBorder + this.GetPosition().X + 1; speed.X = 0; } }));
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.UpBorder + this.GetPosition().Y > 1) { this.Position.Y -= this.Hitbox.UpBorder + this.GetPosition().Y - 1; speed.Y = 0; } }));
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.BottomBorder + this.GetPosition().Y < -1) { this.Position.Y -= this.Hitbox.BottomBorder + this.GetPosition().Y + 1; speed.Y = 0; } }));

            this.Activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }


    }






}
