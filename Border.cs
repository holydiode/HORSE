using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Border
    {
        private bool left; 
        private bool right; 
        private bool bottom; 
        private bool down;

        public bool Left { get => left; set => left = value; }
        public bool Right { get => right; set => right = value; }
        public bool Bottom { get => bottom; set => bottom = value; }
        public bool Down { get => down; set => down = value; }

        public Border()
        {
            left = true;
            right = true;
            bottom = true;
            down = true;
        }
    };

    
}
