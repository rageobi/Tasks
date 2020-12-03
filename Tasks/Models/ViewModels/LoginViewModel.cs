using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tasks.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Username")]
        [Description("Please Enter you User Name")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "{0} should be of length 1 to 15 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Password")]
        [Description("Please Enter you Password")]
        //[RegularExpression(@" [a-zA-Z0-9!@#$%^&*]{6,16}", ErrorMessage = "Weak password. Please enter an alphanumeric text of length 6 to 16 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}