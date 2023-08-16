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
	class FriendShipLinkDaoImpl
	{
		utils.Dbhelp dbhelp = null;
		SqlConnection conn = null;
		SqlCommand cmd = null;
		//增加
		public int InsertFriendShipLink(Models.FriendshipLink linkurl)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "INSERT INTO association.friendshiplink(linkname,linkurl) " +
				"VALUES ('" + linkurl.Linkname + "','" + linkurl.Linkurl + "')";
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
		public int DeleteFriendShipLink(Models.FriendshipLink linkurl)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "delete from association.friendshiplink where id='" + linkurl.Id + "'";
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
		public int UpdateFriendShipLink(Models.FriendshipLink linkurl)
		{
			int flag = 0;
			dbhelp = new utils.Dbhelp();
			string sql = "update association.friendshiplink set linkname='" + linkurl.Linkname + "', linkurl='" + linkurl.Linkurl + "' where id='" + linkurl.Id + "'";
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
		public DataTable QueryFriendShipLink()
		{
			DataTable dt = new DataTable();
			dbhelp = new utils.Dbhelp();
			string sql = "select * from association.friendshiplink";
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
	}
}
