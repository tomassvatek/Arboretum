using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Models.Interfaces
{
    public interface IGeolocation
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }   
}
