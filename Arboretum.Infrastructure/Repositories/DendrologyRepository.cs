using System.Collections.Generic;
using System.Linq;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.Persistence;
using Microsoft.EntityFrameworkCore.Internal;

namespace Arboretum.Infrastructure.Repositories
{
    public class DendrologyRepository : IDendrologyRepository
    {
        protected readonly ArboretumDbContext DbContext;

        public DendrologyRepository(ArboretumDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IList<IDendrology> GetDendrologies()
        {
            var query = DbContext.Dendrologies;
            var domainDendrologies = MapDbDendrologiesToDomain(query).ToList();
            return domainDendrologies;
        }

        public IList<IDendrology> GetDendrologies(IReduction reduction)
        {
            var query = DbContext.Dendrologies;
            if (reduction.PageNumber != null && reduction.PageSize != null)
            {
                var reductionDendrologies = query.Skip((reduction.PageNumber.Value - 1) * reduction.PageSize.Value)
                    .Take(reduction.PageSize.Value);

                var reductionDomainDendrologies = MapDbDendrologiesToDomain(reductionDendrologies).ToList();

                return reductionDomainDendrologies;
            }

            return GetDendrologies();
        }

        public IDendrology GetDendrologyById(int id)
        {
            var domainDendrologies = GetDendrologies().First(d => d.Id == id);
            return domainDendrologies;
        }

        private IQueryable<IDendrology> MapDbDendrologiesToDomain(IQueryable<Persistence.Entities.Dendrology> query)
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