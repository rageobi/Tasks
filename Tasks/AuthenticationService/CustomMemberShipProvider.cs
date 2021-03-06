﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Security;
using Tasks;
using Tasks.Helpers;
using Tasks.Models;

namespace Tasks.AuthenticationService
{
    public class CustomMemberShipProvider : MembershipProvider
    {
        private readonly TasksHelper service = new TasksHelper();

        public override bool ValidateUser(string username, string password)
        {
            return service.ValidateUser(username, password);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline = true)
        {
            if (service.UserExists(username))
                return new CustomMemberShipUser(Membership.Provider.ApplicationName, service.GetUser(username));
            return null;
        }

        public override void UpdateUser(MembershipUser userToUpdate)
        {
            var user = (CustomMemberShipUser)userToUpdate;

            var result = service.UpdateUser(user.UserData);
            if (!result)
                throw new Exception("User has not been updated");
        }

        public override string ApplicationName
        {
            get { return "MyCustomMembership"; }
            set { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval => throw new NotImplementedException();

        public override bool EnablePasswordReset => throw new NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

        public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

        public override int PasswordAttemptWindow => throw new NotImplementedException();

        public override bool RequiresUniqueEmail => throw new NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

        public override int MinRequiredPasswordLength => throw new NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

    }

}