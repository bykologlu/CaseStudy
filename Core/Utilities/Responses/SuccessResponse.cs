using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(true)
        {

        }

        public SuccessResponse(string message) : base(true,message)
        {

        }
    }
}
