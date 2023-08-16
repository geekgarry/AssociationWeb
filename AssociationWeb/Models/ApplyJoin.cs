using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class ApplyJoin
	{
		private string id;
		private string stuid;
		private string associationid;
		private string realname;
		private string hobbyspeciality;
		private string applyreason;
		private string personalintro;
		private string applyassociation;
		private string auditstatus;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Stuid { get => stuid; set => stuid = value; }
		public string Associationid { get => associationid; set => associationid = value; }
		public string Realname { get => realname; set => realname = value; }
		public string Hobbyspeciality { get => hobbyspeciality; set => hobbyspeciality = value; }
		public string Applyreason { get => applyreason; set => applyreason = value; }
		public string Personalintro { get => personalintro; set => personalintro = value; }
		public string Applyassociation { get => applyassociation; set => applyassociation = value; }
		public string Create_time { get => create_time; set => create_time = value; }
		public string Auditstatus { get => auditstatus; set => auditstatus = value; }
	}
}
