using System;
using System.Collections.Generic;
using System.Linq;
using Arboretum.AppCore.Models;
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

        public ServiceResult<List<Dendrology>> GetDendrologies()
        {
            var result = new ServiceResult<List<Dendrology>>();

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
        
        public ServiceResult<Dendrology> GetDendrologyById(int id)
        {
            var result = new ServiceResult<Dendrology>();

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