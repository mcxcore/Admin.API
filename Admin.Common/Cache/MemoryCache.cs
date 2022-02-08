using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Cache
{
    public class MemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public long Del(params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<long> DelAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string key)
        {
            throw new NotImplementedException();
        }

        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public bool Set(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool Set(string key, object value, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync(string key, object value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync(string key, object value, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }
    }
}
