using Arboretum.Common.Enums;

namespace Arboretum.Web.ViewModels
{
    public class TreeMapViewModel
    {
        public TreeMapViewModel( ) { }

        public TreeMapViewModel( int id, string commonName )
        {
            this.Id = id;
            this.CommonName = commonName;
        }

        public int Id { get; set; }
        public ProviderName ProviderName { get; set; }      
        public string CommonName { get; set; }
    }
}
