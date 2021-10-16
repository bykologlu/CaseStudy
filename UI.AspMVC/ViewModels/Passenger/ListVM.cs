using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.AspMVC.ViewModels.Passenger.SubModels;

namespace UI.AspMVC.ViewModels.Passenger
{
    public class ListVM
    {
        public ListVM()
        {
            Passengers = new List<PassengerItemModel>();
        }

        public int DataProvider { get; set; }
        public List<PassengerItemModel> Passengers { get; set; }
    }
}