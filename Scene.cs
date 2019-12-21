using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Scene
    {
        private List<GameObject> staticObjects;
    
        public Scene()
        {
            staticObjects = new List<GameObject>();

        }

        internal List<GameObject> StaticObjects { get => staticObjects; set => staticObjects = value; }

        public void Add(GameObject app) {
            staticObjects.Add(app);
        }
    }

}
