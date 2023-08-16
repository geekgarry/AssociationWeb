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
	class StuMemberDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertStuMember(Models.StuMember stuMember)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.stumember(id, realname,nickname,stuclass,phonenumber,password,collegedepartment,create_time) " +
				"VALUES ('" + stuMember.Id + "','" + stuMember.Realname + "','" + stuMember.Nickname + "','" + stuMember.Stuclass + "','" + stuMember.Phonenumber + "','" + stuMember.Password +
				"','" + stuMember.Collegedepartment + "','" + stuMember.Create_time + "')";
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
		//从申请表中增加社团组织id号
		public int UpdateStuMemberFromApplyJoin(Models.StuMember stuMember)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.stumember set associationids=" +
				"CONCAT('" + stuMember.Associationids + ",'" + ",associationids) where id='" + stuMember.Id+"'";
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
		public int DeleteStuMember(Models.StuMember stuMember)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.stumember where id='" + stuMember.Id + "'";
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
		//修改密码
		public int UpdateStuMemberPwd(Models.StuMember stuMember)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.stumember set password='" + stuMember.Password + "' where id='" + stuMember.Id + "'";
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
		public int UpdateStuMember(Models.StuMember stuMember)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.stumember set realname='" + stuMember.Realname + "', nickname='" + stuMember.Nickname + "', stuclass='" + stuMember.Stuclass + "', phonenumber='" + stuMember.Phonenumber + "', hobbyspeciality='" + stuMember.Hobbyspeciality +
				"', personalintro='" + stuMember.Personalintro + "', collegedepartment='" + stuMember.Collegedepartment + "' where id='" + stuMember.Id + "'";
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
		//修改社团号
		public int UpdateStuMemberAssids(Models.StuMember stuMember)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.stumember set associationids='" + stuMember.Associationids + "' where id='" + stuMember.Id + "'";
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
		public DataTable QueryStuMember(Models.StuMember stuMember)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.stumember where ','+associationids+',' like " + "%,"+"'" + stuMember.Associationids + "'"+",%"+" order by create_time desc";
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
		//登录查询
		public Boolean LoginQueryStuMember(Models.StuMember stuMember)
		{
			Boolean flag = false;
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.stumember where id='" + stuMember.Id + "'and password='"+stuMember.Password+"' order by create_time desc";
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
		//根据ID查询一个
		public string QueryOneStuMember(Models.StuMember stuMember)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();

			string sql = "select * from association.stumember where id='" + stuMember.Id + "' order by create_time desc";
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
				info = dr[0].ToString() + "*" + dr[1].ToString() + "*" + dr[2].ToString() + "*" + dr[3].ToString() + "*" + dr[4].ToString() + "*" + dr[5].ToString() + "*" + dr[6].ToString() + "*" + dr[7].ToString() + "*" + dr[8].ToString() + "*" + dr[9].ToString() + "*" + dr[10].ToString();
			}
			conn.Close();
			return info;
		}
		//根据ID查询社团号字段
		public string QueryOneStuMemberAssIds(Models.StuMember stuMember)
		{
			string info = null;
			dbhelp = new utils.Dbhelp();
			utils.OpJson opJson = new utils.OpJson();
			string sql1 = "select * from association.stumember where id='" + stuMember.Id + "' order by create_time desc";
			conn = dbhelp.GetSqlConnection();
			cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = sql1
			};
			//用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.Read())
			{
				//dr[]里面可以填列名或者索引，显示获得的数据
				//MessageBox.Show(dr[1].ToString());
				info = dr[8].ToString();
			}
			conn.Close();
			return info;
		}
		//分页查询，适用于社团管理员
		public DataTable QueryDividedAss(Models.StuMember stuMember, int pageno, int pagesize)
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			//string sql = "select * from association.campusnew where editorid='" + campusNew.Editorid + "' order by create_time desc";
			string sql = "select top " + pagesize + " * from(select row_number() over(order by cmn.create_time desc) as rownumber, * from (select * from association.stumember where ','+associationids+',' like '%,'+" + "'" + stuMember.Associationids + "'" + "+',%') as cmn) as cn where cn.rownumber > ((" + pageno + " - 1)*" + pagesize + ")";
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
		public int TotalRowAss(Models.StuMember stuMember)
		{
			int rowcount = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "select count(*) from association.stumember where ','+associationids+',' like '%,'+" + "'" + stuMember.Associationids + "'" + "+',%'";
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
		public Models.UniversalPage UniversalPageAss(Models.StuMember stuMember, int pageno, int pagesize)
		{
			Models.UniversalPage page = new Models.UniversalPage();
			utils.OpJson opJson = new utils.OpJson();
			int total = 0; // 总记录数
			int PageCount = 0; // 页码总数
			total = TotalRowAss(stuMember);
			PageCount = total % pagesize == 0 ? total / pagesize : (total / pagesize) + 1;//(total - 1) / pagesize + 1;
			page.Currentpage = pageno;
			page.Onepagesize = pagesize;
			page.Totalsize = total;
			page.Totalpagesize = PageCount;
			page.ArrayListpage = opJson.DbToArrayList(QueryDividedAss(stuMember, pageno, pagesize));
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
