﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common;
using Arboretum.Common.Enums;
using Arboretum.WebService.Helpers;
using Arboretum.WebService.HttpClient;
using Arboretum.WebService.Providers.Interfaces;

namespace Arboretum.WebService.Providers.SPK
{
    public class SPK : ITreeDataProvider
    {
        private readonly IHttpClient _httpClient;

        public SPK(IHttpClient httpClient)
        {
            _httpClient = httpClient;

            // TODO: Move to config file.
            Name = ProviderName.SPK;
            BaseAddress = "https://www.stromypodkontrolou.cz/client_api/v1/";
            RequestHeaders.Add(new RequestHeaders("User-Agent", "arboretum-client-api-consumer-98ebdf2f-6e82-4638-8a4c-24a13cca786e"));
        }

        public ProviderName Name { get; }
        public string BaseAddress { get; }
        public bool IsEditable { get; } = false;
        public IList<RequestHeaders> RequestHeaders { get; set; } = new List<RequestHeaders>();

        public async Task<System.Collections.Generic.IList<Tree>> GetTreesAsync(IRegion region)
        {
            var json = await _httpClient.FetchDataAsync(BaseAddress, $"trees?lat_min={region.LatitudeMin}&lat_max={region.LatitudeMax}&lon_min={region.LongitudeMin}&lon_max={region.LongitudeMax}", RequestHeaders);
            var trees = MapToDomain(json);

            return trees;
        }

        public async Task<Tree> GetTreeByIdAsync(int id)
        {
            //var json = await _httpClient.FetchDataAsync(BaseAddress, $"tree/{id}", RequestHeaders);
            //var dtos = JsonHelper<TreeDto>.DeserializeTree(json);

            //var tree = MapToDomain(dtos).First();

            return null;
        }

        private List<Tree> MapToDomain(string json) 
        {
            var dtos = JsonHelper<TreeDto>.DeserializeTrees(json);
            if (dtos == null)
            {
                throw new ArgumentException();
            }

            var trees = dtos.Select(t => new Tree()
            {
                Id = t.Id,
                Age = t.Age,
                CrownSize = t.CrownSize,
                Height = t.Height,
                Note = t.Note,
                TrunkSize = t.TrunkSize,
                Latitude = t.Coordinates.Latitude,
                Longitude = t.Coordinates.Longitude,
                ProviderName = this.Name,
                IsEditable = this.IsEditable,
                Dendrology = new Dendrology
                {
                    CommonName = t.CommonName,
                    ScientificName = t.ScientificName
                }
            }).ToList();

            return trees;
        }
    }
}