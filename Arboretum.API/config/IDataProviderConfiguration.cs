﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arboretum.Web.Config  
{
    interface IDataProviderConfiguration<T>
    {
        IList<T> Providers { get; set; }
        T GetProvider(string providerName);
    }
}
    