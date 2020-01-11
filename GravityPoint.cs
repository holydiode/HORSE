using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class GravityPoint:Gravitaiton
    {
        public GravityPoint()
        {
            this.power = 0.1;
        }

        public GravityPoint(Coord2d point, double power)
        {
            this.power = power;
        }

        public override void drug(Physics currentObject)
        {
            currentObject.Speed += (power* currentObject.Mass) * (this.GetPosition() - currentObject.GetPosition());
        }

    }
}
