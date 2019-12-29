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

        protected Coord2d Speed { get => speed; set => speed = value; }


        public Physics():base(){
            speed = new Coord2d();
        }

        public void Move() {
            this.Position = this.Position + speed;
        }


        public void SetBallBorderRule()
        {
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.RightBorder + this.GetPosition().X > 1) { this.speed.X = -1 * this.speed.X; } }));
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.LeftBorder + this.GetPosition().X < -1) { this.speed.X = -1 * this.speed.X; } }));
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.UpBorder + this.GetPosition().Y > 1)     {this.speed.Y = -1 * this.speed.Y; } }));
            Activities.Add(new FrameActivity(() => { if (this.Hitbox.BottomBorder + this.GetPosition().Y < -1) { this.speed.Y = -1 * this.speed.Y; } }));
        }


    }




}
