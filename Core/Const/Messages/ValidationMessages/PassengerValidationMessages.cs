using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Const.Messages.ValidationMessages
{
    public class PassengerValidationMessages
    {
        public const string DataProviderRequired = "Veri Sağlayıcı seçimi zorunludur.";
        public const string NameRequired = "İsim bilgisi zorunludur.";
        public const string SurnameRequired = "Soyisim bilgisi zorunludur.";
        public const string GenderRequired = "Cinsiyet seçimi zorunludur.";
        public const string DocumentNoRequired = "Belge no bilgisi zorunludur.";
        public const string DocumentTypeRequired = "Belge türü seçimi zorunludur.";
        public const string IssueDateRequired = "Belge veriliş tarihi zorunludur.";
        public const string UserIdRequired = "Kullanıcı ID'si zorunludur.";
    }
}
