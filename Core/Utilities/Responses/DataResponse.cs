using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Responses
{
    public class DataResponse<T> :Response, IDataResponse<T>
    {
        public T Data { get; set; }

        public DataResponse(T data, bool success) : base(success)
        {
            Data = data;
        }

        [JsonConstructor]
        public DataResponse(T data, bool success, string message) : base(success,message)
        {
            Data = data;
        }
    }
}
