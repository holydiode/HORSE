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
        protected GameObject parent;
        protected List<GameObject> children;

        internal Coord3d Position { get => position; set => position = value; }
        internal Texture Texture { get => texture; set => texture = value; }
        internal Geometry Hitbox { get => hitbox; set => hitbox = value; }
        internal GameObject Parent { get => parent; set => parent = value; }

        public GameObject()
        {
            texture = new TextureFigure();
            hitbox = new Geometry();
            status = true;
            animation = null;
            position = new Coord3d(0,0,0);
            parent = null;
            children = new List<GameObject>();
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


        public void SetChild(GameObject child)
        {
            children.Add(child);
            child.parent = this;
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

            foreach(GameObject currentObject in this.children)
            {
                Core.CurrentObject = currentObject;
                currentObject.Drow();
            }

        }

        public void Rotate(double rad)
        {
            foreach(Coord2d currentPoint in this.Hitbox.Points)
            {


                double X = currentPoint.X;
                double y = currentPoint.Y;

                currentPoint.X = X * Math.Cos(rad) - y * Math.Sin(rad);
                currentPoint.Y = X * Math.Sin(rad) + y * Math.Cos(rad);

            }

            this.hitbox.RecountBorder();

            if( this.Texture.GetType() != typeof(TextureFigure) &&  ((TextureFigure)this.Texture).Border.Points != this.Hitbox.Points) { 
                this.Texture.Rotate(rad);
            }


        }

    }
}
