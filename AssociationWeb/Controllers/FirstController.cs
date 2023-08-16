using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.Script.Serialization;
using System.Collections;

namespace AssociationWeb.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult StuLogin()
		{
			//ViewBag.LoginState = "登录前。。。。";
			return View();
		}
		public ActionResult StuRegister()
		{
			return View();
		}
		public ActionResult AssMain()
		{
			daoimpl.FriendShipLinkDaoImpl shipLinkDaoImpl = new daoimpl.FriendShipLinkDaoImpl();
			daoimpl.AssociationActivityDaoImpl associationActivityDaoImpl = new daoimpl.AssociationActivityDaoImpl();
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			utils.OpJson dtbtojson = new utils.OpJson();
			DataTable dtb = shipLinkDaoImpl.QueryFriendShipLink();
			DataTable assdtb = associationInfoDaoImpl.QueryAllAssociationInfoTop();
			DataTable assacdtb = associationActivityDaoImpl.QueryAssociationActivityTop();
			DataTable newsdtb = campusNewDaoImpl.QueryCampusNewTop();
			DataTable noticedtb = associationNoticeDaoImpl.QueryAllAssociationNoticeTop();
			DataTable resourcedtb = resourceDaoImpl.QueryResourceTop();
			DataTable apprisedtb = appriseDaoImpl.QueryAppriseTop();
			DataTable commentdtb = activityCommentDaoImpl.QueryAllActivityCommentTop();
			JavaScriptSerializer jss = new JavaScriptSerializer();
			ArrayList dic = new ArrayList();
			foreach (DataRow row in dtb.Rows)
			{
				Dictionary<string, object> drow = new Dictionary<string, object>();
				foreach (DataColumn col in dtb.Columns)
				{
					drow.Add(col.ColumnName, row[col.ColumnName]);
				}
				dic.Add(drow);
			}
			ViewData["assinfo"]= dtbtojson.DbToJson(assdtb);
			ViewData["assac"] = dtbtojson.DbToJson(assacdtb);
			ViewData["news"] = dtbtojson.DbToJson(newsdtb);
			ViewData["notice"] = dtbtojson.DbToJson(noticedtb);
			ViewData["resource"] = dtbtojson.DbToJson(resourcedtb);
			ViewData["apprise"] = dtbtojson.DbToJson(apprisedtb);
			ViewData["commentdtb"] = dtbtojson.DbToJson(commentdtb);
			ViewData["fdshiplink"]=jss.Serialize(dic);
			return View();
		}
		[HttpPost]
		public ActionResult StuLogin(FormCollection form)
		{
			string username = form["username"];
			string password = form["password"];
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Id = username;
			stuMember.Password = password;
			if (username.Equals("") || password.Equals(""))
			{
				ViewBag.LoginState = "用户名和密码不能为空！";
			}
			else if (stuMemberDaoImpl.LoginQueryStuMember(stuMember)==true)
			{
				Session.Add("userid",username);
				//Session["UserName"] = username;
				Response.Redirect("~/First/AssMain");
			}
			else
			{
				ViewBag.LoginState = "用户名或密码错误！";
			}
			return View();
		}
		[HttpPost]
		public ActionResult StuRegister(FormCollection form)
		{
			string username = form["userid"];
			string realname = form["realname"];
			string stuclass = form["stuclass"];
			string college = form["college"];
			string phonenumber = form["phonenumber"];
			string password = form["password"];
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Id = username;
			stuMember.Realname = realname;
			stuMember.Stuclass = stuclass;
			stuMember.Collegedepartment = college;
			stuMember.Phonenumber = phonenumber;
			stuMember.Password = password;
			stuMember.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (username.Equals("") || realname.Equals("") || stuclass.Equals("") || college.Equals("") || phonenumber.Equals("") || password.Equals(""))
			{
				ViewBag.LoginState = "输入不能为空！";
			}
			else if (stuMemberDaoImpl.InsertStuMember(stuMember)>0)
			{
				//Session.Add("userid", username);
				return this.Content("<script>alert('注册成功！回到登录页面！');window.location.href='StuLogin';</script>");
			}
			else
			{
				ViewBag.LoginState = "注册失败！可能是学号有错";
			}
			return View();
		}
		public ActionResult LogoutUser()
		{
			if (Session["userid"] == null)
			{
				Response.Redirect("/First/StuLogin");
			}
			Session.Remove("userid");//这个方法仅仅是移除了attribute属性值
			Session.Clear();//这个方法是连同session和attribute一同移除
			Response.Redirect("/First/StuLogin");
			return View();
		}
	}
}