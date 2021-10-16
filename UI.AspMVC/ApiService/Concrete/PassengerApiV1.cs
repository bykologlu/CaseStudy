using Core.DTOs.Passenger.Request;
using Core.DTOs.Passenger.Response;
using Core.Utilities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using UI.AspMVC.ApiService.Abstract;

namespace UI.AspMVC.ApiService.Concrete
{
    public class PassengerApiV1 : IPassengerApi
    {
        public IResponse Add(AddPassengerRequestDto request)
        {
            IResponse response = new ApiServiceHelper().Post<Response>("passengers/add", request);

            return response;
        }

        public IResponse CreateDummyData()
        {
            IResponse response = new ApiServiceHelper().Post<Response>("passengers/createdummydata",null);

            return response;
        }

        public IResponse Delete(DeletePassengerRequestDto request)
        {
            IResponse response = new ApiServiceHelper().Post<Response>("passengers/delete", request);

            return response;
        }

        public IDataResponse<PassengerDto> Get(GetPassengerRequestDto request)
        {
            Dictionary<string,string> query = ConvertObjectToDictionary(request);

            IDataResponse<PassengerDto> response = new ApiServiceHelper().GetQuery<DataResponse<PassengerDto>>("passengers/get", query);

            return response;
        }

        public IDataResponse<List<PassengerDto>> GetList(GetPassengerListRequestDto request)
        {
            Dictionary<string, string> query = ConvertObjectToDictionary(request);

            IDataResponse<List<PassengerDto>> response = new ApiServiceHelper().GetQuery<DataResponse<List<PassengerDto>>>("passengers/getlist", query);

            return response;
        }

        public IResponse Update(UpdatePassengerRequestDto request)
        {
            IResponse response = new ApiServiceHelper().Post<Response>("passengers/update", request);

            return response;
        }


        private Dictionary<string,string> ConvertObjectToDictionary(object data)
        {
            return data.GetType()
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .ToDictionary(prop => prop.Name, prop => prop.GetValue(data).ToString());
        }
    }
}