using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Entities.Interfaces    
{
    public interface ITree : IGeolocation, INote
    {
        int Id { get; set; }
        int? Age { get; set; }
        double? Height { get; set; }
        double? CrownSize { get; set; }
        double? TrunkSize { get; set; }
    }
}
