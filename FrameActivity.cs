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
            this.propity = 20;
        }

        public FrameActivity(script Script, int propity)
        {
            this.Script = Script;
            this.propity = propity;
        }


        protected override bool Check()
        {
            return true;
        }
    };
}
