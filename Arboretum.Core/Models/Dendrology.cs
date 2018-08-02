using Arboretum.Core.Models.Interfaces;
using System.Collections.Generic;

namespace Arboretum.Core.Models
{
    public partial class Dendrology : IDendrology
    {
        public Dendrology( )
        {
            Tree = new HashSet<Tree>( );
        }

        public int Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string About { get; set; }
        public ICollection<Tree> Tree { get; set; }
    }
}
