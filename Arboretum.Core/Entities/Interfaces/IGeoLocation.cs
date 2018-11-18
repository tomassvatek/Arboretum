using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Entities.Interfaces
{
    public interface IGeolocation
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }   
}
