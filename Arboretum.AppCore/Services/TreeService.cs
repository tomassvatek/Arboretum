using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;

namespace Arboretum.AppCore.Services
{
    public class TreeService : ITreeService
    {
        public IList<Tree> GetTrees( IRegion mapViewport )
        {
            throw new System.NotImplementedException();
        }

        public IList<Tree> GetTrees( IRegion viewport, double latitude, double longitude, int count)
        {
            throw new System.NotImplementedException();
        }

        public Tree GetTreeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Dendrology> GetDendrologies()
        {
            throw new System.NotImplementedException();
        }

        public Dendrology GetDendrologyById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateTree(Tree tree)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTree(int id, Tree tree)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTree(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}