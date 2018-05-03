using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Models.Locations
{
    public interface IMapViewport
    {
        double NorthWest { get; set; }
        double NorthEast { get; set; }
        double SouthEast { get; set; }
        double SouthWest { get; set; }  
    }
}
