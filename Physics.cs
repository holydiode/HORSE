using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Physics : Active
    {
        private double mass;
        private Coord2d speed;
        protected float inertia;
        protected Coord2d massCenter;
        protected int layerColision;

        internal Coord2d Speed { get => speed; set => speed = value; }
        public double Mass { get => mass; set => mass = value; }

        public Physics():base(){
            speed = new Coord2d();
            layerColision = 0;
            inertia = 1;
        }

        public void Move() {
            if (Core.CurrentObject.Status == true) { 
            this.Position = this.Position + speed;
            this.Hit();  //ДОРАБОТАТЬ !!!!
            this.Drug();
            this.Push();
            }
        }


        public void Hit() {
            foreach (Physics currentObject in Core.MainScene.PhysicsObjects) {
                if (this.layerColision == currentObject.layerColision && currentObject != this)
                {
                    foreach (Coord2d currentPoint in currentObject.Hitbox.Points)
                    {
                        if (this.PointInObject(currentPoint + currentObject.GetPosition()))
                        {

                            List<Coord2d> near = this.Hitbox.FindNearStraight(currentPoint + currentObject.GetPosition(), this.GetPosition());

                            Coord2d normal = new Coord2d((near[1].Y - near[0].Y), (near[0].X - near[1].X));
                            normal = normal / normal.len();
                            
                            Coord2d mirror = currentObject.speed - normal * 2  * (normal * currentObject.speed);

                            if (this.mass != 0)
                            {

                            }

                            if (currentObject.mass != 0)
                            {
                                currentObject.Speed = mirror;
                            }

                            break;
                        }
                    }
                }
            }
        }



        public void Push()
        {
            foreach (Physics currentObject in Core.MainScene.PhysicsObjects)
            {
                if (this.layerColision == currentObject.layerColision && currentObject != this)
                {
                    foreach (Coord2d currentPoint in currentObject.Hitbox.Points)
                    {
                        if (this.PointInObject(currentPoint + currentObject.GetPosition()))
                        {
                            double len;

                            List<Coord2d> near = this.Hitbox.FindNearStraight(currentPoint + currentObject.GetPosition(), this.GetPosition(), out len);

                            Coord2d normal = new Coord2d((near[1].Y - near[0].Y), (near[0].X - near[1].X));
                            normal = normal / normal.len();

                            GameObject pushed = this;

                            if (this.mass == 0 || this.mass < currentObject.mass)
                            {
                                pushed = currentObject;
                                normal = normal * -1;
                            }

                            pushed.Position = pushed.Position + (normal * len);


                            foreach (Activity currentivent in this.Activities)
                            {
                                if(currentivent is ColissionActivity && ((ColissionActivity)currentivent).GameObject == currentObject)
                                {
                                    currentivent.Script();
                                }
                            }


                            foreach (Activity currentivent in currentObject.Activities)
                            {
                                if (currentivent is ColissionActivity && ((ColissionActivity)currentivent).GameObject == this)
                                {
                                    currentivent.Script();
                                }
                            }


                        }
                    }
                }
            }
        }

        public void Drug()
        {
            foreach(Gravitaiton currentObject in Core.MainScene.GravityObjects)
            {
                currentObject.drug(this);
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

            this.Activities.Add(new KeyUp("w", () => this.Speed.X = 0));
            this.Activities.Add(new KeyUp("a", () => this.Speed.Y = 0));
            this.Activities.Add(new KeyUp("s", () => this.Speed.X = 0));
            this.Activities.Add(new KeyUp("d", () => this.Speed.Y = 0));
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


        public void SetArcanoidBehaivor(float speed, string keyOne, string keyTwo)
        {
            this.Activities.Add(new KeyUp(keyOne, () => this.Speed.X = 0));
            this.Activities.Add(new KeyUp(keyTwo, () => this.Speed.X = 0));
            this.Activities.Add(new KeyHold(keyOne, () => this.Speed.X = -speed));
            this.Activities.Add(new KeyHold(keyTwo, () => this.Speed.X = speed));

            this.Activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }


        public new void SetSolidBoderRule()
        {
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.RightBorder + this.GetPosition().X > 1) { this.Position.X -= this.GetPosition().X + this.Hitbox.RightBorder - 1 ;  } }));
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.LeftBorder + this.GetPosition().X < -1) { this.Position.X -= this.Hitbox.LeftBorder + this.GetPosition().X + 1 ;  } }));
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.UpBorder + this.GetPosition().Y > 1) { this.Position.Y -= this.Hitbox.UpBorder + this.GetPosition().Y - 1 ;  } }));
            this.Activities.Add(new FrameActivity(() => { if (this.Hitbox.BottomBorder + this.GetPosition().Y < -1) { this.Position.Y -= this.Hitbox.BottomBorder + this.GetPosition().Y + 1 ;  } }));

            this.Activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }


    }






}
