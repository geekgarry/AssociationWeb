using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class Associationactivity
	{
		private string id;
		private string personalincharge;
		private string activitytitle;
		private string activitycontent;
		private string associationid;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Personalincharge { get => personalincharge; set => personalincharge = value; }
		public string Activitytitle { get => activitytitle; set => activitytitle = value; }
		public string Activitycontent { get => activitycontent; set => activitycontent = value; }
		public string Associationid { get => associationid; set => associationid = value; }
		public string Create_time { get => create_time; set => create_time = value; }
	}
}
