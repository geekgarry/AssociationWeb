using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace AssociationWeb.utils
{
	public class Dbhelp
	{
		private SqlConnection con;
		private SqlCommand cmd;
		//private readonly string SqlCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\myCodehouse\\C#aspCode\\mySite(校园社团)\\2072455311639552\\mySite\\App_Data\\Studentdatabase.mdf;Integrated Security=True;Connect Timeout=30";             //在下面我会介绍这部分怎么填写;
		//private readonly string sqlstr = "Data Source=localhost;Initial Catalog=studentassociation;User ID=sa;Password=147258cjj";
		private readonly static string sqlstr = ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;
		public Dbhelp()
		{
			con = new SqlConnection(@sqlstr);
			con.Open();
		}
		public SqlConnection GetSqlConnection()
		{
			return con;
		}
		public DataTable ExecuteQuery(string sqlStr)      //用于查询；其实是相当于提供一个可以传参的函数，到时候写一个sql语句，存在string里，传给这个函数，就会自动执行。
		{
			SqlConnection con = new SqlConnection(@sqlstr);
			con.Open();
			//SqlCommand cmd = new SqlCommand();
			//cmd.Connection = con;
			//cmd.CommandType = CommandType.Text;
			//cmd.CommandText = sqlStr;
			SqlCommand cmd = new SqlCommand
			{
				Connection = con,
				CommandType = CommandType.Text,
				CommandText = sqlStr
			};
			DataTable dt = new DataTable();
			SqlDataAdapter msda;
			msda = new SqlDataAdapter(cmd);
			msda.Fill(dt);
			con.Close();
			return dt;
		}
		public int ExecuteUpdate(string sqlStr)      //用于增删改;
		{
			SqlConnection con = new SqlConnection(@sqlstr);
			con.Open();
			// cmd = new SqlCommand();
			//cmd.Connection = con;
			//cmd.CommandType = CommandType.Text;
			//cmd.CommandText = sqlStr;
			SqlCommand cmd = new SqlCommand
			{
				Connection = con,
				CommandType = CommandType.Text,
				CommandText = sqlStr
			};
			int iud = 0;
			iud = cmd.ExecuteNonQuery();
			con.Close();
			return iud;
		}
		public SqlCommand GetSqlCommand(SqlConnection con, string sql)
		{
			cmd = new SqlCommand
			{
				Connection = con,
				CommandType = CommandType.Text,
				CommandText = sql
			};
			return cmd;
		}
		public void Close(SqlConnection con)
		{
			con.Close();
		}
	}
}
