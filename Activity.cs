using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HORSE
{
    abstract class Activity
    {
        //количество выполнения инструкции
        protected int count;
        //сузествование инструкции в данный момент времени
        protected bool status;
        //дочернии инструкции выполняються только при условии что данная инструкция истинна
        protected List<Activity> children;

        //Непосредственна сама инструкция
        public delegate void script();
        public script Script;

        //приоритет
        protected int propity;


        public Activity()
        {
            count = 0;
            status = true;
            children = null;
            propity = 0;
        }

        public Activity(script Script)
        {
            count = 0;
            status = true;
            children = null;
            propity = 0;
            this.Script = Script;
        }

        public Activity(script Script, int priority)
        {
            count = 0;
            status = true;
            children = null;
            this.propity = priority;
            this.Script = Script;
        }

        //условие выполнения инструкции
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

                if (this.children != null)
                {
                    foreach (Activity current in this.children)
                    {
                        current.Run();
                    }
                }

            }
        }

        public void Refresh()
        {
            count = 0;
        }

        public static bool operator >(Activity a, Activity b)
        {
            return (a.propity > b.propity);
        }

        public static bool operator <(Activity a, Activity b)
        {
            return (a.propity < b.propity);
        }

    }
}
