using Core.Const.Enums;
using Core.CrossCuttingConcerns.Caching;
using Data.Concrete.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public class PassengerDalFactory
    {
        public static IPassengerDal GetPassengerDal(DataProviders dataProvider, ICacheManager cacheManager)
        {
            switch(dataProvider)
            {
                case DataProviders.Online: return new PassengerOnlineDalMC(cacheManager);
                case DataProviders.Offline: return new PassengerOfflineDalMC(cacheManager);
                default: return null;
            }
        }
    }
}
