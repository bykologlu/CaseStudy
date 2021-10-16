using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Const.Enums
{
    public enum DataProviders
    {
        [Description("Online")]
        Online = 1,
        [Description("Offline")]
        Offline = 2
    }
}
