using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace AssociationWeb.Controllers.daoimpl
{
	class AssociationActivityDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertAssociationActivity(Models.Associationactivity activity)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.associationactivity(id, personalincharge,activitytitle,activitycontent,associationid,create_time) " +
				"VALUES ('" + activity.Id + "','" + activity.Personalincharge + "','" + activity.Activitytitle + "','" + activity.Activitycontent + "'," +
				"'" + activity.Associationid + "','" + activity.Create_time + "')";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			flag = cmd.ExecuteNonQuery();
			conn.Close();
			return flag;
		}
		//删除
		public int DeleteAssociationActivity(Models.Associationactivity activity)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.associationactivity where id='" + activity.Id + "'";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			flag = cmd.ExecuteNonQuery();
			conn.Close();
			return flag;
		}
		//修改
		public int UpdateAssociationActivity(Models.Associationactivity activity)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.associationactivity set personalincharge='" + activity.Personalincharge + "', activitytitle='" + activity.Activitytitle + "',activitycontent='" + activity.Activitycontent +
				"',create_time='"+activity.Create_time+"' where id='" + activity.Id + "'";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			flag = cmd.ExecuteNonQuery();
			conn.Close();
			return flag;
		}
		//查询
		public DataTable QueryAssociationActivity(Models.Associationactivity activity)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select aa.id,aa.personalincharge,aa.activitytitle,aa.activitycontent,aa.associationid,ai.associationname,aa.create_time " +
				"from association.associationactivity aa inner join association.associationinfo ai on aa.associationid=ai.id" +
				" and aa.associationid='" + activity.Associationid + "' order by aa.create_time desc";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			conn.Close();
			return dt;
		}
		//根据ID查询一个
		public string QueryOneAssociationActivity(Models.Associationactivity activity)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			string sql = "select aa.id,aa.personalincharge,aa.activitytitle,aa.activitycontent,aa.associationid,ai.associationname,aa.create_time " +
				"from association.associationactivity aa inner join association.associationinfo ai on aa.associationid=ai.id" +
				" and aa.id='" + activity.Id + "' order by aa.create_time desc";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			//用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				//dr[]里面可以填列名或者索引，显示获得的数据
				//MessageBox.Show(dr[1].ToString());
				info = dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString();
			}
			conn.Close();
			return info;
		}
		//查询
		public DataTable QueryAssociationActivityTop(Models.Associationactivity activity)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 6 aa.id,aa.personalincharge,aa.activitytitle,aa.activitycontent,aa.associationid,ai.associationname,aa.create_time " +
				"from association.associationactivity aa inner join association.associationinfo ai on aa.associationid=ai.id" +
				" and aa.associationid='" + activity.Associationid + "' order by aa.create_time desc";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			conn.Close();
			return dt;
		}
		//查询
		public DataTable QueryAssociationActivityTop()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 6 aa.id,aa.personalincharge,aa.activitytitle,aa.activitycontent,aa.associationid,ai.associationname,aa.create_time " +
				"from association.associationactivity aa inner join association.associationinfo ai on aa.associationid=ai.id" +
				" order by aa.create_time desc";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			conn.Close();
			return dt;
		}
		//查询所有
		public DataTable QueryAllAssociationActivity()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.associationactivity order by create_time desc";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			conn.Close();
			return dt;
		}
		//查询所有
		public DataTable QueryAllAssociationActivityTop()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 6 * from association.associationactivity order by create_time desc";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			conn.Close();
			return dt;
		}
		//分页查询
		public DataTable QueryDivided( int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by acc.create_time desc) as rownumber, * from (select aa.id,aa.personalincharge,aa.activitytitle,aa.activitycontent,aa.associationid,ai.associationname,aa.create_time " +
				"from association.associationactivity aa inner join association.associationinfo ai on aa.associationid=ai.id) as acc) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			conn.Close();
			return dt;
		}
		public int TotalRow()
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.associationactivity";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			//用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				//dr[]里面可以填列名或者索引，显示获得的数据
				//MessageBox.Show(dr[1].ToString());
				rowcount = (int)dr[0];
			}
			conn.Close();
			return rowcount;
		}
		public Models.UniversalPage UniversalPage(int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRow();
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDivided(pageno, pagesize));
			if (pageno == 1)
			{
				page.Hasprevious = 1;
			}
			else
			{
				page.Hasprevious = pageno - 1;
			}
			if (pageno == PageCount)
			{
				page.Hasnext = PageCount;
			}
			else
			{
				page.Hasnext = pageno + 1;
			}
			return page;
		}
		//分页查询，适用于社团管理员
		public DataTable QueryDividedAss(Models.Associationactivity associationactivity, int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select aa.id,aa.personalincharge,aa.activitytitle,aa.activitycontent,aa.associationid,ai.associationname,aa.create_time " +
				"from association.associationactivity aa inner join association.associationinfo ai on aa.associationid=ai.id and aa.associationid='" + associationactivity.Associationid + "') as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			conn.Close();
			return dt;
		}
		//适用于社团
		public int TotalRowAss(Models.Associationactivity associationactivity)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.associationactivity where associationid='" + associationactivity.Associationid + "'";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			//用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				//dr[]里面可以填列名或者索引，显示获得的数据
				//MessageBox.Show(dr[1].ToString());
				rowcount = (int)dr[0];
			}
			conn.Close();
			return rowcount;
		}
		//适用于社团管理员
		public Models.UniversalPage UniversalPageAss(Models.Associationactivity associationactivity, int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowAss(associationactivity);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedAss(associationactivity, pageno, pagesize));
			if (pageno == 1)
			{
				page.Hasprevious = 1;
			}
			else
			{
				page.Hasprevious = pageno - 1;
			}
			if (pageno == PageCount)
			{
				page.Hasnext = PageCount;
			}
			else
			{
				page.Hasnext = pageno + 1;
			}
			return page;
		}
	}
}
