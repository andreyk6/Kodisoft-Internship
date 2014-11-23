using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    abstract class IPluginClient<T>
    {
        private IPlugin<T> Plugin;

        public T Data { get; set; }

        public IPluginClient(IPlugin<T> plugin, T data)
        {
            Plugin = plugin;
            Data = data;
        }

        virtual public void WriteResult()
        {
            //Modify data by plugin and display Result 
            Console.WriteLine(Modify(Data));
        }

        virtual protected T Modify(T value)
        {
            return Plugin.Modify(value); ;
        }
    }
}
