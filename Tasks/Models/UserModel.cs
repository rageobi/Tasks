using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tasks.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("First Name")]
        [Description("Please Enter you First Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} should be of length 1 to 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Last Name")]
        [Description("Please Enter you Last Name")]
        [StringLength(50, MinimumLength = 1,ErrorMessage = "{0} should be of length 1 to 50 characters")]
        public string LastName { get; set; }
        public string FullName {
            get {
                return this.FirstName + ' ' + this.LastName;
            } 
        }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Username")]
        [Description("Please Enter you User Name")]
        [StringLength(15, MinimumLength = 1,ErrorMessage = "{0} should be of length 1 to 15 characters")]
        public string UserName
        {
            get;set;
        }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Password")]
        [Description("Please Enter you Password")]
        [RegularExpression(@" [a-zA-Z0-9!@#$%^&*]{6,16}", ErrorMessage = "Weak password. Please enter an alphanumeric text of length 6 to 16 characters.")]
        public string Password { get; set; }
    }
}