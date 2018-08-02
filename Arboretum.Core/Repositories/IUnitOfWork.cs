using System;

namespace Arboretum.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITreeRepository Trees { get; set; }
        IDendrologyRepository Dendrologies { get; set; }
        int SaveChanges( );
    }
}
