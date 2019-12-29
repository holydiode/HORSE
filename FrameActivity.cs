using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class FrameActivity : Activity
    {
        public FrameActivity(script Script)
        {
            this.Script = Script;
        }

        protected override bool Check()
        {
            return true;
        }
    };
}
