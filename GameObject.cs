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
        private List<GameObject> Children;
    }
}
