using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class CampusNew
	{
		private string id;
		private string newtitle;
		private string newcontent;
		private string editorid;
		private string editorname;
		private string create_time;

		public string Id { get => id; set => id = value; }
		public string Newtitle { get => newtitle; set => newtitle = value; }
		public string Newcontent { get => newcontent; set => newcontent = value; }
		public string Editorid { get => editorid; set => editorid = value; }
		public string Create_time { get => create_time; set => create_time = value; }
		public string Editorname { get => editorname; set => editorname = value; }
	}
}
