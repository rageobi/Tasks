using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class TaskModel
    {
        public static int TaskID { get { return TaskID; } set { TaskID = 1; } }
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Task Description")]
        [Description("Please Enter you User Name")]
        public string TaskDescription { get; set; }
        [Description("Is the task complete?")]
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn
        {
            get
            {
                return CreatedOn;
            }
            set => CreatedOn = DateTime.UtcNow;
        }
        public int UserID
        {
            get
            {
                return this.UserID;
            }
            set => UserID = value;
        }
    }
}