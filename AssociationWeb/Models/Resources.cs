using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class Resources
	{
		private string id;
		private string dtitle;
		private string dcontent;
		private string dtype;
		private string dfileposition;
		private string upid;
		private string upidname;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Dtitle { get => dtitle; set => dtitle = value; }
		public string Dcontent { get => dcontent; set => dcontent = value; }
		public string Dtype { get => dtype; set => dtype = value; }
		public string Dfileposition { get => dfileposition; set => dfileposition = value; }
		public string Create_time { get => create_time; set => create_time = value; }
		public string Upid { get => upid; set => upid = value; }
		public string Upidname { get => upidname; set => upidname = value; }
	}
}
