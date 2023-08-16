using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class StuMember
	{
		private string id;
		private string realname;
		private string nickname;
		private string stuclass;
		private string phonenumber;
		private string password;
		private string hobbyspeciality;
		private string personalintro;
		private string associationids;
		private string collegedepartment;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Realname { get => realname; set => realname = value; }
		public string Stuclass { get => stuclass; set => stuclass = value; }
		public string Phonenumber { get => phonenumber; set => phonenumber = value; }
		public string Password { get => password; set => password = value; }
		public string Hobbyspeciality { get => hobbyspeciality; set => hobbyspeciality = value; }
		public string Personalintro { get => personalintro; set => personalintro = value; }
		public string Associationids { get => associationids; set => associationids = value; }
		public string Collegedepartment { get => collegedepartment; set => collegedepartment = value; }
		public string Create_time { get => create_time; set => create_time = value; }
		public string Nickname { get => nickname; set => nickname = value; }
	}
}
