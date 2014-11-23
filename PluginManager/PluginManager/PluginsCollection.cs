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
        private List<IPlugin<T>> PluginsList = new List<IPlugin<T>>();

        public PluginsCollection(params IPlugin<T>[] pluginsList)
        {
            PluginsList = pluginsList.ToList();
        }

        public PluginsCollection()
        {
            //Get all IPlugin<T> classes 
            var plugins = Assembly.GetExecutingAssembly().GetExportedTypes().Where(
                t => (t.IsClass && t.GetInterfaces().Contains(typeof(IPlugin<T>))) ? true : false
                    );

            if (plugins.Count() == 0) throw new NotSupportedException("No plugins found");

            //Add all Plugins to collection
            foreach(var plugin in plugins)
            {
                PluginsList.Add((IPlugin<T>)Activator.CreateInstance(plugin));
            }
        }

        public T Modify(T value)
        {
            foreach (var plugin in PluginsList)
            {
                value = plugin.Modify(value);
            }

            return value;
        }
    }
}
