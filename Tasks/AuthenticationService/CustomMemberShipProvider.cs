using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Security;
using Tasks;
using Tasks.Models;

namespace Tasks.AuthenticationService
{
    public class AuthenticationService : IDisposable
    {
        public bool UserExists(string email, string password)
        {
            //implementation here
            return false;
        }

        public UserModel GetUser(string username)
        {
            //implementation here
            return new UserModel();
        }

        public UserModel GetUser(long userId)
        {
            //implementation here
            return new UserModel();

        }

        public bool UpdateUser(UserModel user)
        {
            //implementation here
            return true;
        }

        public void Dispose()
        {
            //implementation here
        }
    }
    public class CustomMemberShipProvider : MembershipProvider
	{
		public override bool ValidateUser(string username, string password)
		{
            using (AuthenticationService service = new AuthenticationService())
			{
				return service.UserExists(username, password);
			}
		}

		public override MembershipUser GetUser(string username, bool userIsOnline=true)
		{
			using (var service = new AuthenticationService())
			{
				var user = service.GetUser(username);

				if (null != user)
					return new CustomMemberShipUser(Membership.Provider.ApplicationName, user);

				return null;
			}
		}

		public override void UpdateUser(MembershipUser userToUpdate)
		{
			var user = (CustomMemberShipUser)userToUpdate;
			using (var service = new AuthenticationService())
			{
				var result = service.UpdateUser(user.UserData);
				if (!result)
					throw new Exception("User has not been updated");
			}

		}

		public override string ApplicationName
		{
			get { return "MyAppMemberShip"; }
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

        ///
        /// 
        /// all overrrided methods
        /// 
        /// 

    }

}