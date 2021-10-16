using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Const.Enums
{
    public enum DocumentTypes
    {
        [Description("Pasaport")]
        Pasaport = 1,
        [Description("Vize")]
        Visa = 2,
        [Description("Seyahat Belgesi")]
        TravelDocument = 3
    }
}
