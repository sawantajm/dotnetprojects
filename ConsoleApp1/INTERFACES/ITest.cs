using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACES
{
    public interface ITest
    {
        void Add(int a, int b);
    }

    public interface Itest1: ITest
    {
        void sub(int a, int b);
    }
}
