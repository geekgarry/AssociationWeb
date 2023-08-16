using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AssociationWeb.Models
{
	public class UniversalPage
	{
		//public DataTable Dtb { get; set; }//第一种get，set方法写法
		private DataTable dtb;
		private int currentpage;
		private int totalpagesize;
		private int onepagesize;
		private int totalsize;
		private int hasprevious;
		private int hasnext;
		private ArrayList arrayListpage = new ArrayList();

		public DataTable Dtb { get => dtb; set => dtb = value; }
		public int Currentpage { get => currentpage; set => currentpage = value; }
		public int Totalpagesize { get => totalpagesize; set => totalpagesize = value; }
		public int Onepagesize { get => onepagesize; set => onepagesize = value; }
		public int Totalsize { get => totalsize; set => totalsize = value; }
		public int Hasprevious { get => hasprevious; set => hasprevious = value; }
		public int Hasnext { get => hasnext; set => hasnext = value; }
		public ArrayList ArrayListpage { get => arrayListpage; set => arrayListpage = value; }
	}
}