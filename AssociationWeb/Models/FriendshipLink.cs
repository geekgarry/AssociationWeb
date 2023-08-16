using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	class FriendshipLink
	{
		private string id;
		private string linkname;
		private string linkurl;

		//public string Id{ get {return id;} set {id=value;} }
		public string Id { get => id; set => id = value; }
		public string Linkname { get => linkname; set => linkname = value; }
		public string Linkurl { get => linkurl; set => linkurl = value; }
	}
}
