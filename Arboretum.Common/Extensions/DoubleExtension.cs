using System;

namespace Arboretum.Common.Extensions
{
    public static class DoubleExtension
    {
        public static double ToRadians(this double angle)
        {
            return Math.PI * angle / 180;
        }
    }
}