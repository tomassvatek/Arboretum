using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.API.Helpers.Converters.Interfaces
{
    public interface IConverter<TSource, TDestination>
    {
        TDestination Convert( TSource source );
    }
}
