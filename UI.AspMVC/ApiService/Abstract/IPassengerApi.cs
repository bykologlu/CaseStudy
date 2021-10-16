using Core.DTOs.Passenger.Request;
using Core.DTOs.Passenger.Response;
using Core.Utilities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.AspMVC.ApiService.Abstract
{
    public interface IPassengerApi
    {
        IResponse Add(AddPassengerRequestDto request);
        IResponse CreateDummyData();
        IResponse Update(UpdatePassengerRequestDto request);
        IResponse Delete(DeletePassengerRequestDto request);
        IDataResponse<PassengerDto> Get(GetPassengerRequestDto request);
        IDataResponse<List<PassengerDto>> GetList(GetPassengerListRequestDto request);
    }
}
