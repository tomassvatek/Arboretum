using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arboretum.API.ViewModels
{
    public class EditTreeViewModel
    {
        public int? Age { get; set; }
        public double? Height { get; set; }
        public double? CrownSize { get; set; }
        public double? TrunkSize { get; set; }
        public string Note { get; set; }
    }
}
