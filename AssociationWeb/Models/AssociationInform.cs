using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class AssociationInform
	{
		private string id;
		private string noticetitle;
		private string noticecontent;
		private string associationid;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Noticetitle { get => noticetitle; set => noticetitle = value; }
		public string Noticecontent { get => noticecontent; set => noticecontent = value; }
		public string Associationid { get => associationid; set => associationid = value; }
		public string Create_time { get => create_time; set => create_time = value; }
	}
}
