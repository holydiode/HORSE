using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class GameObject
    {
        private Texture texture;
        private Geometry hitbox;
        private bool status;
        private Animation animation;
        private Coord3d position;
        private GameObject parent;
        private List<GameObject> children;

        internal Coord3d Position { get => position; set => position = value; }
        internal Texture Texture { get => texture; set => texture = value; }
        internal Geometry Hitbox { get => hitbox; set => hitbox = value; }

        public GameObject()
        {
            texture = new TextureFigure();
            hitbox = new Geometry();
            status = true;
            animation = null;
            position = new Coord3d(0,0,0);
            parent = null;
            children = null;
        }

        public Coord2d GetPosition()
        {
            if (parent == null)
            {
                return position.LowerDegree();
            }
            else
            {
                return position.LowerDegree() + parent.GetPosition();
            }
        }

        public bool PointInObject(Coord2d point)
        {
            bool c = false;
            for (int i = 0, j = hitbox.Complexity - 1; i < hitbox.Complexity; j = i++)
            {
                if ((( (Hitbox.Points[i].Y + this.GetPosition().Y <= point.Y)
                    && (point.Y < Hitbox.Points[j].Y + this.GetPosition().Y))
                    || ((Hitbox.Points[j].Y + this.GetPosition().Y <= point.Y)
                    && (point.Y < Hitbox.Points[i].Y + this.GetPosition().Y)))
                    && (((Hitbox.Points[j].Y + this.GetPosition().Y - (Hitbox.Points[i].Y + this.GetPosition().Y)) != 0)
                    && (point.X > ((Hitbox.Points[j].X + this.GetPosition().X - (Hitbox.Points[i].X + this.GetPosition().X)) * (point.Y - (Hitbox.Points[i].Y + this.GetPosition().Y)) / (Hitbox.Points[j].Y + this.GetPosition().Y - (Hitbox.Points[i].Y + this.GetPosition().Y)) + Hitbox.Points[i].X + this.GetPosition().X))))
                    c = !c;
            }
            return c;
        }


        public void Drow() {
            texture.Drow();
        }

    }
}
