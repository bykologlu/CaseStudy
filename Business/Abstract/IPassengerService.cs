using Core.Const.Enums;
using Core.DTOs.Passenger;
using Core.DTOs.Passenger.Request;
using Core.DTOs.Passenger.Response;
using Core.Utilities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPassengerService
    {
        IResponse Add(AddPassengerRequestDto request);

        IResponse Update(UpdatePassengerRequestDto request);

        IResponse Delete(DeletePassengerRequestDto request);

        IDataResponse<PassengerDto> Get(GetPassengerRequestDto request);

        IDataResponse<List<PassengerDto>> GetList(GetPassengerListRequestDto request);
    }
}
