using Arboretum.Common.Enums;

namespace Arboretum.AppCore.Models.Interfaces
{
    public interface IProvider
    {
        ProviderName ProviderName { get; set; }     
        bool IsEditable { get; set; }
    }
}