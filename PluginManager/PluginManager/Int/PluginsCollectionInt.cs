using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    class PluginsCollectionInt : IPlugin<int>
    {
        private List<IPlugin<int>> PluginList = new List<IPlugin<int>>
        {
            new PluginIntAbs(),
            new PluginIntPow3()
        };

        public int Modify(int value)
        {
            foreach (var plugin in PluginList)
            {
                value = plugin.Modify(value);
            }

            return value;
        }
    }
}
