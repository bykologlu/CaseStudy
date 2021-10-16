using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Const.Enums;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Data.Abstract;
using Data.Concrete.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PassengerManager>().As<IPassengerService>().SingleInstance();
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();

            builder.RegisterType<PassengerOfflineDalMC>()
                   .As<IPassengerDal>().Keyed<IPassengerDal>(DataProviders.Offline);

            builder.RegisterType<PassengerOnlineDalMC>()
                   .As<IPassengerDal>().Keyed<IPassengerDal>(DataProviders.Online);

            builder.Register<Func<DataProviders, IPassengerDal>>(c =>
            {
                var componentContext = c.Resolve<IComponentContext>();
                return (dataProvider) =>
                {
                    var dataService = componentContext.ResolveKeyed<IPassengerDal>(dataProvider);
                    return dataService;
                };
            });
        }
    }
}
