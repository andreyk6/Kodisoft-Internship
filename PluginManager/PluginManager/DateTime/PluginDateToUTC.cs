using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    public class PluginDateToUTC : IPlugin<DateTime>
    {
         public DateTime Modify(DateTime value)
        {
            //Convert DateTime from Local to UTC
            return TimeZone.CurrentTimeZone.ToUniversalTime(value);
        }
    }
}
