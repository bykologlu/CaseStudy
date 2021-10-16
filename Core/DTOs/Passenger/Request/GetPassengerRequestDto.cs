using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Passenger.Request
{
    public class GetPassengerRequestDto : BaseRequestDto
    {
        public string Id { get; set; }
    }
}
