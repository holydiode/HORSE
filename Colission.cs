using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Colission: ColissionActivity
    {

        public Colission(GameObject gameObject, script Script):base(gameObject, Script)
        {

        }


        protected override bool Check()
        {
            if(GameObject != null)
            {
                foreach(Coord2d currentPoint in this.GameObject.Hitbox.Points)
                {
                    if (Core.CurrentObject.PointInObject(currentPoint + this.GameObject.GetPosition()))
                    {
                        return true;
                    }
                }

                foreach (Coord2d currentPoint in Core.CurrentObject.Hitbox.Points)
                {
                    if (this.GameObject.PointInObject(currentPoint + Core.CurrentObject.GetPosition() ))
                    {
                        return true;
                    }
                }

            }
            return false;
        }


    }
}
