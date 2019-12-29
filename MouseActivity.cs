using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace HORSE
{
    class MouseActivity:Activity
    {
        protected MouseButton button;
        protected MouseState mouse;

        public MouseActivity(string button, script Script)
        {
            if(button.ToLower() == "l" || button.ToLower() == "left")
            {
                this.button = MouseButton.Left;
            }else if (button.ToLower() == "r" || button.ToLower() == "right")
            {
                this.button = MouseButton.Right;
            }

            this.Script = Script;
            mouse = OpenTK.Input.Mouse.GetState();
        }

    }
}
