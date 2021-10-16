using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Responses
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public Response(bool success)
        {
            Success = success;
        }

        [JsonConstructor]
        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }
    }
}
