using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Tasks.Models;

namespace Tasks.AuthenticationService
{
	public class CustomMemberShipUser : MembershipUser
	{
		private readonly UserModel _userData;

		public UserModel UserData
		{
			get { return _userData; }
		}
		public CustomMemberShipUser(string providername, UserModel userData) :
		base(providername,
			 userData.FullName,
			 userData.UserId,
			 userData.Email,
			 string.Empty,
			 string.Empty,
			 true,
			 true,
			 userData.CreationDate,
			 DateTime.Now,
			 DateTime.Now,
			 DateTime.Now,
			 DateTime.Now)
		{
			this._userData = userData;
		}
	}
}