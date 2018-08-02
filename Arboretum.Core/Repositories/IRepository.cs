using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Arboretum.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get( int index );
        IEnumerable<TEntity> GetAll( );
        TEntity Find( Expression<Func<TEntity, bool>> predicate );
        void Add( TEntity entity );
        void AddRange( IEnumerable<TEntity> entities );
        void Remove( TEntity entity );
        void RemoveRange( TEntity entities );
    }
}
