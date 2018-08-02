using System;
using System.Collections.Generic;
using System.Linq;
using Arboretum.Core.Extensions;
using Arboretum.Core.Models;

namespace Arboretum.Core.Modules.Locations
{
    public class HaverniseDistance : IDistanceCalculator
    {
        private IList<TreeDistance> _results;

        /// <summary>
        /// Inicializuje novou instanci třídy <see cref="HaverniseDistance"/>.
        /// </summary>
        public HaverniseDistance()
        {
            _results = new List<TreeDistance>();
        }

        /// <summary>
        /// Vrací vzestupně seřazené výsledky výpočtu.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TreeDistance> GetResults(LatLng current, IEnumerable<Tree> trees)
        {
            LoadTrees(trees);

            foreach (var item in _results)
            {
                //item.Distance = Calculate(current.Latitude, current.Longitude, item.Tree.LatLng.Latitude, item.Tree.LatLng.Longitude);
            }

            Sort();
            return _results;
        }


        /// <summary>
        /// Seřadí položky v instační proměnné trees vzestupně podle vzdálenosti.
        /// </summary>
        private void Sort()
        {
            _results = _results.OrderBy(t => t.Distance).ToList();
        }

        private double Calculate( double lat1, double lon1, double lat2, double lon2 )
        {
            var r = 6372.8;
            var dLat = lat2 - lat1;
            var dLon = lon2 - lon1;

            // Convert to radians
            dLat = dLat.ToRadians();
            dLon = dLon.ToRadians();
            lat1 = lat1.ToRadians();
            lat2 = lat2.ToRadians();

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return r * 2 * Math.Asin(Math.Sqrt(a)) / 1000;
        }

        /// <summary>
        /// Inicializuje instační proměnou results.
        /// </summary>
        /// <param name="trees">Stromy.</param>
        private void LoadTrees(IEnumerable<Tree> trees)
        {
            foreach (var tree in trees)
            {
                _results.Add(new TreeDistance() { Tree = tree });
            }
        }
    }
}
