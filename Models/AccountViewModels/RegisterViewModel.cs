using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Frist Name")]
        [MaxLength(30, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(30, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Gender { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        [Display(Name = "Personal Health Number")]
        public string PersonalHealthNumber { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Next Of Kin Full Name")]
        [MaxLength(60, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string NextOfKinFullName { get; set; }

        [Display(Name = "Next Of Kin Phone Number")]
        [MaxLength(15, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string NextOfKinPhoneNumber { get; set; }

        [Display(Name = "Street")]
        [MaxLength(80, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string AddressStreet { get; set; }

        [Display(Name = "City")]
        [MaxLength(30, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string AddressCity { get; set; }

        [Display(Name = "Province")]
        [MaxLength(20, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string AddressProvince { get; set; }

        [Display(Name = "Postal Code")]
        [MaxLength(10, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string AddressPostalCode { get; set; }

        [Display(Name = "Country")]
        [MaxLength(15, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string AddressCountry { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [MaxLength(15, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        [Display(Name = "Email")]
        [MaxLength(60, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MaxLength(20, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [MaxLength(20, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string ConfirmPassword { get; set; }
    }
}
