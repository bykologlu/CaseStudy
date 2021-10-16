using Core.Const.Enums;
using Core.DTOs.Passenger.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.AspMVC.ApiService.Abstract;
using UI.AspMVC.ViewModels.Passenger;
using UI.AspMVC.ViewModels.Passenger.SubModels;
using Core.Utilities.Extensions;
using Core.Utilities.Helpers;
using UI.AspMVC.Filters;
using Core.Utilities.Responses;

namespace UI.AspMVC.Controllers
{
    public class PassengerController : Controller
    {
        IPassengerApi _passengerApi;

        public PassengerController(IPassengerApi passengerApi)
        {
            _passengerApi = passengerApi;
        }

        public ActionResult Index()
        {
            IndexVM model = new IndexVM();

            return View(model);
        }

        public ActionResult Add()
        {
            List<EnumListItem> genders = EnumHelper.GetEnumList<Genders>();

            List<EnumListItem> documentTypes = EnumHelper.GetEnumList<DocumentTypes>();

            List<EnumListItem> dataProviders = EnumHelper.GetEnumList<DataProviders>();

            AddVM model = new AddVM
            {
                DocumentTypes = new SelectList(documentTypes, "Id", "Name"),
                Genders = new SelectList(genders, "Id", "Name"),
                DataProviders = new SelectList(dataProviders, "Id", "Name")
            };
            return View(model);
        }

        public ActionResult Update(string id, int? dataProvider)
        {
            if (!dataProvider.HasValue || string.IsNullOrEmpty(id))
                return Redirect("/Passenger");

            var passenger = _passengerApi.Get(new GetPassengerRequestDto { DataProvider = dataProvider.Value, Id = id });

            if(!passenger.Success)
                return Redirect("/Passenger");


            List<EnumListItem> genders = EnumHelper.GetEnumList<Genders>();

            List<EnumListItem> documentTypes = EnumHelper.GetEnumList<DocumentTypes>();

            UpdateVM model = new UpdateVM
            {
                Id = passenger.Data.Id,
                Name = passenger.Data.Name,
                Surname = passenger.Data.Surname,
                DocumentNo = passenger.Data.DocumentNo,
                DocumentType = passenger.Data.DocumentType,
                Gender = passenger.Data.Gender,
                IssueDate = passenger.Data.IssueDate,
                DataProvider = dataProvider.Value,
                DocumentTypes = new SelectList(documentTypes, "Id", "Name"),
                Genders = new SelectList(genders, "Id", "Name")
            };

            return View(model);
        }

        public ActionResult List(int? dataProvider)
        {
            if(!dataProvider.HasValue)
                return Redirect("/Passenger");

            ListVM model = new ListVM {
                DataProvider = dataProvider.Value
            };
            
            var passengers = _passengerApi.GetList(new GetPassengerListRequestDto { DataProvider = dataProvider.Value });

            if (!passengers.Success)
            {
                TempData["Message"] = passengers.Message;
                return View(model);
            }

            model.Passengers = passengers.Data.Select(j => new PassengerItemModel
            {
                Id = j.Id,
                Name = j.Name,
                Surname = j.Surname,
                DocumentNo = j.DocumentNo,
                DocumentTypeName = j.DocumentTypeName,
                GenderName = j.GenderName,
                IssueDate = j.IssueDate
            }).ToList();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateFilter]
        public ActionResult Add(AddVM model)
        {
            IResponse response = _passengerApi.Add(new AddPassengerRequestDto
            {
                DataProvider = model.DataProvider,
                DocumentNo = model.DocumentNo,
                DocumentType = model.DocumentType,
                Gender = model.Gender,
                IssueDate = model.IssueDate,
                Name = model.Name,
                Surname = model.Surname
            });
 
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateFilter]
        public ActionResult Update(UpdateVM model)
        {
            IResponse response = _passengerApi.Update(new UpdatePassengerRequestDto
            {
                DataProvider = model.DataProvider,
                DocumentNo = model.DocumentNo,
                DocumentType = model.DocumentType,
                Gender = model.Gender,
                IssueDate = model.IssueDate,
                Name = model.Name,
                Surname = model.Surname,
                Id = model.Id
            });

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id,int? dataProvider)
        {

            IResponse response = _passengerApi.Delete(new DeletePassengerRequestDto
            {
                DataProvider = dataProvider.Value,
                Id = id
            });

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}