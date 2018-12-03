using System.ComponentModel.DataAnnotations;
using Arboretum.AppCore.Models.Interfaces;

namespace Arboretum.AppCore.Models
{
    public class Reduction : IReduction
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page number must be bigger than 1.")]
        public int? PageNumber { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Page size must be bigger than 1.")]
        public int? PageSize { get; set; }

        public bool HasValues()
        {
            if (PageNumber == null || PageSize == null)
            {
                return false;
            }

            return true;
        }
    }
}