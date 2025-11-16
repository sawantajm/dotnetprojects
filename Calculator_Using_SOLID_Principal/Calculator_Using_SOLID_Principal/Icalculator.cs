using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Using_SOLID_Principal
{
    public interface Icalculator
    {
        public string operators { get; }

        public double Calculate(double a, double b);

    }
}
