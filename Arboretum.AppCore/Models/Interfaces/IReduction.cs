namespace Arboretum.AppCore.Models.Interfaces
{
    public interface IReduction
    {
        int? PageNumber { get; set; }
        int? PageSize { get; set; }
        bool HasValues();   
    }
}