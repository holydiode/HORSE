using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Core
    {
        private static Scene mainScene;
        private static GameObject currentObject;
        internal static GameObject CurrentObject { get => currentObject; set => currentObject = value; }
        internal static Scene MainScene { get => mainScene; set => mainScene = value; }

        public Core()
        {
            currentObject = null;
            mainScene = new Scene();
        }



        public void Run()
        {

        }
    }



}
