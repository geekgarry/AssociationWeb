using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationWeb.Controllers
{
    public class ActivityCommentController : Controller
    {
        // GET: ActivityComment
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult IndexPage(int pageno)
		{
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = activityCommentDaoImpl.UniversalPage(pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult OneAcCommentIndex(string id)
		{
			ViewData["acid"]= id;
			return View();
		}
		public ActionResult OneAcCommentIndexPage(FormCollection form)
		{
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			activityComment.Associationactivityid = form["acid"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = activityCommentDaoImpl.UniversalPageAss(activityComment,pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult OneAcComment(string id)
		{
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			utils.OpJson opJson = new utils.OpJson();
			activityComment.Id = id;
			string dtb = activityCommentDaoImpl.QueryOneActivityComment(activityComment);
			DataTable acdtb = activityCommentDaoImpl.QueryAllActivityCommentTop();
			string[] info = dtb.Split(',');
			ViewData["id"] = info[0];
			ViewData["stuid"] = info[1];
			ViewData["realname"] = info[2];
			ViewData["nickname"] = info[3];
			ViewData["stuclass"] = info[4];
			ViewData["activitycomment"] = info[5];
			ViewData["associationactivityid"] = info[6];
			ViewData["create_time"] = info[7];
			ViewData["actitle"] = info[8];
			ViewData["acdtb"] = opJson.DbToJson(acdtb);
			return View();
		}
		public ActionResult DeleteActivityComment(string id)
		{
			string msg = "";
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			activityComment.Id = id;
			if(activityCommentDaoImpl.DeleteActivityComment(activityComment) >0)
			{
				msg = "删除成功!";
			}
			else
			{
				msg = "删除失败!";
			}
			//ViewData["acdtb"] = opJson.DbToJson(acdtb);
			return Content(msg);
		}
		public ActionResult UpdateActivityComment(FormCollection form)
		{
			string msg = "";
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			activityComment.Id = form["nid"];
			activityComment.Activitycomment = form["accomment"];
			if (activityCommentDaoImpl.UpdateActivityComment(activityComment) > 0)
			{
				msg = "修改成功!";
			}
			else
			{
				msg = "修改失败!";
			}
			//ViewData["acdtb"] = opJson.DbToJson(acdtb);
			return Content(msg);
		}
		[HttpGet]
		public ActionResult AboutActivityComment(string acid)
		{
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			utils.OpJson opJson = new utils.OpJson();
			activityComment.Associationactivityid = acid;
			DataTable acdtb = activityCommentDaoImpl.QueryAboutActivityCommentTop(activityComment);
			//ViewData["acdtb"] = opJson.DbToJson(acdtb);
			return Content(opJson.DbToJson(acdtb));
		}
		[HttpPost]
		public ActionResult AddActivityComment(FormCollection form)
		{
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			utils.OpJson opJson = new utils.OpJson();
			string msg = null;
			activityComment.Activitycomment = form["accomment"];
			activityComment.Stuid = form["stuid"];
			activityComment.Associationactivityid = form["acid"];
			activityComment.Id = generateSomeId.GenerateNum();
			activityComment.Create_time = DateTime.Now.ToLocalTime().ToString();
			if(form["accomment"]==""|| form["stuid"]=="" || form["acid"] == "" || form["accomment"] == null)
			{
				msg = "发表失败！不能为空！";
			}else if(activityCommentDaoImpl.InsertActivityComment(activityComment) > 0)
			{
				msg = "发表成功！";
			}
			else
			{
				msg = "发表失败！";
			}
			//ViewData["acdtb"] = opJson.DbToJson(acdtb);
			return Content(msg);
		}
	}
}