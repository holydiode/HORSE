using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{

    class TestObject: Active{
        public TestObject() : base()
        {

            this.SetTopDownBehaivor(0.01f);
            this.SetSolidBoderBehaivor();

        }

        private void move()
        {
            this.Position.X += 0.01f;
        }

    }



    class Program
    {



        static void Main(string[] args)
        {
            Core game = new Core();
            TestObject pix = new TestObject();
            

            Core.MainScene.Add(pix);
            game.Run();
        }
    }
}
