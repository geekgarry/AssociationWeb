using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class ActivityComment
	{
		private string id;
		private string stuid;
		private string activitycomment;
		private string associationactivityid;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Stuid { get => stuid; set => stuid = value; }
		public string Activitycomment { get => activitycomment; set => activitycomment = value; }
		public string Associationactivityid { get => associationactivityid; set => associationactivityid = value; }
		public string Create_time { get => create_time; set => create_time = value; }
	}
}
