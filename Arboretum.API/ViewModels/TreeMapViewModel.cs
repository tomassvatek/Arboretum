namespace Arboretum.API.ViewModels
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
        public string CommonName { get; set; }
    }
}
