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

        /// <summary>
        /// Gets the dendrologies.
        /// </summary>
        /// <returns></returns>
        public IList<IDendrology> GetDendrologies()
        {
            var query = DbContext.Dendrologies;
            var domainDendrologies = MapDbDendrologiesToDomain(query).ToList();
            return domainDendrologies;
        }

        /// <summary>
        /// Gets the dendrologies.
        /// </summary>
        /// <param name="reduction">The reduction.</param>
        /// <returns></returns>
        public IList<IDendrology> GetDendrologies(IReduction reduction)
        {
            var query = DbContext.Dendrologies;
            if (reduction.PageNumber != null && reduction.PageSize != null)
            {
                var skipCount = (reduction.PageNumber.Value - 1) * reduction.PageSize.Value;
                var reductionDendrologies = query.Skip(skipCount)
                    .Take(reduction.PageSize.Value);

                var reductionDomainDendrologies = MapDbDendrologiesToDomain(reductionDendrologies)
                    .ToList();

                return reductionDomainDendrologies;
            }

            return GetDendrologies();
        }

        /// <summary>
        /// Gets the dendrology by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IDendrology GetDendrologyById(int id)
        {
            var domainDendrologies = GetDendrologies().First(d => d.Id == id);
            return domainDendrologies;
        }

        /// <summary>
        /// Maps the database dendrologies to domain.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
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