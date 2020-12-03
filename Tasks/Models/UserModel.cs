using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Tasks.Models
{
    public class User
    {
        public static int _UserId { get; set; } = 0;
        public int UserId
        {
            get; set;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return this.FirstName + ' ' + this.LastName;
            }
        }
        public string Username { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public User()
        {
            _UserId += 1;
        }
    }
}