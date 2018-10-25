using Arboretum.API.Helpers.Converters.Interfaces;
using Arboretum.Core.Entities;
using Arboretum.Core.Models;
using Arboretum.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.API.Helpers.Converters
{
    public class TreeToDtoConverter : IConverter<Tree, TreeDto>
    {
        public TreeDto Convert( Tree source )
        {
            throw new NotImplementedException( );
        }
    }
}
