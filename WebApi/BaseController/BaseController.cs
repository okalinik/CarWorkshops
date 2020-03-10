using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace WebApi.BaseController
{
    public class BaseController : ControllerBase
    {
        private IMemoryCache _cache;

        public BaseController(IMemoryCache cache)
        {
            _cache = cache;
        }

        protected T GetOrCreateCacheEntry<T>(string key, Func<Task<T>> getData, int cacheTimeInSeconds)
        {
            T cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = getData().Result;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheTimeInSeconds));
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }
}
