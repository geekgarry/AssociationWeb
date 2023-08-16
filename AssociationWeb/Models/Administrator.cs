using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class Administrator
	{
		private string id;
		private string username;
		private string password;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Username { get => username; set => username = value; }
		public string Password { get => password; set => password = value; }
		public string Create_time { get => create_time; set => create_time = value; }
	}
}
