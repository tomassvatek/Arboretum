using System.Collections.Generic;
using System.Linq;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Repositories;
using Arboretum.Persistence;

namespace Arboretum.Infrastructure.Repositories
{
    public class DendrologyRepository : IDendrologyRepository
    {
        protected readonly ArboretumDbContext DbContext;

        public DendrologyRepository(ArboretumDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IList<Dendrology> GetDendrologies()
        {
            var query = DbContext.Dendrologies;
            var domainDendrologies = MapDbDendrologiesToDomain(query).ToList();
            return domainDendrologies;
        }

        public Dendrology GetDendrologyById(int id)
        {
            var domainDendrologies = GetDendrologies().First(d => d.Id == id);
            return domainDendrologies;
        }

        private IQueryable<Dendrology> MapDbDendrologiesToDomain(IQueryable<Persistence.Entities.Dendrology> query)
        {
            return query.Select(d => new Dendrology
            {
                Id = d.Id,
                CommonName = d.CommonName,
                ScientificName = d.ScientificName,
                About = d.About
            });
        }
    }
}