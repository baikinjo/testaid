using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondAid.Models.AccountViewModels
{
    public class UserInfoViewModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        public string Gender { get; set; }
        public string PersonalHealthNumber { get; set; }

        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvince { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountry { get; set; }

        public int ResponseCode { get; set; }
    }
}
