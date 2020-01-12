using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class ShowActivity: Activity
    {
        public ShowActivity(script Script) :base(Script)
        {

        }

        protected override bool Check()
        {
            if (this.count == 0) {
                return true;
            }
            return false;
        }

    }
}
