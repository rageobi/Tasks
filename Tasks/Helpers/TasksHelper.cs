using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tasks.Models;

namespace Tasks.Helpers
{
    public class TasksHelper
    {
        public static IList<User> Users = new List<User>();
        public static IList<Task> Tasks = new List<Task>();

        public IEnumerable<Task> GetUserTasks(int userId)
        {
            IList<Task> UserTasks = Tasks.Where(x => x.UserId.Equals(userId)).ToList();
            return UserTasks;
        }
        public Task GetTask(int taskId)
        {
            Task task = Tasks.FirstOrDefault(x => x.TaskId.Equals(taskId));
            return task;
        }
        public bool ValidateUser(string username, string password)
        {
            User user = Users.FirstOrDefault(x => x.Username.Equals(username));
            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UserExists(string userName)
        {
            User user = Users.FirstOrDefault(x => x.Username.Equals(userName));
            if (user != null)
                return true;
            return false;
        }
        public User GetUser(string userName)
        {
            User user = Users.FirstOrDefault(x => x.Username.Equals(userName));
            return user;
        }

        public int GetUserID(string username)
        {
            int userID = Users.FirstOrDefault(x => x.Username.Equals(username)).UserId;
            return userID;
        }

        public bool UpdateUser(User user)
        {
            //implementation here
            return false;
        }
    }
}