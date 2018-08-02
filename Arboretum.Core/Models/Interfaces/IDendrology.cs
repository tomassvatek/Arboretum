using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Models.Interfaces
{
    public interface IDendrology
    {
        string CommonName { get; set; }
        string ScientificName { get; set; }
        string About { get; set; }
    }
}
