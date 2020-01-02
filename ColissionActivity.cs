using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class ColissionActivity: Activity
    {
        protected GameObject gameObject;
        protected Type type;

        public ColissionActivity(GameObject gameObject, script Script)
        {
            this.gameObject = gameObject;
            this.Script = Script;

            type = null;

            this.propity = 50;

        }

    }
}
