using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates1
{
    public delegate void WorkPerformHandler(int hour, string Worktype);
    public delegate void WorkCompaleteHandler(string Worktype);
    public class Delegates12
    {
        public void Work(int hours, string Worktype,WorkPerformHandler workPerformHandler,WorkCompaleteHandler workCompaleteHandler)
        {
            for (int i = 0; i < hours; i++)
            {
                //Do Some Processing
                Thread.Sleep(1000);
                //Notfiy how much works have been done
                workPerformHandler(i + 1, Worktype);
            }
            workCompaleteHandler(Worktype);
        }
    }
}
