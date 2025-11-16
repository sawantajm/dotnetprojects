using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Using_SOLID_Principal
{
    public class Subtraction :Icalculator
    {
        public string operators => "-";

        public double Calculate(double a, double b)
        {
            return a - b;
        }
    }
}
