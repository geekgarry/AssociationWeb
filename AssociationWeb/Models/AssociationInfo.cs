using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class AssociationInfo
	{
		private string ids;
		private string id;
		private string username;
		private string password;
		private string associationname;
		private string associationintro;
		private string teacherincharge;
		private string stuincharge;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Username { get => username; set => username = value; }
		public string Password { get => password; set => password = value; }
		public string Associationname { get => associationname; set => associationname = value; }
		public string Associationintro { get => associationintro; set => associationintro = value; }
		public string Teacherincharge { get => teacherincharge; set => teacherincharge = value; }
		public string Stuincharge { get => stuincharge; set => stuincharge = value; }
		public string Create_time { get => create_time; set => create_time = value; }
		public string Ids { get => ids; set => ids = value; }
	}
}
