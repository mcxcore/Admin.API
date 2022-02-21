using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Cache
{
    public class RedisCache : ICache
    {
        public long Del(params string[] key)
        {
            return RedisHelper.Del(key);
        }

        public Task<long> DelAsync(params string[] key)
        {
            return RedisHelper.DelAsync(key);
        }

        public bool Exists(string key)
        {
            return RedisHelper.Exists(key);
        }

        public Task<bool> ExistsAsync(string key)
        {
            return RedisHelper.ExistsAsync(key);
        }

        public string Get(string key)
        {
            return RedisHelper.Get<string>(key);
        }

        public Task<string> GetAsync(string key)
        {
            return RedisHelper.GetAsync<string>(key);
        }

        public bool Set(string key, object value)
        {
            return RedisHelper.Set(key,value);
        }

        public bool Set(string key, object value, TimeSpan expire)
        {
            return RedisHelper.Set(key,value, expire);
        }

        public Task<bool> SetAsync(string key, object value)
        {
            return RedisHelper.SetAsync(key,value);
        }

        public Task<bool> SetAsync(string key, object value, TimeSpan expire)
        {
            return RedisHelper.SetAsync(key,value,expire);
        }
    }
}
