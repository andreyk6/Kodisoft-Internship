using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    class PluginsCollectionDateTime : IPlugin<DateTime>
    {
        private List<IPlugin<DateTime>> PluginList = new List<IPlugin<DateTime>> {
            new PluginDateAddDay(),
            new PluginDateToUTC()
        };

        public DateTime Modify(DateTime value)
        {
            foreach (var plugin in PluginList)
            {
                value = plugin.Modify(value);
            }

            return value; 
        }
    }
}
