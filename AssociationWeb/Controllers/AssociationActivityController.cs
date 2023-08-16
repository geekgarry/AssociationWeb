using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationWeb.Controllers
{
    public class AssociationActivityController : Controller
    {
        // GET: AssociationActivity
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult IndexPage(FormCollection form)
		{
			daoimpl.AssociationActivityDaoImpl associationActivityDaoImpl = new daoimpl.AssociationActivityDaoImpl();
			Models.Associationactivity associationactivity = new Models.Associationactivity();
			associationactivity.Associationid = form["id"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = associationActivityDaoImpl.UniversalPageAss(associationactivity, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AllAssActivity()
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			DataTable dataTable = associationNoticeDaoImpl.QueryAllAssociationNoticeTopSlider();
			utils.OpJson dtbtojson = new utils.OpJson();
			ViewData["noticedtb"] = dtbtojson.DbToJson(dataTable);
			return View();
		}
		public ActionResult AllAssActivityPage(int pageno)
		{
			daoimpl.AssociationActivityDaoImpl associationActivityDaoImpl = new daoimpl.AssociationActivityDaoImpl();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = associationActivityDaoImpl.UniversalPage(pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AddAssActivity()
		{
			return View();
		}
		public ActionResult AddAssActivityPage(FormCollection form)
		{
			daoimpl.AssociationActivityDaoImpl associationActivityDaoImpl = new daoimpl.AssociationActivityDaoImpl();
			Models.Associationactivity associationactivity = new Models.Associationactivity();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			string msg = null;
			associationactivity.Activitytitle = form["actitle"];
			associationactivity.Personalincharge = form["incharge"];
			associationactivity.Activitycontent = form["accontent"];
			associationactivity.Associationid = form["assid"];
			associationactivity.Id = generateSomeId.GetTimeToId();
			associationactivity.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (associationActivityDaoImpl.InsertAssociationActivity(associationactivity) > 0)
			{
				msg = "添加成功！";
			}
			else
			{
				msg = "添加失败！";
			}
			return Content(msg);
		}
		public ActionResult DeleteAssActivity(string id)
		{
			string msg = "";
			daoimpl.AssociationActivityDaoImpl associationActivityDaoImpl = new daoimpl.AssociationActivityDaoImpl();
			Models.Associationactivity associationactivity = new Models.Associationactivity();
			associationactivity.Id = id;
			if (associationActivityDaoImpl.DeleteAssociationActivity(associationactivity) > 0)
			{
				msg = "删除成功！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult UpdateAssActivity(FormCollection form)
		{
			string msg = "";
			daoimpl.AssociationActivityDaoImpl associationActivityDaoImpl = new daoimpl.AssociationActivityDaoImpl();
			Models.Associationactivity associationactivity = new Models.Associationactivity();
			associationactivity.Id = form["nid"];
			associationactivity.Activitytitle = form["ntitle"];
			associationactivity.Personalincharge = form["ncharge"];
			associationactivity.Activitycontent = form["ncontent"];
			associationactivity.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (associationActivityDaoImpl.UpdateAssociationActivity(associationactivity) > 0)
			{
				msg = "更新成功！";
			}
			else
			{
				msg = "更新失败！";
			}
			return Content(msg);
		}
		public ActionResult OneAssActivity(string id)
		{
			daoimpl.AssociationActivityDaoImpl associationActivityDaoImpl = new daoimpl.AssociationActivityDaoImpl();
			Models.Associationactivity associationactivity = new Models.Associationactivity();
			utils.OpJson opJson = new utils.OpJson();
			associationactivity.Id = id;
			string newsdtb = associationActivityDaoImpl.QueryOneAssociationActivity(associationactivity);
			DataTable assacdtb = associationActivityDaoImpl.QueryAllAssociationActivityTop();
			daoimpl.ActivityCommentDaoImpl activityCommentDaoImpl = new daoimpl.ActivityCommentDaoImpl();
			Models.ActivityComment activityComment = new Models.ActivityComment();
			activityComment.Associationactivityid = id;
			DataTable accommentdtb = activityCommentDaoImpl.QueryAboutActivityCommentTop(activityComment);
			string[] newinfo = newsdtb.Split(',');
			ViewData["acid"] = newinfo[0];
			ViewData["perincharge"] = newinfo[1];
			ViewData["actitle"] = newinfo[2];
			ViewData["accontent"] = newinfo[3];
			ViewData["assid"] = newinfo[4];
			ViewData["assname"] = newinfo[5];
			ViewData["ctime"] = newinfo[6];
			ViewData["assacdtb"] = opJson.DbToJson(assacdtb);
			ViewData["accommentdtb"] = opJson.DbToJson(accommentdtb);
			return View();
		}
	}
}