using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    public class PluginIntAbs : IPlugin<Int32>
    {
        public int Modify(int value)
        {
            checked
            {
                return Math.Abs(value);
            }
        }
    }
}
