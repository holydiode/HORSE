using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace HORSE
{
    class Activity
    {
        protected int count;
        protected bool status;
        protected List<Activity> children;
        public delegate void script();
        public script Script;

        public Activity()
        {
            count = 0;
            status = true;
            children = null;
        }

        protected virtual bool Check()
        {
            return true;
        }

        public void Run()
        {
            if (this.Check())
            {
                Script();
                count++;
            }
        }

        public void Refresh()
        {
            count = 0;
        }
    }
}
