using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    class TestPlugin<T> : IPluginClient<T>
    {
        private Func<T,T> AdditionalFunc;
        public TestPlugin(Func<T,T> additionalFunc, IPlugin<T> plugin, T data) : base (plugin, data)
        {
            AdditionalFunc = additionalFunc;
        }

        public override void WriteResult()
        {
            Console.WriteLine(Modify(Data));
        }

        protected override T Modify(T value)
        {
            //Modify value by additional Function and then by base Plugin
            return base.Modify(AdditionalFunc(value));
        }
    }
}
