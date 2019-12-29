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
        protected Border border;

        public ColissionActivity(Border border, script Script)
        {
            this.border = border;
            this.Script = Script;

            type = null;
            gameObject = null;

        }

    }
}
