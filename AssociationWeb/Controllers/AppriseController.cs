using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace AssociationWeb.Controllers
{
    public class AppriseController : Controller
    {
        // GET: Apprise
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult IndexPage(int pageno)
		{
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			//Models.Apprise apprise = new Models.Apprise();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = appriseDaoImpl.UniversalPage(pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AssIndex()
		{
			return View();
		}
		public ActionResult AssIndexPage(FormCollection form)
		{
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			Models.Apprise apprise = new Models.Apprise();
			apprise.Associationid = form["id"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = appriseDaoImpl.UniversalPageAss(apprise, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult MyStuApprise()
		{
			return View();
		}
		public ActionResult MyStuApprisePage(FormCollection form)
		{
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			Models.Apprise apprise = new Models.Apprise();
			apprise.Stuid = form["stuid"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = appriseDaoImpl.UniversalPageStu(apprise, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AddApprise()
		{
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			DataTable assinfodtb = associationInfoDaoImpl.QueryAllAssociationInfo();
			DataTable apprisedtb = appriseDaoImpl.QueryAppriseTop();
			utils.OpJson dtbtijson = new utils.OpJson();
			ViewData["assinfo"]= dtbtijson.DbToJson(assinfodtb);
			ViewData["apprise"] = dtbtijson.DbToJson(apprisedtb);
			return View();
		}
		[HttpPost]
		public ActionResult AddApprise(FormCollection form)
		{
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			Models.Apprise apprise = new Models.Apprise();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			string stuid = form["stuid"];
			string apprisecontent = form["apprisecontent"];
			string suggestcontent = form["suggestcontent"];
			string assid = form["assid"];
			apprise.Stuid = stuid;
			apprise.Apprisecontent = apprisecontent;
			apprise.Suggestcontent = suggestcontent;
			apprise.Associationid = assid;
			apprise.Id = generateSomeId.GetTimeToId();
			apprise.Create_time = DateTime.Now.ToLocalTime().ToString();
			if(apprisecontent == ""|| suggestcontent==""|| assid == "")
			{
				ViewBag.AddApprise = "不能为空！";
			}
			else if (appriseDaoImpl.InsertApprise(apprise) > 0)
			{
				ViewBag.AddApprise = "已发表评价！";
			}
			else
			{
				ViewBag.AddApprise = "发表评价失败！";
			}
			return RedirectToAction("AddApprise");
		}
		public ActionResult DeleteApprise(string id)
		{
			string msg = "";
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			Models.Apprise apprise = new Models.Apprise();
			apprise.Id = id;
			if (appriseDaoImpl.DeleteApprise(apprise) > 0)
			{
				msg = "删除成功！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult DeleteAppriseAdmin(string id)
		{
			string msg = "";
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			Models.Apprise apprise = new Models.Apprise();
			apprise.Id = id;
			if (appriseDaoImpl.DeleteApprise(apprise) > 0)
			{
				msg = "删除成功！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult UpdateApprise(FormCollection form)
		{
			string msg = "";
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			Models.Apprise apprise = new Models.Apprise();
			apprise.Id = form["nid"];
			apprise.Apprisecontent = form["napprise"];
			apprise.Suggestcontent = form["nsuggest"];
			if (appriseDaoImpl.UpdateApprise(apprise) > 0)
			{
				msg = "修改成功！";
			}
			else
			{
				msg = "修改失败！";
			}
			return Content(msg);
		}
		public ActionResult AllApprise()
		{
			return View();
		}
		public ActionResult OneApprise(string id)
		{
			daoimpl.AppriseDaoImpl appriseDaoImpl = new daoimpl.AppriseDaoImpl();
			Models.Apprise apprise = new Models.Apprise();
			utils.OpJson opJson = new utils.OpJson();
			apprise.Id = id;
			string dtb = appriseDaoImpl.QueryOneApprise(apprise);
			DataTable appdtb = appriseDaoImpl.QueryAppriseTop();
			string[] info = dtb.Split(',');
			ViewData["id"] = info[0];
			ViewData["stuid"] = info[1];
			ViewData["realname"] = info[2];
			ViewData["apprisecontent"] = info[3];
			ViewData["suggestcontent"] = info[4];
			ViewData["associationid"] = info[5];
			ViewData["associationname"] = info[6];
			ViewData["create_time"] = info[7];
			ViewData["appdtb"] = opJson.DbToJson(appdtb);
			return View();
		}
	}
}