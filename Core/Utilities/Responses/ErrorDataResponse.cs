using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Responses
{
    public class ErrorDataResponse<T> : DataResponse<T>
    {
        public ErrorDataResponse() : base(default, false)
        {

        }


        public ErrorDataResponse(string message) : base(default,false,message)
        {

        }

    }
}
