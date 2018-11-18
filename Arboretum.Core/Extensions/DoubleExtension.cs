using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Extensions
{
    public static class DoubleExtension
    {
        public static double ToRadians( this double angle )
        {
            return Math.PI * angle / 180;
        }
    }
}
