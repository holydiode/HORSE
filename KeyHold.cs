using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;


namespace HORSE
{
    class KeyHold:KeyBoardActity
    {
        public KeyHold(string button, script Script) : base(button, Script)
        {
        }

        protected override bool Check()
        {
            keyboard = Keyboard.GetState();
            return (keyboard[button]);
        }


    }
}
