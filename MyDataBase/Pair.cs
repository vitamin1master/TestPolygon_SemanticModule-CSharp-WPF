using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase
{
    public class Pair<T,P>
    {
        public T First;
        public P Second;

        public Pair(T first, P second)
        {
            First = first;
            Second = second;
        }
    }
}
