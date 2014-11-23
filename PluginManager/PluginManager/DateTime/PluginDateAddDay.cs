using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
   public class PluginDateAddDay : IPlugin<DateTime>
    {
        public DateTime Modify(DateTime value)
        {
            return value.AddDays(1);
        }
    }
}
