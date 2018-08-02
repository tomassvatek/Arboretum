using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Models.Interfaces
{
    public interface ITree
    {
        int Id { get; set; }
        int? Age { get; set; }
        double? Height { get; set; }
        double? CrownSize { get; set; }
        double? TrunkSize { get; set; }
        string Note { get; set; }
    }
}
