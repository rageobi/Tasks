using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tasks.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("First Name")]
        [Description("Please Enter you First Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} should be of length 1 to 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Last Name")]
        [Description("Please Enter you Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} should be of length 1 to 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Username")]
        [Description("Please Enter your User Name")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "{0} should be of length 1 to 15 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("E-Mail")]
        [Description("Please Enter your Email")]
        //[RegularExpression(@"​^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter a valid Email Address.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Password")]
        [Description("Please Enter you Password")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{6,16}$", ErrorMessage = "Weak password. Please enter an alphanumeric text of length 6 to 16 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}