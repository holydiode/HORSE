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
            if(gameObject != null)
            {
                foreach(Coord2d currentPoint in this.gameObject.Hitbox.Points)
                {
                    if (Core.CurrentObject.PointInObject(currentPoint + this.gameObject.GetPosition()))
                    {
                        return true;
                    }
                }

                foreach (Coord2d currentPoint in Core.CurrentObject.Hitbox.Points)
                {
                    if (this.gameObject.PointInObject(currentPoint + Core.CurrentObject.GetPosition() ))
                    {
                        return true;
                    }
                }

            }
            return false;
        }


    }
}
