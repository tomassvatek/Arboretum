using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common.Enums;
using Arboretum.Web.ViewModels;

namespace Arboretum.Web.Mappers
{
    public static class ViewModelMapper
    {
        public static List<TreeViewModel> MapTreeToViewModel(IList<ITree> trees)
        {
            var treesViewModels = trees.Select(tree => new TreeViewModel
            {
                Id = tree.Id,
                Age = tree.Age,
                CrownSize = tree.CrownSize,
                TreeNote = tree.Note,
                Height = tree.Height,
                Latitude = tree.Latitude,
                Longitude = tree.Longitude,
                DendrologyId = tree.Dendrology.Id,
                CommonName = tree.Dendrology.CommonName,
                ScientificName = tree.Dendrology.ScientificName,
                AboutDendrology = tree.Dendrology.About,
                IsEditable = tree.IsEditable,
                ProviderId = tree.ProviderName
            }).ToList();

            return treesViewModels; 
        }

        public static TreeViewModel MapTreeToViewModel(ITree tree)
        {
            var treeViewModels = new TreeViewModel  
            {
                Id = tree.Id,
                Age = tree.Age,
                CrownSize = tree.CrownSize,
                TreeNote = tree.Note,
                Height = tree.Height,
                Latitude = tree.Latitude,
                Longitude = tree.Longitude,
                DendrologyId = tree.Dendrology.Id,
                CommonName = tree.Dendrology.CommonName,
                ScientificName = tree.Dendrology.ScientificName,
                AboutDendrology = tree.Dendrology.About,
                IsEditable = tree.IsEditable,
                ProviderId = tree.ProviderName
            };

            return treeViewModels;
        }
    }
}
