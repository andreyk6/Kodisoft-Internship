using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    class PluginsCollection<T> : IPlugin<T>
    {
        private List<IPlugin<T>> PluginList = new List<IPlugin<T>>();

        public PluginsCollection()
        {
            var plugins = Assembly.GetExecutingAssembly().GetExportedTypes().Where(
                t => (t.IsClass && t.GetInterfaces().Contains(typeof(IPlugin<T>))) ? true : false
                    );

            //if (plugins.Count() == 0) throw new NotSupportedException("No plugins found");

            foreach(var plugin in plugins)
            {
                PluginList.Add((IPlugin<T>)Activator.CreateInstance(plugin));
            }

        }

        public T Modify(T value)
        {
            foreach (var plugin in PluginList)
            {
                value = plugin.Modify(value);
            }

            return value;
        }
    }
}
