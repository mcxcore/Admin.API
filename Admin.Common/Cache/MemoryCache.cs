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
            foreach (var item in key) {
                _memoryCache.Remove(item);
            }
            return key.Length;
        }

        public Task<long> DelAsync(params string[] key)
        {
            foreach (var item in key)
            {
                _memoryCache.Remove(item);
            }
            return Task.FromResult((long)key.Length);
        }

        public bool Exists(string key)
        {
            return _memoryCache.TryGetValue(key,out _);
        }

        public Task<bool> ExistsAsync(string key)
        {
            return Task.FromResult(_memoryCache.TryGetValue(key, out _));
        }

        public string Get(string key)
        {
            return _memoryCache.Get<string>(key);
        }

        public Task<string> GetAsync(string key)
        {
            return Task.FromResult(_memoryCache.Get<string>(key));
        }

        public bool Set(string key, object value)
        {
            _memoryCache.Set(key,value);
            return true;
        }

        public bool Set(string key, object value, TimeSpan expire)
        {
            _memoryCache.Set(key,value,expire);
            return true;
        }

        public Task<bool> SetAsync(string key, object value)
        {
            _memoryCache.Set(key, value);
            return Task.FromResult(true);
        }

        public Task<bool> SetAsync(string key, object value, TimeSpan expire)
        {
            _memoryCache.Set(key, value,expire);
            return Task.FromResult(true);
        }
    }
}
