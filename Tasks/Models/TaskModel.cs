using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Task
    {
        public Task()
        {
            TaskId += 1;
        }
        public static int TaskId { get; set; } = 0;

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Task Description")]
        [Description("Please Enter you User Name")]
        public string TaskDescription { get; set; }
        [Description("Is the task complete?")]
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; }
        public int UserID { get; set; }
    }
}