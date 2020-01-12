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

        internal List<Activity> Activities { get => activities; set => activities = value; }

        public Active() : base()
        {
            activities = new List<Activity>();
        }


        public void SetBehavior(Activity activity)
        {
            activities.Add(activity);

            activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; }); ;
        }

        public void SetTopDownBehaivor(float speed)
        {
            activities.Add(new KeyHold("w", () => this.Position.Y += speed));
            activities.Add(new KeyHold("s", () => this.Position.Y -= speed));
            activities.Add(new KeyHold("a", () => this.Position.X -= speed));
            activities.Add(new KeyHold("d", () => this.Position.X += speed));

            activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }

        public void SetArcanoidBehaivor(float speed)
        {
            activities.Add(new KeyHold("a", () => this.Position.X -= speed));
            activities.Add(new KeyHold("d", () => this.Position.X += speed));

            activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }

        public void SetTeleportBorderRule()
        {
            activities.Add(new FrameActivity(() => { if (this.GetPosition().Y < -1) this.Position.Y = 1f; }));
            activities.Add(new FrameActivity(() => { if (this.GetPosition().X < -1) this.Position.X = 1f; }));
            activities.Add(new FrameActivity(() => { if (this.GetPosition().Y > 1) this.Position.Y = -1f; }));
            activities.Add(new FrameActivity(() => { if (this.GetPosition().X > 1) this.Position.X = -1f; }));

            activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }

        public void SetSolidBoderRule()
        {
            activities.Add(new FrameActivity(() => { if (this.Hitbox.RightBorder + this.GetPosition().X > 1) { this.Position.X -=  this.GetPosition().X + this.Hitbox.RightBorder - 1; } }));
            activities.Add(new FrameActivity(() => { if (this.Hitbox.LeftBorder + this.GetPosition().X < -1) { this.Position.X -= this.Hitbox.LeftBorder + this.GetPosition().X + 1; } }));
            activities.Add(new FrameActivity(() => { if (this.Hitbox.UpBorder + this.GetPosition().Y > 1) { this.Position.Y -= this.Hitbox.UpBorder + this.GetPosition().Y - 1; } }));
            activities.Add(new FrameActivity(() => { if (this.Hitbox.BottomBorder + this.GetPosition().Y < -1) { this.Position.Y -= this.Hitbox.BottomBorder + this.GetPosition().Y + 1; } }));

            activities.Sort((Activity a, Activity b) => { if (a < b) return -1; else return 1; });
        }

        public void Refresh()
        {
            foreach(Activity activity in Activities)
            {
                activity.Refresh();
            }
        }




        public void Run()
        {
            if (Core.CurrentObject.Status == true)
            {
                foreach (Activity current in activities)
                {
                    current.Run();
                }

                foreach (GameObject currentObject in children)
                {
                    Core.CurrentObject = currentObject;

                    if (currentObject is Active)
                    {
                        ((Active)currentObject).Run();
                    }
                }

            }

            else
            {
                this.Refresh();


                foreach (GameObject currentObject in children)
                {
                    Core.CurrentObject = currentObject;

                    if (currentObject is Active)
                    {
                        ((Active)currentObject).Refresh();
                    }
                }

            }
        }

    }
}
