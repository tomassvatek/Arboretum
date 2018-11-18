
namespace Arboretum.API.Models
{
    public class AddTreeDto
    {
        public string Note { get; set; }

        public string CommonName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
