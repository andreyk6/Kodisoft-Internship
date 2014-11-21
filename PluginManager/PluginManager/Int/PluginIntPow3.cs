using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    class PluginIntPow3 : IPlugin<int>
    {
        public int Modify(int value)
        {
            return IntPow(value, 2);
        }
        private static int IntPow(int num, int pow)
        {
            int result = 1;

            for (int i = 0; i < pow; i++) result *= num;

            return result;
        }
    }
}
