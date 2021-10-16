using Core.CrossCuttingConcerns.Caching;
using Core.Data.MemoryCache;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.MemoryCache
{
    public class PassengerOfflineDalMC : MCEntityRepositoryBase<Passenger>, IPassengerDal
    {
        ICacheManager _cacheManager;
        public PassengerOfflineDalMC(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public override void Add(Passenger entity)
        {
            string uniqueId = Guid.NewGuid().ToString();

            entity.UniquePassengerId = uniqueId;

            string key = string.Format("{0}({1})",this.GetType().Name, uniqueId);

            _cacheManager.Add(key, entity);

        }

        public override void Delete(Passenger entity)
        {
            string key = string.Format("{0}({1})", this.GetType().Name, entity.UniquePassengerId);
            
            _cacheManager.Remove(key);
        }


        public override Passenger Get(string id)
        {
            string key = string.Format("{0}({1})", this.GetType().Name, id);

            return _cacheManager.Get<Passenger>(key);
        }
         
        public override List<Passenger> GetList()
        {
            string pattern = this.GetType().Name;

            return _cacheManager.GetList<Passenger>(pattern);
        }
         

        public override void Update(Passenger entity)
        {
            string key = string.Format("{0}({1})", this.GetType().Name, entity.UniquePassengerId);

            _cacheManager.Remove(key);

            _cacheManager.Add(key, entity);
        }
    }
}
