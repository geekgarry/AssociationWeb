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
	class AssociationInfoDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertAssociationInfo(Models.AssociationInfo associationInfo)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.associationinfo(username, password,associationname,associationintro,teacherincharge,stuincharge,create_time) " +
				"VALUES ('" + associationInfo.Username + "',123456,'" + associationInfo.Associationname + "'," +
				"'" + associationInfo.Associationintro + "','" + associationInfo.Teacherincharge + "','" + associationInfo.Stuincharge + "','" + associationInfo.Create_time + "')";
			conn=dbhelp.GetSqlConnection();
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
		//增加2
		public int InsertAssociationInfowithpwd(Models.AssociationInfo associationInfo)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.associationinfo(username, password,associationname,associationintro,teacherincharge,stuincharge,create_time) " +
				"VALUES ('" + associationInfo.Username + "','"+ associationInfo .Password+ "','" + associationInfo.Associationname + "'," +
				"'" + associationInfo.Associationintro + "','" + associationInfo.Teacherincharge + "','" + associationInfo.Stuincharge + "','" + associationInfo.Create_time + "')";
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
		public int DeleteAssociationInfo(Models.AssociationInfo associationInfo)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.associationinfo where id='" + associationInfo.Id + "'";
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
		public int UpdateAssociationInfo(Models.AssociationInfo associationInfo)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.associationinfo set username='" + associationInfo.Username + "', password='" + associationInfo.Password + "',associationname='" + associationInfo.Associationname + "'" +
				",associationintro='" + associationInfo.Associationintro + "',teacherincharge='" + associationInfo.Teacherincharge + "',stuincharge='" + associationInfo.Stuincharge + "'" +
				" where id='" + associationInfo.Id + "'";
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
		public DataTable QueryAssociationInfo(Models.AssociationInfo associationInfo)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select username,associationname,associationintro,teacherincharge,stuincharge,create_time from association.associationinfo" +
				" where id='" + associationInfo.Id + "' order by create_time desc";
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
		//特殊查询，查询学生所加入的社团
		public DataTable QueryAssociationInfoByStu(Models.StuMember stuMember)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			utils.OpJson opJson = new utils.OpJson();
			StuMemberDaoImpl stuMemberdaoImpl = new StuMemberDaoImpl();
			String info = stuMemberdaoImpl.QueryOneStuMemberAssIds(stuMember);
			string sqlhanshu = "create Function StrToTable(@str varchar(1000)) " +
				"Returns @tableName Table(str2table varchar(50))As" +
				"–该函数用于把一个用逗号分隔的多个数据字符串变成一个表的一列，例如字符串’1,2,3,4,5’ 将编程一个表，这个表" +
				"Begin set @str = @str +’,’ Declare @insertStr varchar(50) –截取后的第一个字符串" +
				"Declare @newstr varchar(1000) –截取第一个字符串后剩余的字符串" +
				 "set @insertStr = left(@str, charindex(‘,’, @str) - 1)" +
				 "set @newstr = stuff(@str, 1, charindex(‘,’, @str),”)" +
				 "Insert @tableName Values(@insertStr)" +
				 "while (len(@newstr) > 0)" +
				 "begin" +
				 "set @insertStr = left(@newstr, charindex(‘,’, @newstr) - 1)" +
				 "Insert @tableName Values(@insertStr)" +
				 "set @newstr = stuff(@newstr, 1, charindex(‘,’, @newstr),”)" +
				 "end" +
				 "Return" +
				 "End";
			string sql = "select id,username,associationname,associationintro,teacherincharge,stuincharge,create_time from association.associationinfo" +
					" where id in ("+ info + ") order by create_time desc";
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
		public DataTable QueryAllAssociationInfo()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select id,username,associationname,associationintro,teacherincharge,stuincharge,create_time from association.associationinfo order by create_time desc";
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
		public DataTable QueryAllAssociationInfoTop()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select top 5 id,username,associationname,associationintro,teacherincharge,stuincharge,create_time from association.associationinfo order by create_time desc";
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
		public string QueryMyAssociationInfo(Models.AssociationInfo associationInfo)
		{
			string myinfo=null;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.associationinfo where username='"+associationInfo.Username+"' order by create_time desc";
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
				myinfo = dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + 
					dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString();
			}
			conn.Close();
			return myinfo;
		}
		//查询
		public string QueryMyAssociationInfoId(Models.AssociationInfo associationInfo)
		{
			string myinfo = null;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.associationinfo where username='" + associationInfo.Username + "' order by create_time desc";
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
				myinfo = dr[0].ToString()+","+ dr[3].ToString();
			}
			conn.Close();
			return myinfo;
		}
		//根据ID查询一个
		public string QueryOneAssociationInfo(Models.AssociationInfo associationInfo)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.associationinfo where id='" + associationInfo.Id + "' order by create_time desc";
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
		//登录查询
		public Boolean LoginQueryAssociation(Models.AssociationInfo associationInfo)
		{
			Boolean flag = false;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.associationinfo where username='" + associationInfo.Username + "' and password='" + associationInfo.Password + "'";
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
		//分页查询
		public DataTable QueryDivided(int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by aii.create_time desc) as rownumber, * from(select id,username,associationname,associationintro,teacherincharge,stuincharge,create_time from association.associationinfo) as aii) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
			string sql = "select count(*) from association.associationinfo";
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
	}
}
