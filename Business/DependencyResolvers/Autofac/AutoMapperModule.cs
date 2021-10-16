using Autofac;
using AutoMapper;
using Business.Mappings.Automapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(j => CreateConfiguration()).AsSelf().SingleInstance();
            builder.Register(j => j.Resolve<MapperConfiguration>().CreateMapper(j.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(j => j.AddProfile(new BusinessProfile()));

            return config;
        }
    }
}
