using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.WebServices.Providers
{
    public interface IDataProvider
    {
        string ProviderName { get; }
        Uri BaseAddress { get; }    
        List<RequestHeader> RequestHeaders { get; }    
    }
}
