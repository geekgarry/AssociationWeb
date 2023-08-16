using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace AssociationWeb.utils
{
	public class OpJson
	{
		//把DataTable转化为数据json
		public string DbToJson(DataTable dtb)
		{
			JavaScriptSerializer jss = new JavaScriptSerializer();
			ArrayList dic = new ArrayList();
			foreach (DataRow row in dtb.Rows)
			{
				Dictionary<string, object> drow = new Dictionary<string, object>();
				foreach (DataColumn col in dtb.Columns)
				{
					drow.Add(col.ColumnName, row[col.ColumnName]);
				}
				dic.Add(drow);
			}
			return jss.Serialize(dic);
		}
		//把DataTable转化为ArrayList
		//把DataTable转化为数据json
		public ArrayList DbToArrayList(DataTable dtb)
		{
			//ArrayList arrayList = new ArrayList();
			ArrayList dic = new ArrayList();
			foreach (DataRow row in dtb.Rows)
			{
				Dictionary<string, object> drow = new Dictionary<string, object>();
				foreach (DataColumn col in dtb.Columns)
				{
					drow.Add(col.ColumnName, row[col.ColumnName]);
				}
				dic.Add(drow);
			}
			return dic;
		}
		//把UniversalPage转化为json
		public string PageToJson(Models.UniversalPage page)
		{
			JavaScriptSerializer jss = new JavaScriptSerializer();
			ArrayList arrayListpage = new ArrayList();
			arrayListpage.Add(page.ArrayListpage);
			arrayListpage.Add(page.Currentpage);
			arrayListpage.Add(page.Hasnext);
			arrayListpage.Add(page.Hasprevious);
			arrayListpage.Add(page.Onepagesize);
			arrayListpage.Add(page.Totalpagesize);
			arrayListpage.Add(page.Totalsize);
			return jss.Serialize(arrayListpage);
		}
		//把ArrayList转化为json
		public string ArrayListToJson(ArrayList arrayList)
		{
			JavaScriptSerializer jss = new JavaScriptSerializer();
			return jss.Serialize(arrayList);
		}
		public String StringArray2Strin(String str)
		{
			String[] strs = str.Split(',');
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < strs.Length; i++)
			{
				sb.Append("'").Append(str[i]).Append("'").Append(",");
			}
			return sb.ToString().Substring(0, sb.Length - 1);
		}
	}
}