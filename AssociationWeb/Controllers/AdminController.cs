using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AssociationWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult AdminLogin()
		{
			return View();
		}
		public ActionResult AssAdminLogin()
		{
			return View();
		}
		public ActionResult AssAdminRegister()
		{
			return View();
		}
		public ActionResult AssAdminMain()
		{
			return AssAdminMainIndex();
		}
		public ActionResult MyAdminInfo(string id)
		{
			daoimpl.AdministratorDaoImpl administratorDaoImpl = new daoimpl.AdministratorDaoImpl();
			Models.Administrator administrator = new Models.Administrator();
			administrator.Id = id;
			string admin = administratorDaoImpl.QueryPersonalAdministratorWithId(administrator);
			string[] admininfo = admin.Split(',');
			ViewData["id"]= admininfo[0];
			ViewData["username"] = admininfo[1];
			ViewData["password"] = admininfo[2];
			ViewData["ctime"] = admininfo[3];
			return View();
		}
		public ActionResult AdminMain()
		{
			return AdminMainIndex();
		}
		public ActionResult AdminMainIndex()
		{
			ViewBag.AdminWelcomeMessage = "欢迎来到社团组织管理系统，本系统可以更好地管理社团和组织！\n" +
				"这里是系统管理员端系统";
			return View();
		}
		public ActionResult AssAdminMainIndex()
		{
			ViewBag.AdminWelcomeMessage = "欢迎来到社团组织管理系统，本系统可以更好地管理社团和组织！\n" +
				"这里是社团管理员端系统\n" + "今天是：" + DateTime.Today.ToLocalTime().ToString();
			return View();
		}
		public ActionResult AllAdministrator()
		{
			daoimpl.AdministratorDaoImpl administratorDaoImpl = new daoimpl.AdministratorDaoImpl();
			Models.Administrator admin = new Models.Administrator();
			DataTable dtb = administratorDaoImpl.QueryAdministrator(admin);
			JavaScriptSerializer jss = new JavaScriptSerializer();
			ArrayList dic = new ArrayList();
			foreach (DataRow row in dtb.Rows)
			{
				Dictionary<string, object> drow = new Dictionary<string, object>();
				foreach (DataColumn col in dtb.Columns)
				{
					drow.Add(col.ColumnName, row[col.ColumnName]);
					if (col.ColumnName.Equals("create_time"))
					{
						drow.Remove(col.ColumnName);
						String timestamp= string.Format("yyyy-MM-dd HH:mm:ss", row[col.ColumnName]);
						drow.Add(col.ColumnName, row[col.ColumnName]);
					}
				}
				dic.Add(drow);
			}
			ViewData["alladmin"] = jss.Serialize(dic);
			return View();
		}
		[HttpPost]
		public ActionResult AdminLogin(FormCollection form)
		{
			string username = form["userid"];
			string password = form["password"];
			daoimpl.AdministratorDaoImpl administratorDaoImpl = new daoimpl.AdministratorDaoImpl();
			Models.Administrator administrator = new Models.Administrator();
			administrator.Username = username;
			administrator.Password = password;
			if (username.Equals("") || password.Equals(""))
			{
				ViewBag.LoginStatus = "用户名和密码不能为空！";
			}else if (administratorDaoImpl.LoginQueryAdministrator(administrator) == true)
			{
				string adminid = administratorDaoImpl.QueryPersonalAdministratorId(administrator);
				Session.Add("adminid", username);
				Session.Add("id",adminid);
				Response.Redirect("~/Admin/AdminMain/");
			}
			else
			{
				ViewBag.LoginStatus = "用户名或密码错误！";
			}
			return View();
		}
		[HttpPost]
		public ActionResult AssAdminLogin(FormCollection form)
		{
			string username = form["userid"];
			string password = form["password"];
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			associationInfo.Username = username;
			associationInfo.Password = password;
			if (username.Equals("") || password.Equals(""))
			{
				ViewBag.LoginStatus = "用户名和密码不能为空！";
			}
			else if (associationInfoDaoImpl.LoginQueryAssociation(associationInfo) == true)
			{
				string assid = associationInfoDaoImpl.QueryMyAssociationInfoId(associationInfo);
				string[] assinfos = assid.Split(',');
				Session.Add("assadminid", username);
				Session.Add("assid", assinfos[0]);
				Session.Add("assname", assinfos[1]);
				Response.Redirect("~/Admin/AssAdminMain");
			}
			else
			{
				ViewBag.LoginStatus = "用户名或密码错误！";
			}
			return View();
		}
		[HttpPost]
		public ActionResult AssAdminRegister(FormCollection form)
		{
			string username = form["userid"];
			string password = form["password"];
			string assname = form["assname"];
			string assintro = form["assintro"];
			string assteacher = form["assteacher"];
			string assstudent = form["assstudent"];
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			associationInfo.Username = username;
			associationInfo.Password = password;
			associationInfo.Associationname = assname;
			associationInfo.Associationintro = assintro;
			associationInfo.Teacherincharge = assteacher;
			associationInfo.Stuincharge = assstudent;
			associationInfo.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (username.Equals("") || password.Equals("") || assname.Equals("") || assintro.Equals("") || assteacher.Equals("") || assstudent.Equals(""))
			{
				ViewBag.LoginStatus = "输入不能为空！";
			}
			else if (associationInfoDaoImpl.InsertAssociationInfowithpwd(associationInfo) >0)
			{
				//Session.Add("userid", username);
				//Response.Redirect("~/Admin/AssAdminLogin");
				return this.Content("<script>alert('注册完成！等待系统管理员反馈！请登录查看！');window.location.href='AssAdminLogin';</script>");
			}
			else
			{
				ViewBag.Register = "注册失败！";
			}
			return View();
		}
		public ActionResult RealDelete(String id)
		{
			daoimpl.AdministratorDaoImpl administratorDaoImpl = new daoimpl.AdministratorDaoImpl();
			Models.Administrator administrator = new Models.Administrator();
			administrator.Id = id;
			if (administratorDaoImpl.DeleteAdministrator(administrator) >0)
			{
				ViewBag.delete = "已删除！";
			}
			else
			{
				ViewBag.delete = "删除失败！";
			}
			return RedirectToAction("AllAdministrator");
		}
		public ActionResult UpdateAdminInfo(FormCollection form)
		{
			daoimpl.AdministratorDaoImpl administratorDaoImpl = new daoimpl.AdministratorDaoImpl();
			Models.Administrator administrator = new Models.Administrator();
			string msg = null;
			administrator.Id = form["uid"];
			administrator.Username = form["username"];
			administrator.Password = form["newpassword"];
			if(form["newpassword"] ==""|| form["newpasswordagain"] =="")
			{
				msg = "不能为空！";
			}else if(form["newpassword"] != form["newpasswordagain"])
			{
				msg = "前后密码不一致！";
			}else
			//administrator.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (administratorDaoImpl.UpdateAdministrator(administrator) > 0)
			{
				msg = "已更新！";
			}
			else
			{
				msg = "更新失败！";
			}
			return Content(msg);
		}
		public ActionResult UpdateAdminInfoByAdmin(FormCollection form)
		{
			daoimpl.AdministratorDaoImpl administratorDaoImpl = new daoimpl.AdministratorDaoImpl();
			Models.Administrator administrator = new Models.Administrator();
			string msg = null;
			administrator.Id = form["uid"];
			administrator.Username = form["username"];
			administrator.Password = form["password"];
			if (form["username"] == "" || form["password"] == "")
			{
				msg = "不能为空！";
			}
			else
			//administrator.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (administratorDaoImpl.UpdateAdministrator(administrator) > 0)
			{
				msg = "已更新！";
			}
			else
			{
				msg = "更新失败！";
			}
			return Content(msg);
		}
		public ActionResult LogoutAdmin()
		{
			if (Session["adminid"] == null)
			{
				Response.Redirect("/Admin/AdminLogin");
			}
			Session.Remove("adminid");//这个方法仅仅是移除了attribute属性值
			Session.Clear();//这个方法是连同session和attribute一同移除
			Response.Redirect("/Admin/AdminLogin");
			return View();
		}
		public ActionResult LogoutAssAdmin()
		{
			if (Session["assadminid"] == null)
			{
				Response.Redirect("/Admin/AssAdminLogin");
			}
			Session.Remove("assadminid");//这个方法仅仅是移除了attribute属性值
			Session.Clear();//这个方法是连同session和attribute一同移除
			Response.Redirect("/Admin/AssAdminLogin");
			return View();
		}
		public ActionResult AddAdminInfo(FormCollection form)
		{
			string msg = "";
			daoimpl.AdministratorDaoImpl administratorDaoImpl = new daoimpl.AdministratorDaoImpl();
			Models.Administrator administrator = new Models.Administrator();
			administrator.Username = form["username"];
			administrator.Password= form["password"];
			administrator.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (administratorDaoImpl.InsertAdministrator(administrator) > 0)
			{
				msg = "添加成功！";
			}
			else
			{
				msg = "添加失败！";
			}
			return Content(msg);
		}
	}
}