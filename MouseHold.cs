using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;


namespace HORSE
{
    class MouseHold:MouseActivity
    {
        public MouseHold(string button, script Script) : base(button, Script)
        {
        }

        protected override bool Check()
        {
            mouse = Mouse.GetState();

            return (mouse[button]);
        }
    }
}
