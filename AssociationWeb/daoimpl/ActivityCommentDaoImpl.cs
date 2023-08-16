using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace AssociationWeb.Controllers.daoimpl
{
	class ActivityCommentDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertActivityComment(Models.ActivityComment activityComment)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.activitycomment(id, stuid, activitycomment,associationactivityid,create_time) " +
				"VALUES ('" + activityComment.Id + "','" + activityComment.Stuid + "','" + activityComment.Activitycomment + "','" + activityComment.Associationactivityid + "'," +
				"'" + activityComment.Create_time + "')";
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
		public int DeleteActivityComment(Models.ActivityComment activityComment)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.activitycomment where id='" + activityComment.Id + "'";
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
		public int UpdateActivityComment(Models.ActivityComment activityComment)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.activitycomment set activitycomment='" + activityComment.Activitycomment + "' where id='" + activityComment.Id + "'";
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
		public DataTable QueryActivityComment(Models.ActivityComment activityComment)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.activitycomment" +
				"where id='" + activityComment.Id + "' order by create_time desc";
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
		//查询我的评论
		public DataTable QueryMyActivityComment(Models.ActivityComment activityComment)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select ac.id,ac.stuid,sm.realname,sm.nickname,sm.stuclass,ac.activitycomment,ac.associationactivityid,aa.activitytitle,ac.create_time from association.activitycomment ac inner join" +
				" association.stumember sm on ac.stuid=sm.id and ac.stuid='" + activityComment.Stuid + "' inner join association.associationactivity aa on aa.id=ac.associationactivityid order by ac.create_time desc";
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
		//查询相关评论
		public DataTable QueryAboutActivityComment(Models.ActivityComment activityComment)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select ac.id,ac.stuid,sm.realname,sm.nickname,sm.stuclass,ac.activitycomment,ac.associationactivityid,ac.create_time from association.activitycomment ac inner join" +
				" association.stumember sm on ac.stuid=sm.id and ac.associationactivityid='" + activityComment.Associationactivityid + "' order by ac.create_time desc";
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
		//查询相关评论
		public DataTable QueryAboutActivityCommentTop(Models.ActivityComment activityComment)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			String acid = activityComment.Associationactivityid;
			string sql = "select ac.id,ac.stuid,sm.realname,sm.stuclass,ac.activitycomment,ac.associationactivityid,ac.create_time from association.activitycomment ac inner join association.stumember sm on ac.stuid=sm.id and ac.associationactivityid='"+ activityComment.Associationactivityid + "' order by ac.create_time desc";
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
		//首页最新评论
		public DataTable QueryAllActivityCommentTop()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 6 ac.id,ac.stuid,sm.realname,sm.stuclass,ac.activitycomment,ac.associationactivityid,aa.activitytitle,ac.create_time from association.activitycomment ac inner join" +
				" association.stumember sm on ac.stuid=sm.id inner join association.associationactivity aa on ac.associationactivityid=aa.id order by ac.create_time desc";
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
		public string QueryOneActivityComment(Models.ActivityComment activityComment)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();

			string sql = "select ac.id,ac.stuid,sm.realname,sm.nickname,sm.stuclass,ac.activitycomment,ac.associationactivityid,ac.create_time,aa.activitytitle from association.activitycomment ac inner join" +
				" association.stumember sm on ac.stuid=sm.id and ac.id='" + activityComment.Id + "' inner join association.associationactivity aa on ac.associationactivityid=aa.id order by ac.create_time desc";
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
				info = dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString() + "," + dr[7].ToString() + "," + dr[8].ToString();
			}
			conn.Close();
			return info;
		}
		//分页查询，适用于社团管理员
		public DataTable QueryDividedAss(Models.ActivityComment activityComment, int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select ac.id,ac.stuid,sm.realname,sm.stuclass,ac.activitycomment,ac.associationactivityid,ac.create_time,aa.activitytitle from association.activitycomment ac inner join association.stumember sm on ac.stuid=sm.id and ac.associationactivityid='" + 
				activityComment.Associationactivityid + "' inner join association.associationactivity aa on ac.associationactivityid=aa.id) as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		public int TotalRowAss(Models.ActivityComment activityComment)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.activitycomment where associationactivityid='" + activityComment.Associationactivityid + "'";
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
		public Models.UniversalPage UniversalPageAss(Models.ActivityComment activityComment, int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowAss(activityComment);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedAss(activityComment, pageno, pagesize));
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
		//分页查询
		public DataTable QueryDivided(int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select ac.id,ac.stuid,sm.realname,sm.nickname,sm.stuclass,ac.activitycomment,ac.associationactivityid,ac.create_time,aa.activitytitle from association.activitycomment ac inner join" +
				" association.stumember sm on ac.stuid=sm.id inner join association.associationactivity aa on ac.associationactivityid=aa.id) as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		//适用于系统管理员
		public int TotalRow()
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.activitycomment";
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
		//适用于系统管理员
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
		//分页查询
		public DataTable QueryDividedStu(Models.ActivityComment activityComment,int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select ac.id,ac.stuid,sm.realname,sm.stuclass,ac.activitycomment,ac.associationactivityid,ac.create_time,aa.activitytitle from association.activitycomment ac inner join association.stumember sm on ac.stuid=sm.id and ac.stuid='"
				+ activityComment.Stuid+ "' inner join association.associationactivity aa on ac.associationactivityid=aa.id) as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		//适用于系统管理员
		public int TotalRowStu(Models.ActivityComment activityComment)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.activitycomment where stuid='"+activityComment.Stuid+"'";
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
		//适用于系统管理员
		public Models.UniversalPage UniversalPageStu(Models.ActivityComment activityComment,int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowStu(activityComment);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedStu(activityComment,pageno, pagesize));
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
