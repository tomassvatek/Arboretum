using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Services
{
    interface ITreeService
    {
        IEnumerable<Tree> GetTrees();
        Tree GetTrees(QuizOption option, IMapViewport viewport);
        Tree GetTreeById(int id);
    }
}
