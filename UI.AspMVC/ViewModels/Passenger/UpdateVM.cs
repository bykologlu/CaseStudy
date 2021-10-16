using Core.Const.Messages.PropertyMessages;
using Core.Const.Messages.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.AspMVC.ViewModels.Passenger
{
    public class UpdateVM
    {
        [Required(ErrorMessage = PassengerValidationMessages.DataProviderRequired)]
        public int DataProvider { get; set; }

        [Required(ErrorMessage = PassengerValidationMessages.UserIdRequired)]
        public string Id { get; set; }

        [Display(Name = PassengerPropertyMessages.Name)]
        [Required(ErrorMessage = PassengerValidationMessages.NameRequired)]
        public string Name { get; set; }

        [Display(Name = PassengerPropertyMessages.Surname)]
        [Required(ErrorMessage = PassengerValidationMessages.SurnameRequired)]
        public string Surname { get; set; }

        [Display(Name = PassengerPropertyMessages.Gender)]
        [Required(ErrorMessage = PassengerValidationMessages.GenderRequired)]
        public int Gender { get; set; }

        [Display(Name = PassengerPropertyMessages.DocumentNo)]
        [Required(ErrorMessage = PassengerValidationMessages.DocumentNoRequired)]
        public string DocumentNo { get; set; }

        [Display(Name = PassengerPropertyMessages.DocumentType)]
        [Required(ErrorMessage = PassengerValidationMessages.DocumentTypeRequired)]
        public int DocumentType { get; set; }

        [Display(Name = PassengerPropertyMessages.IssueDate)]
        [Required(ErrorMessage = PassengerValidationMessages.IssueDateRequired)]
        public DateTime IssueDate { get; set; }

        public SelectList Genders { get; set; }

        public SelectList DocumentTypes { get; set; }
    }
}