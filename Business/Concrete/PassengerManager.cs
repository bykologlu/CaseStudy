using AutoMapper;
using Business.Abstract;
using Core.Const.Enums;
using Core.Const.Messages.PostMessages;
using Core.DTOs.Passenger;
using Core.DTOs.Passenger.Request;
using Core.DTOs.Passenger.Response;
using Core.Utilities.Responses;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PassengerManager : IPassengerService
    {
        Func<DataProviders, IPassengerDal>  _passengerDal;
        IMapper _mapper;

        public PassengerManager(Func<DataProviders, IPassengerDal> passengerDal, IMapper mapper)
        {
            _passengerDal = passengerDal;
            _mapper = mapper;
        }
        public IResponse Add(AddPassengerRequestDto request)
        {
            Passenger passenger = _mapper.Map<Passenger>(request);

            _passengerDal((DataProviders)request.DataProvider).Add(passenger);

            return new SuccessResponse(PassengerPostMessages.AddedSuccess);
        }

        public IResponse Delete(DeletePassengerRequestDto request)
        {
            Passenger curentPassenger = FindPassengerById(request.Id, (DataProviders) request.DataProvider);

            _passengerDal((DataProviders)request.DataProvider).Delete(curentPassenger);

            return new SuccessResponse(PassengerPostMessages.DeletedSuccess);
        }

        public IDataResponse<PassengerDto> Get(GetPassengerRequestDto request)
        {
            Passenger curentPassenger = FindPassengerById(request.Id, (DataProviders)request.DataProvider);

            return new SuccessDataResponse<PassengerDto>(_mapper.Map<PassengerDto>(curentPassenger));
        }

        public IDataResponse<List<PassengerDto>> GetList(GetPassengerListRequestDto request)
        {
            List<Passenger> passengers = _passengerDal((DataProviders)request.DataProvider).GetList();

            return new SuccessDataResponse<List<PassengerDto>>(_mapper.Map<List<Passenger>, List<PassengerDto>>(passengers));
        }

        public IResponse Update(UpdatePassengerRequestDto request)
        {
            Passenger curentPassenger = FindPassengerById(request.Id, (DataProviders)request.DataProvider);

            curentPassenger = _mapper.Map<UpdatePassengerRequestDto, Passenger>(request); 

            _passengerDal((DataProviders)request.DataProvider).Update(curentPassenger);

            return new SuccessResponse(PassengerPostMessages.UpdatedSuccess);

        }

        private Passenger FindPassengerById(string id, DataProviders dataProvider)
        {
            Passenger passenger = _passengerDal(dataProvider).Get(id);

            if(passenger == null)
                throw new Exception(PassengerPostMessages.NotFound);

            return passenger;
        }
    }
}
