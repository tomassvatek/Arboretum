using System.Collections.Generic;

namespace Arboretum.Persistence.Entities
{
    public class Dendrology
    {
        public Dendrology( )
        {
            Tree = new HashSet<Tree>( );
        }

        public Dendrology( string commonName, string scientificName )
        {
            this.CommonName = commonName;
            this.ScientificName = scientificName;
            Tree = new HashSet<Tree>( );
        }

        public int Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string About { get; set; }
        public ICollection<Tree> Tree { get; set; }
    }
}