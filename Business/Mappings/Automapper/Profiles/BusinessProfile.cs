using AutoMapper;
using Core.Const.Enums;
using Core.DTOs.Passenger.Request;
using Core.DTOs.Passenger.Response;
using Core.Utilities.Extensions;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings.Automapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<PassengerDto, Passenger>().ReverseMap()
                .ForMember(d => d.Id, s => s.MapFrom(p => p.UniquePassengerId))
                .ForMember(d => d.GenderName, s => s.MapFrom(j => ((Genders)j.Gender).ToName()))
                .ForMember(d => d.DocumentTypeName, s => s.MapFrom(j => ((DocumentTypes)j.DocumentType).ToName()));

            CreateMap<UpdatePassengerRequestDto, Passenger>()
                .ForMember(d => d.UniquePassengerId, s => s.MapFrom(p => p.Id));

            CreateMap<AddPassengerRequestDto, Passenger>().ReverseMap();

            
        }
    }

}
