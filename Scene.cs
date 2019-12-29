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
        private List<Active> dinamicObjects;
        private List<Physics> physicsObjects;
        
    
        public Scene()
        {
            staticObjects = new List<GameObject>();
            dinamicObjects = new List<Active>();
            physicsObjects = new List<Physics>();

        }

        internal List<GameObject> StaticObjects { get => staticObjects; set => staticObjects = value; }
        internal List<Active> DinamicObjects { get => dinamicObjects; set => dinamicObjects = value; }
        internal List<Physics> PhysicsObjects { get => physicsObjects; set => physicsObjects = value; }


        public void Add(GameObject app) {
            staticObjects.Add(app);
        }
        public void Add(Active app) {
            staticObjects.Add(app);
            dinamicObjects.Add(app);
        }

        public void Add(Physics app)
        {
            staticObjects.Add(app);
            dinamicObjects.Add(app);
            physicsObjects.Add(app);
        }

    }

}
