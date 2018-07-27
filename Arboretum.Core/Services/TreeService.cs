using System;
using System.Collections.Generic;
using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
using Arboretum.Core.Repositories;

namespace Arboretum.Core.Services
{
    public class TreeService : ITreeService
    {
        private IUnitOfWork _unitOfWork;

        public TreeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Tree GetTreeById(int id)
        {
            return _unitOfWork.Trees.Get(id);
        }

        public IEnumerable<Tree> GetTrees()
        {
            var trees = _unitOfWork.Trees.GetAll();

            return trees;
        }

        public Tree GetTrees(QuizOption option, IMapViewport viewport)
        {
            throw new NotImplementedException();
        }
    }
}
