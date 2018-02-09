using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolForum.Models
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
        //[Required]
        //[Display(Name = "Role")]
        //public string UserRoles { get; set; }
            

        //[Required]
        //[Display(Name = "Category")]
        //public string CategoryName { get; set; }
        
        public string UserRoleName { get; set; }

        public int ClassId { get; set; }
        //---------------------------------------------

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z'' ']+$", ErrorMessage = "Special characters  & Numbers are not allowed")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z'' ']+$", ErrorMessage = "Special characters  & Numbers are not allowed")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Column(TypeName="datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        //-----------------------------------------------------------------

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


    public class GroupedUserViewModel
    {
        public List<UserViewModel> Students { get; set; }
        public List<UserViewModel> Teachers { get; set; }
    }
    public class UserViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string ClassName { get; set; }
       
    }
}
