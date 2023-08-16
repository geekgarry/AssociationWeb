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
	class AdministratorDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertAdministrator(Models.Administrator administrator)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.administrator(username,password,create_time) " +
				"VALUES ('" + administrator.Username + "','" + administrator.Password + "','" + administrator.Create_time + "')";
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
		public int DeleteAdministrator(Models.Administrator administrator)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.administrator where id='" + administrator.Id + "'";
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
		public int UpdateAdministrator(Models.Administrator administrator)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.administrator set username='" + administrator.Username + "',password='" + administrator.Password + "' where id='" + administrator.Id + "'";
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
		public DataTable QueryAdministrator(Models.Administrator administrator)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.administrator order by create_time desc";
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
		//查询个人信息
		public string QueryPersonalAdministrator(Models.Administrator administrator)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.administrator" +
				" where username='" + administrator.Username + "' order by create_time desc";
			conn = dbhelp.GetSqlConnection();
			/*cmd = new SqlCommand
			{
				Connection = conn,

				CommandType = CommandType.Text,
				CommandText = sql
			};*/
			cmd = conn.CreateCommand();
			cmd.CommandText = sql;
			//用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				//dr[]里面可以填列名或者索引，显示获得的数据
				//MessageBox.Show(dr[1].ToString());
				info = dr[0].ToString()+","+ dr[1].ToString()+ "," + dr[2].ToString()+ "," + dr[3].ToString();
			}
			conn.Close();
			return info;
		}
		//查询个人信息
		public string QueryPersonalAdministratorWithId(Models.Administrator administrator)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			int idd = int.Parse(administrator.Id);
			string sql = "select * from association.administrator" +
				" where id=" + idd + " order by create_time desc";
			conn = dbhelp.GetSqlConnection();
			/*cmd = new SqlCommand
			{
				Connection = conn,

				CommandType = CommandType.Text,
				CommandText = sql
			};*/
			cmd = conn.CreateCommand();
			cmd.CommandText = sql;
			//用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				//dr[]里面可以填列名或者索引，显示获得的数据
				//MessageBox.Show(dr[1].ToString());
				info = dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString();
			}
			conn.Close();
			return info;
		}
		//查询管理员id
		public string QueryPersonalAdministratorId(Models.Administrator administrator)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.administrator" +
				" where username='" + administrator.Username + "' order by create_time desc";
			conn = dbhelp.GetSqlConnection();
			/*cmd = new SqlCommand
			{
				Connection = conn,

				CommandType = CommandType.Text,
				CommandText = sql
			};*/
			cmd = conn.CreateCommand();
			cmd.CommandText = sql;
			//用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				//dr[]里面可以填列名或者索引，显示获得的数据
				//MessageBox.Show(dr[1].ToString());
				info = dr[0].ToString();
			}
			conn.Close();
			return info;
		}
		//登录查询
		public Boolean LoginQueryAdministrator(Models.Administrator admin)
		{
			Boolean flag = false;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.administrator where username='" + admin.Username + "'and password='" + admin.Password + "'";
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
				flag = true;
			}
			conn.Close();
			return flag;
		}
		//分页查询，适用于社团管理员
		public DataTable QueryDivided(int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by ann.create_time desc) as rownumber, * from (select * from association.administrator) as ann) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		public int TotalRow()
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.administrator";
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
		public Models.UniversalPage UniversalPage(Models.ActivityComment activityComment, int pageno, int pagesize)
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
	}
}
