using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Responses
{
    public interface IResponse
    {
        string Message { get; set; }
        bool Success { get; set; }
    }
}
