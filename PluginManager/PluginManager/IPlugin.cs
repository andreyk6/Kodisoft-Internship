﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager
{
    public interface IPlugin<T>
    {
      T Modify(T value);
    }
}
