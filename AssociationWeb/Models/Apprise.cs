using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class Apprise
	{
		private string id;
		private string stuid;
		private string apprisecontent;
		private string suggestcontent;
		private string associationid;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Stuid { get => stuid; set => stuid = value; }
		public string Apprisecontent { get => apprisecontent; set => apprisecontent = value; }
		public string Suggestcontent { get => suggestcontent; set => suggestcontent = value; }
		public string Associationid { get => associationid; set => associationid = value; }
		public string Create_time { get => create_time; set => create_time = value; }
	}
}
