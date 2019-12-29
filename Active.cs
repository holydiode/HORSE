using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Active:GameObject
    {

        private List<Activity> activities;

        public Active() : base()
        {
            activities = new List<Activity>();
        }


        public void SetBehavior(Activity activity)
        {
            activities.Clear();
            activities.Add(activity);
        }

        public void SetTopDownBehaivor(float speed)
        {
            activities.Add(new KeyHold("w", () =>  this.Position.Y += speed));
            activities.Add(new KeyHold("s", () =>  this.Position.Y -= speed));
            activities.Add(new KeyHold("a", () =>  this.Position.X -= speed));
            activities.Add(new KeyHold("d", () =>  this.Position.X += speed));
        }

        public void SetTeleportBorderBehaivor()
        {
            activities.Add(new FrameActivity(() => { if (this.Position.Y < -1) this.Position.Y = 1f; }));
            activities.Add(new FrameActivity(() => { if (this.Position.X < -1) this.Position.X = 1f; }));
            activities.Add(new FrameActivity(() => { if (this.Position.Y > 1) this.Position.Y = -1f; }));
            activities.Add(new FrameActivity(() => { if (this.Position.X > 1) this.Position.X = -1f; }));
        }

        public void SetSolidBoderBehaivor()
        {
            activities.Add(new FrameActivity(() => { if (this.Position.Y < -1) this.Position.Y = -1f; }));
            activities.Add(new FrameActivity(() => { if (this.Position.X < -1) this.Position.X = -1f; }));
            activities.Add(new FrameActivity(() => { if (this.Position.Y > 1) this.Position.Y = 1f; }));
            activities.Add(new FrameActivity(() => { if (this.Position.X > 1) this.Position.X = 1f; }));
        }


        public void Run()
        {
            foreach (Activity current in activities)
            {
                current.Run();
            }
        }


    }
}
