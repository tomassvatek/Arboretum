using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
using Arboretum.Core.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arboretum.Core.Repositories
{
    public class TreeRepository : Repository<Tree>, ITreeRepository
    {
        public TreeRepository( ArboretumContext context ) : base( context )
        {

        }

        //public IEnumerable<Tree> GetTrees(IMapViewport viewport)
        //{
        //    ArboretumContext.Tree.w
        //}

        //public Tree GetTrees(QuizOption option, IMapViewport viewport)
        //{
        //    throw new NotImplementedException();
        //}

        //public Tree GetTreeById(int id)
        //{
        //    return (_context as ArboretumContext).Tree.Find(id);
        //}

        //public ArboretumContext ArboretumContext
        //{
        //    get { return _context as ArboretumContext; }
        //}
    }
}
