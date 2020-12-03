using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Task
    {
        public static int _TaskId { get; set; } = 0;
        public int TaskId { get; set;}

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Task Description")]
        [Description("Please Enter your task description")]
        public string TaskDescription { get; set; }
        [Description("Is the task complete?")]
        [DisplayName("Task Status")]
        public bool IsCompleted { get; set; }
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [DisplayName("Last Updated")]
        public DateTime LastUpdated { get; set; }

        public int UserId { get; set; }
    }
}