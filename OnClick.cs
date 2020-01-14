using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace HORSE
{
    class OnClick:MouseActivity
    {
        private bool buttonIsDown;

        public OnClick(string button, script Script) : base(button, Script)
        {
            buttonIsDown = false;
        }

        protected override bool Check()
        {
            mouse = Mouse.GetState();

            Coord2d MousePosition = new Coord2d(Mouse.GetCursorState().X, Mouse.GetCursorState().Y);
            MousePosition.ScreenToScene();

            if (mouse[button])
            {
                if (Core.CurrentObject.PointInObject(MousePosition)) { 
                    buttonIsDown = true;
                }
                return false;
            }

            else if (buttonIsDown)
            {
                if (Core.CurrentObject.PointInObject(MousePosition))
                {
                    return true;
                }
                buttonIsDown = false;
            }
            return false;
        }

    }
}
