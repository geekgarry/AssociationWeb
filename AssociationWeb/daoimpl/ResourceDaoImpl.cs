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
	class ResourceDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertResource(Models.Resources resources)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.resources(id, dtitle,dcontent,dtype,dfileposition,upid,upidname,create_time) " +
				"VALUES ('" + resources.Id + "','" + resources.Dtitle + "','" + resources.Dcontent + "','" + resources.Dtype + "','" + resources.Dfileposition + "','" + resources.Upid + "','" + resources.Upidname + "','" + resources.Create_time + "')";
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
		public int DeleteResource(Models.Resources resources)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.resources where id='" + resources.Id + "'";
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
		public int UpdateResource(Models.Resources resources)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.resources set dtitle='" + resources.Dtitle + "', dcontent='" + resources.Dcontent + "', dtype='" + resources.Dtype +
				"' where id='" + resources.Id + "'";
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
		public DataTable QueryResource(Models.Resources resources)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.resources where upid='"+resources.Upid+"' order by create_time desc";
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
		public DataTable QueryResource()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.resources order by create_time desc";
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
		public DataTable QueryResourceTop()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 5 * from association.resources order by create_time desc";
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
		public string QueryOneResource(Models.Resources resources)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.resources where id='" + resources.Id + "' order by create_time desc";
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
				info = dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString() + "," + dr[7].ToString();
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
			string sql = "select top " + pagesize + " * from(select row_number() over(order by res.create_time desc) as rownumber, * from(select * from association.resources) as res) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		//分页查询,社团管理员
		public DataTable QueryDividedAss(Models.Resources resource,int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by res.create_time desc) as rownumber, * from(select * from association.resources where upid='"+ resource.Upid+ "') as res) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
			string sql = "select count(*) from association.resources";
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
		//社团管理员
		public int TotalRowAss(Models.Resources resource)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.resources where upid='"+resource.Upid+"'";
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
		//社团管理员分页查询
		public Models.UniversalPage UniversalPageAss(Models.Resources resource,int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowAss(resource);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedAss(resource,pageno, pagesize));
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
