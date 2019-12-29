using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace HORSE
{
    class MouseClick: MouseActivity
    {

        private bool buttonIsDown; 

        public MouseClick(string button, script Script) : base(button, Script) {
            buttonIsDown = false;
        }

        protected override bool Check()
        {
            mouse = Mouse.GetState();

            if (mouse[button])
            {
                buttonIsDown = true;
                return false;
            }
            else if (buttonIsDown)
            {
                buttonIsDown = false;
                return true;
            }
            return false;
        }
    }
}
