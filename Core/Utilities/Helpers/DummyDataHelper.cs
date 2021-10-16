using Core.Const.Enums;
using Core.DTOs.Passenger.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class DummyDataHelper
    {
        static string[] names = {"Mehmet","Ali","Can","Gizem","Selma","Merve","Kübra" };
        static string[] surnames = { "Karasu", "Özgül", "Yılmaz", "Gül", "Yıldırım", "Korkmaz", "Çiçek" };

        static List<AddPassengerRequestDto> passengers = new List<AddPassengerRequestDto>();

        public static List<AddPassengerRequestDto> CreateData()
        {
            for(int i = 0; i < names.Length; i++)
            {
                Thread.Sleep(10);
                passengers.Add(new AddPassengerRequestDto
                {
                    DataProvider = new Random().Next(1, 3),
                    Name = names[i],
                    Surname = surnames[i],
                    DocumentNo = new Random().Next(10000, 99999).ToString(),
                    DocumentType = new Random().Next(1, 4),
                    Gender = new Random().Next(1, 3),
                    IssueDate = DateTime.Today.AddDays(-new Random().Next(1000, 5000))
                });
            }

            return passengers;
        }
    }
}
