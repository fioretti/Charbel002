using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Akavache;
using GiftCert.Mobile.Core.Constants;
using GiftCert.Mobile.Core.Contracts.Services.Data;
using GiftCert.Mobile.Core.Extensions;
using GiftCert.Mobile.Core.Models;
using System.Reactive.Linq;
using GiftCert.Mobile.Core.Contracts.Repository;

namespace GiftCert.Mobile.Core.Services.Data
{
    public class CatalogDataService : BaseService, ICatalogDataService
    {
        private readonly IGenericRepository _genericRepository;
        
        public CatalogDataService(IGenericRepository genericRepository, IBlobCache cache = null): base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Pie>> GetAllPiesAsync()
        {
            List<Pie> piesFromCache = await GetFromCache<List<Pie>>(CacheNameConstants.AllPies);

            if (piesFromCache != null)//loaded from cache
            {
                return piesFromCache;
            }
            else
            {
                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.CatalogEndpoint
                };

                var pies = await _genericRepository.GetAsync<List<Pie>>(builder.ToString());

                await Cache.InsertObject(CacheNameConstants.AllPies, pies, DateTimeOffset.Now.AddSeconds(20));

                return pies;
            }
        }

        public async Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync()
        {
            List<Pie> piesFromCache = await GetFromCache<List<Pie>>(CacheNameConstants.PiesOfTheWeek);

            if (piesFromCache != null)//loaded from cache
            {
                return piesFromCache;
            }

            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.PiesOfTheWeekEndpoint
            };

            var pies = await _genericRepository.GetAsync<List<Pie>>(builder.ToString());

            await Cache.InsertObject(CacheNameConstants.PiesOfTheWeek, pies, DateTimeOffset.Now.AddSeconds(20));

            return pies;
        }
    }
}
