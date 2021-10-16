using Business.Abstract;
using Core.Const.Enums;
using Core.DTOs.Passenger;
using Core.DTOs.Passenger.Request;
using Core.DTOs.Passenger.Response;
using Core.Utilities.Helpers;
using Core.Utilities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [Route("api/passengers")]
    public class PassengersController : ApiController
    {
        IPassengerService _passengerManager;

        public PassengersController(IPassengerService passengerManager)
        {
            _passengerManager = passengerManager;
        }

        [Route("api/passengers/get")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetPassengerRequestDto request)
        {
            IDataResponse<PassengerDto> response = _passengerManager.Get(request);

            return Ok(response);
        }

        [Route("api/passengers/getlist")]
        [HttpGet]
        public IHttpActionResult GetList([FromUri] GetPassengerListRequestDto request)
        {
            IDataResponse<List<PassengerDto>> response  = _passengerManager.GetList(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("api/passengers/add")]
        public IHttpActionResult Add(AddPassengerRequestDto request)
        {
            IResponse response = _passengerManager.Add(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("api/passengers/update")]
        public IHttpActionResult Update(UpdatePassengerRequestDto request)
        {
            IResponse response = _passengerManager.Update(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("api/passengers/delete")]
        public IHttpActionResult Delete(DeletePassengerRequestDto request)
        {
            IResponse response = _passengerManager.Delete(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("api/passengers/createdummydata")]
        public IHttpActionResult CreateDummyData()
        {
            var passengers = DummyDataHelper.CreateData();

            foreach (var passenger in passengers)
                _passengerManager.Add(passenger);

            return Ok();
        }
    }
}
