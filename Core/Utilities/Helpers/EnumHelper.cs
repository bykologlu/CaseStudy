using Core.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class EnumHelper
    {
        public static List<EnumListItem> GetEnumList<TEnum>() where TEnum : Enum
        {
            return (from TEnum tType in Enum.GetValues(typeof(TEnum))
                    select new { Id = tType.GetHashCode(), Name = tType.ToName() }).ToList()
                     .Select(j => new EnumListItem
                     {
                         Id = j.Id,
                         Name = j.Name
                     }).ToList();
        }
    }
}
