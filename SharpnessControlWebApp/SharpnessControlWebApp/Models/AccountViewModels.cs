using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        public string Salutation { get; set; }

        [Required]
        public string AcademicTitle { get; set; }

        [Required(ErrorMessage = "Vorname ist erforderlich!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Nachname ist erforderlich!")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "Email stimmt nicht überein")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Das Passwort muss mindestens 2 Zeichnen lang sein", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Das Passwort stimmt nicht überein")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Der Einrichtungsname ist erforderlich!")]
        public string Organisation { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Postleitzahl")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Postleitzahl ist falsch eingegeben")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Das Ort ist erforderlich!")]
        [RegularExpression(@"^.{2,}$", ErrorMessage = "Das Ort muss mindestens 2 Zeichnen lang sein")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Das Land ist erforderlich!")]
        [RegularExpression(@"^.{2,}$", ErrorMessage = "Das Land muss mindestens 2 Zeichnen lang sein")]
        public string Country { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}