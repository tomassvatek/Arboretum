using System;
using System.Collections.Generic;
using System.Linq;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.Common.ServiceResults;

namespace Arboretum.AppCore.Services
{
    public class DendrologyService : IDendrologyService
    {
        private readonly IDendrologyRepository _dendrologyRepository;

        public DendrologyService(IDendrologyRepository dendrologyRepository)
        {
            _dendrologyRepository = dendrologyRepository;
        }

        /// <summary>
        /// Gets the dendrologies.
        /// </summary>
        /// <returns></returns>
        public ServiceResult<List<IDendrology>> GetDendrologies()
        {
            var result = new ServiceResult<List<IDendrology>>();

            try
            {
                var dendrologies = _dendrologyRepository.GetDendrologies().ToList();
                result.Data = dendrologies;
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }

        /// <summary>
        /// Gets the dendrologies.
        /// </summary>
        /// <param name="reduction">The reduction.</param>
        /// <returns></returns>
        public ServiceResult<IList<IDendrology>> GetDendrologies(IReduction reduction)
        {
            var result = new ServiceResult<IList<IDendrology>>();

            try
            {
                var dendrologies = _dendrologyRepository.GetDendrologies(reduction);
                result.Data = dendrologies;
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }

        /// <summary>
        /// Gets the dendrology by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ServiceResult<IDendrology> GetDendrologyById(int id)
        {
            var result = new ServiceResult<IDendrology>();

            try
            {
                var dendrology = _dendrologyRepository.GetDendrologyById(id);
                result.Data = dendrology;
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }
    }
}