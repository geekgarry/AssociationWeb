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
	class AssociationNoticeDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertAssociationNotice(Models.AssociationInform inform)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.associationnotice(id, noticetitle,noticecontent,associationid,create_time) " +
				"VALUES ('" + inform.Id + "','" + inform.Noticetitle + "','" + inform.Noticecontent + "','" + inform.Associationid + "','" + inform.Create_time + "')";
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
		public int DeleteAssociationNotice(Models.AssociationInform inform)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.associationnotice where id='" + inform.Id + "'";
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
		public int UpdateAssociationNotice(Models.AssociationInform inform)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.associationnotice set noticetitle='" + inform.Noticetitle + "', noticecontent='" + inform.Noticecontent +"'," +
				"create_time='"+inform.Create_time+"' where id='" + inform.Id + "'";
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
		public DataTable QueryAssociationNotice(Models.AssociationInform inform)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select an.id,an.noticetitle,an.noticecontent,an.associationid,ai.associationname,an.create_time from association.associationnotice an inner join association.associationinfo ai on an.associationid=ai.id" +
				" and an.associationid='" + inform.Associationid + "' order by create_time desc";
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
		public DataTable QueryAllAssociationNoticeTop()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 6 an.id,an.noticetitle,an.noticecontent,an.associationid,ai.associationname,an.create_time from association.associationnotice an inner join association.associationinfo ai on an.associationid=ai.id" +
				" order by an.create_time desc";
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
		//侧边查询显示
		public DataTable QueryAllAssociationNoticeTopSlider()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 8 an.id,an.noticetitle,an.noticecontent,an.associationid,ai.associationname,an.create_time from association.associationnotice an inner join association.associationinfo ai on an.associationid=ai.id" +
				" order by an.create_time desc";
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
		public string QueryOneAssociationNotice(Models.AssociationInform inform)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			string sql = "select an.id,an.noticetitle,an.noticecontent,an.associationid,ai.associationname,an.create_time from association.associationnotice an inner join association.associationinfo ai on an.associationid=ai.id" +
				" and an.id='" + inform.Id + "' order by create_time desc";
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
				info = dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString();
			}
			conn.Close();
			return info;
		}
		//分页查询
		public DataTable QueryDivided(int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select an.id,an.noticetitle,an.noticecontent,an.associationid,ai.associationname,an.create_time from association.associationnotice an inner join association.associationinfo ai on an.associationid=ai.id" +
				") as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
			string sql = "select count(*) from association.associationnotice";
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
		public DataTable QueryDividedAss(Models.AssociationInform associationInform, int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select an.id,an.noticetitle,an.noticecontent,an.associationid,ai.associationname,an.create_time from association.associationnotice an inner join association.associationinfo ai on an.associationid=ai.id" +
				" and an.associationid='"+associationInform.Associationid+"') as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		public int TotalRowAss(Models.AssociationInform associationInform)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.associationnotice where associationid='" + associationInform.Associationid + "'";
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
		public Models.UniversalPage UniversalPageAss(Models.AssociationInform associationInform, int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowAss(associationInform);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedAss(associationInform, pageno, pagesize));
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
