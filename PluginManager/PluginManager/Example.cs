using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    public static class Example
    {
        static void DateDemo(DateTime date)
        {
            var plugin = new PluginsCollection<DateTime>();

            Console.WriteLine("Current date: {0}", date);
            Console.WriteLine("Result of the plugin: {0}", plugin.Modify(date));
        }

        static void IntDemo( int number)
        {
            var plugin = new PluginsCollection<int>();

            Console.WriteLine("My number: {0}", number);
            Console.WriteLine("Result of the plugin: {0}", plugin.Modify(number));
        }

        public static void Main()
        {
            Console.WriteLine("Create Int Plugin:")
            IntDemo(-5);

            DateDemo(DateTime.Now);

            Console.ReadLine();
        }
    }
}
