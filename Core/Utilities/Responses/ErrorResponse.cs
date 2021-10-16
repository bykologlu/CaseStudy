﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Responses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse() : base(false)
        {

        }

        public ErrorResponse(string message) : base(false,message)
        {

        }
    }
}
