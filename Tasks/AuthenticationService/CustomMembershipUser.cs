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
		private readonly User _userData;

		public User UserData
		{
			get { return _userData; }
		}
		public CustomMemberShipUser(string providername, User userData) :
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