using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Cache
{
    public interface ICache
    {
        long Del(params string[] key);

        Task<long> DelAsync(params string[] key);

        bool Exists(string key);

        Task<bool> ExistsAsync(string key);

        string Get(string key);

        Task<string> GetAsync(string key);

        bool Set(string key,object value);

        bool Set(string key, object value, TimeSpan timeSpan);

        Task<bool> SetAsync(string key, object value);

        Task<bool> SetAsync(string key, object value,TimeSpan timeSpan);

    }
}
