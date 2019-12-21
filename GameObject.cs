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


        public void Drow() {
            texture.Drow();
        }

    }
}
