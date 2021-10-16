using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        List<T> GetList<T>(string pattern);

        void Add(string key, object data, int cacheTime = 1440);

        bool IsAdd(string key);

        void Remove(string key);

        void RemoveByPattern(string pattern);

        void Clear();
    }
}
