using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;


namespace HORSE
{
    class KeyBoardActity: Activity
    {
        protected Key button;
        protected KeyboardState keyboard;

        public KeyBoardActity(string button, script Script)
        {
            if (button.ToLower() == "w")
            {
                this.button = Key.W;
            }
            else if (button.ToLower() == "a")
            {
                this.button = Key.A;
            }
            else if (button.ToLower() == "s")
            {
                this.button = Key.S;
            }
            else if (button.ToLower() == "d")
            {
                this.button = Key.D;
            }


            this.Script = Script;
            keyboard = Keyboard.GetState();

        }


    }
}
