using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arboretum.API.ViewModels
{
    public class CreateTreeViewModel
    {
        public int DendrologyId { get; set; }   
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Note { get; set; }
    }
}
