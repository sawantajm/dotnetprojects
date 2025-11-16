using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Using_SOLID_Principal
{
    public class Calculators
    {
        private readonly List<Icalculator> _calculators;

        public Calculators(List<Icalculator> calculator)
        {
            _calculators = calculator;
        }

        public double Execute(double a, double b, string op )
        {
            var opration = _calculators.FirstOrDefault(o => o.operators == op);
            if (opration == null)
            {
                Console.WriteLine("Oprator is not matched");
            }


                return opration.Calculate(a,b);
        }
    }
}
