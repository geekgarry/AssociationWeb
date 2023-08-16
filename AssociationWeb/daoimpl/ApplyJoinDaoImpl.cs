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
	class ApplyJoinDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertApplyJoin(Models.ApplyJoin applyJoin)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.applyjoin(id,stuid, associationid,hobbyspeciality,applyreason,personalintro,auditstatus,create_time) " +
				"VALUES ('" + applyJoin.Id + "','" + applyJoin.Stuid + "','" + applyJoin.Associationid + "','" + applyJoin.Hobbyspeciality + "'," +
				"'" + applyJoin.Applyreason + "','" + applyJoin.Personalintro + "',0,'" + applyJoin.Create_time + "')";
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
		public int DeleteApplyJoin(Models.ApplyJoin applyJoin)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.applyjoin where id='" + applyJoin.Id + "'";
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
		public int UpdateApplyJoin(Models.ApplyJoin applyJoin)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.applyjoin set associationid='" + applyJoin.Associationid + "', hobbyspeciality='" + applyJoin.Hobbyspeciality + "',applyreason='" + applyJoin.Applyreason + "',personalintro='" + applyJoin.Personalintro +
				"' where id='" + applyJoin.Id + "'";
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
		//修改申请内容
		public int UpdateApplyJoinContent(Models.ApplyJoin applyJoin)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.applyjoin set hobbyspeciality='" + applyJoin.Hobbyspeciality + "',applyreason='" + applyJoin.Applyreason + "',personalintro='" + applyJoin.Personalintro +
				"' where id='" + applyJoin.Id + "'";
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
		//更新申请表状态
		public int UpdateApplyJoinauditstatus(Models.ApplyJoin applyJoin)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.applyjoin set auditstatus='"+applyJoin.Auditstatus+"' where id='" + applyJoin.Id + "'";
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
		public DataTable QueryApplyJoin(Models.ApplyJoin applyJoin)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select aj.id,aj.associationid,aj.hobbyspeciality,aj.applyreason,aj.personalintro,aj.auditstatus,aj.create_time,ai.associationname,sm.realname " +
				"from association.applyjoin aj inner join association.associationinfo ai on aj.associationid=ai.id inner join association.stumember sm on aj.stuid=sm.id" +
				" and aj.associationid='" + applyJoin.Associationid + "' and aj.auditstatus=0 order by aj.create_time desc";
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
		//查询已经通过申请的申请表
		public DataTable QueryApplyJoined(Models.ApplyJoin applyJoin)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select aj.id,aj.associationid,aj.hobbyspeciality,aj.applyreason,aj.personalintro,aj.auditstatus,aj.create_time,ai.associationname,sm.realname " +
				"from association.applyjoin aj inner join association.associationinfo ai on aj.associationid=ai.id inner join association.stumember sm on aj.stuid=sm.id" +
				" and aj.associationid='" + applyJoin.Associationid + "' and aj.auditstatus=1 order by aj.create_time desc";
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
		public string QueryOneApplyJoin(Models.ApplyJoin applyJoin)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();

			string sql = "select aj.id,aj.associationid,aj.hobbyspeciality,aj.applyreason,aj.personalintro,aj.auditstatus,aj.create_time,ai.associationname,sm.realname " +
				"from association.applyjoin aj inner join association.associationinfo ai on aj.associationid=ai.id inner join association.stumember sm on aj.stuid=sm.id" +
				" and aj.id='" + applyJoin.Id + "' order by aj.create_time desc";
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
		public DataTable QueryDividedAss(Models.ApplyJoin applyJoin, int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select aj.id,aj.associationid,aj.hobbyspeciality,aj.applyreason,aj.personalintro,aj.auditstatus,aj.create_time,ai.associationname,sm.realname,aj.stuid " +
				"from association.applyjoin aj inner join association.associationinfo ai on aj.associationid=ai.id inner join association.stumember sm on aj.stuid=sm.id and aj.associationid='" + applyJoin.Associationid + "' and aj.auditstatus='"+applyJoin.Auditstatus+"') as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		public int TotalRowAss(Models.ApplyJoin applyJoin)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.applyjoin where associationid='" + applyJoin.Associationid + "' and auditstatus='"+applyJoin.Auditstatus+"'";
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
		public Models.UniversalPage UniversalPageAss(Models.ApplyJoin applyJoin, int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowAss(applyJoin);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedAss(applyJoin, pageno, pagesize));
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
		public DataTable QueryDividedStu(Models.ApplyJoin applyJoin, int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select aj.id,aj.associationid,aj.hobbyspeciality,aj.applyreason,aj.personalintro,aj.auditstatus,aj.create_time,ai.associationname,sm.realname,aj.stuid " +
				"from association.applyjoin aj inner join association.associationinfo ai on aj.associationid=ai.id inner join association.stumember sm on aj.stuid=sm.id and aj.stuid='" + applyJoin.Stuid + "') as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		public int TotalRowStu(Models.ApplyJoin applyJoin)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.applyjoin where stuid='" + applyJoin.Stuid + "'";
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
		public Models.UniversalPage UniversalPageStu(Models.ApplyJoin applyJoin, int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowStu(applyJoin);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedStu(applyJoin, pageno, pagesize));
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
