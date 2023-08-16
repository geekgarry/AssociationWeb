using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationWeb.Controllers
{
    public class StuMemberController : Controller
    {
        // GET: StuMember
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult IndexPage(FormCollection form)
		{
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Associationids = form["id"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = stuMemberDaoImpl.UniversalPageAss(stuMember, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult MyStuAcComment()
		{
			return View();
		}
		public ActionResult MyStuAcCommentPage(FormCollection form)
		{
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			activityComment.Stuid = form["stuid"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = activityCommentDaoImpl.UniversalPageStu(activityComment, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AddStuMember()
		{
			return View();
		}
		[HttpPost]
		public ActionResult StuMemberRegister(FormCollection form)
		{
			string username = form["userid"];
			string realname = form["realname"];
			string nickname = form["nickname"];
			string stuclass = form["stuclass"];
			string college = form["college"];
			string phonenumber = form["phonenumber"];
			string password = form["password"];
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Id = username;
			stuMember.Realname = realname;
			stuMember.Nickname = nickname;
			stuMember.Stuclass = stuclass;
			stuMember.Collegedepartment = college;
			stuMember.Phonenumber = phonenumber;
			stuMember.Password = password;
			stuMember.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (username.Equals("") || realname.Equals("") || stuclass.Equals("") || college.Equals("") || phonenumber.Equals("") || password.Equals(""))
			{
				ViewBag.LoginState = "输入不能为空！";
			}
			else if (stuMemberDaoImpl.InsertStuMember(stuMember) > 0)
			{
				//Session.Add("userid", username);
				return this.Content("<script>alert('注册成功！回到登录页面！');window.location.href='/First/StuLogin';</script>");
			}
			else
			{
				ViewBag.LoginState = "注册失败！可能是学号有错";
			}
			return View();
		}
		public ActionResult DeleteStuMember()
		{
			return View();
		}
		public ActionResult UpdateStuMember(FormCollection form)
		{
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			//string jscode = null;
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Id = form["stuid"];
			stuMember.Realname = form["realname"];
			stuMember.Nickname = form["nickname"];
			stuMember.Collegedepartment = form["college"];
			stuMember.Stuclass = form["stuclass"];
			stuMember.Phonenumber = form["phonenumber"];
			stuMember.Hobbyspeciality = form["hobby"];
			stuMember.Personalintro = form["personalintro"];
			if (stuMemberDaoImpl.UpdateStuMember(stuMember) > 0)
			{
				//自定义弹框
				ViewData["jscode"] = "<script>Toast('修改成功！',3000);function Toast(msg, duration){duration = isNaN(duration) ? 3000 : duration;" +
				"var m = document.createElement('div');m.innerHTML = msg;m.style.cssText = 'width: 60%;min-width: 150px;opacity: 0.7;" +
				"height: 30px;color: rgb(255, 255, 255);line-height: 30px;text-align: center;border-radius: 5px;position: fixed;top: 40%;left: 20%;z-index: 999999;background: rgb(0, 0, 0);font-size: 12px;';" +
					"document.body.appendChild(m); setTimeout(function() {var d = 0.5;m.style.webkitTransition = '-webkit-transform ' + d + 's ease-in, opacity ' + d + 's ease-in';m.style.opacity = '0';setTimeout(function() { document.body.removeChild(m) }, d * 1000);}, duration);}" +
				"</script>";
			}
			return RedirectToAction("/MyStuInfo/"+ form["stuid"]);
		}
		public ActionResult UpdateStuMemberAssids(FormCollection form)
		{
			string msg = "";
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			//string jscode = null;
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Id = form["nid"];
			stuMember.Associationids = form["assids"];
			if (stuMemberDaoImpl.UpdateStuMemberAssids(stuMember) > 0)
			{
				//自定义弹框
				msg = "清退成功";
			}
			else{
				msg = "清退失败";
			}
			return Content(msg);
		}
		public ActionResult UpdateStuMemberPwd(string id)
		{
			ViewData["id"] = id;
			return View();
		}
		[HttpPost]
		public ActionResult UpdateStuMemberPwd(FormCollection form)
		{
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			String msg = "";
			stuMember.Id = form["id"];
			string password = form["password"];
			stuMember.Password = password;
			string oldpwd = form["oldpwd"];
			string newpwdagain = form["newpwdagain"];
			if(oldpwd==""|| password == "" || newpwdagain == "")
			{
				msg = "不能为空！";
			}else if(password!= newpwdagain)
			{
				msg = "新密码前后不一致！";
			}else if (stuMemberDaoImpl.UpdateStuMemberPwd(stuMember) > 0)
			{
				msg = "修改成功！";
			}
			else
			{
				msg = "修改失败！";
			}
			return Content(msg);
		}
		public ActionResult MyStuInfo(string id)
		{
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Id = id;
			string dtb = stuMemberDaoImpl.QueryOneStuMember(stuMember);
			string[] info = dtb.Split('*');
			ViewData["id"] = info[0];
			ViewData["realname"] = info[1];
			ViewData["nickname"] = info[2];
			ViewData["stuclass"] = info[3];
			ViewData["phonenumber"] = info[4];
			ViewData["password"] = info[5];
			ViewData["hobbyspeciality"] = info[6];
			ViewData["personalintro"] = info[7];
			ViewData["associationids"] = info[8];
			ViewData["collegedepartment"] = info[9];
			ViewData["create_time"] = info[10];
			return View();
		}
		public ActionResult OneStuInfo(string id)
		{
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			stuMember.Id = id;
			string dtb = stuMemberDaoImpl.QueryOneStuMember(stuMember);
			string[] info = dtb.Split('*');
			ViewData["id"] = info[0];
			ViewData["realname"] = info[1];
			ViewData["nickname"] = info[2];
			ViewData["stuclass"] = info[3];
			ViewData["phonenumber"] = info[4];
			//ViewData["password"] = info[5];//社团管理员无法查询社员的密码可以查询到其他的信息
			ViewData["hobbyspeciality"] = info[6];
			ViewData["personalintro"] = info[7];
			ViewData["associationids"] = info[8];
			ViewData["collegedepartment"] = info[9];
			ViewData["create_time"] = info[10];
			return View();
		}
		public ActionResult MyAssociation(string id)
		{
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			//daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			//Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			Models.StuMember stuMember = new Models.StuMember();
			utils.OpJson opJson = new utils.OpJson();
			//ArrayList assinfolist = new ArrayList();
			stuMember.Id = id;
			//string assids = stuMemberDaoImpl.QueryOneStuMemberAssIds(stuMember);
			//string[] assid = assids.Split(',');
			//for(int i = 0; i < assid.Length; i++)
			//{
			//associationInfo.Id = assid[i];
			//associationInfo.Id = assid[0];
			DataTable oneassinfo = associationInfoDaoImpl.QueryAssociationInfoByStu(stuMember);
			//assinfolist.Add(opJson.DbToArrayList(oneassinfo));
			//}
			ViewData["myallassinfo"] = opJson.DbToJson(oneassinfo);
			//ViewData["assids"] = assids;
			return View();
		}
		public ActionResult OpenedPersonalInfo(string id)
		{
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			utils.OpJson opJson = new utils.OpJson();
			stuMember.Id = id;
			activityComment.Stuid = id;
			string dtb = stuMemberDaoImpl.QueryOneStuMember(stuMember);
			DataTable accommenttb = activityCommentDaoImpl.QueryMyActivityComment(activityComment);
			string[] info = dtb.Split('*');
			ViewData["id"] = info[0];
			ViewData["realname"] = info[1];
			ViewData["nickname"] = info[2];
			ViewData["stuclass"] = info[3];
			ViewData["phonenumber"] = info[4];
			ViewData["password"] = info[5];
			ViewData["hobbyspeciality"] = info[6];
			ViewData["personalintro"] = info[7];
			ViewData["associationids"] = info[8];
			ViewData["collegedepartment"] = info[9];
			ViewData["create_time"] = info[10];
			ViewData["myaccommenttb"] = opJson.DbToJson(accommenttb);
			return View();
		}
	}
}