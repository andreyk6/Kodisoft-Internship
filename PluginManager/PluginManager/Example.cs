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
            var plugin = new PluginsCollectionDateTime();

            Console.WriteLine("Current date: {0}", date);
            Console.WriteLine("Result of the plugin: {0}", plugin.Modify(date));
        }

        static void IntDemo( int number)
        {
            var plugin = new PluginsCollectionInt();

            Console.WriteLine("My number: {0}", number);
            Console.WriteLine("Result of the plugin: {0}", plugin.Modify(number));
        }

        public static void Main()
        {
            DateDemo(DateTime.Now);
            IntDemo(-5);

            Console.ReadLine();
        }
    }
}
