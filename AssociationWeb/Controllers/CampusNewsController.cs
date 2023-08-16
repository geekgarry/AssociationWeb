using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AssociationWeb.Controllers
{
    public class CampusNewsController : Controller
    {
        // GET: CampusNews
        public ActionResult Index()
        {
			return View();
        }
		[HttpGet]
		public ActionResult IndexPage(int pageno)
		{
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = campusNewDaoImpl.UniversalPage(campusNew, pageNo, onepagesize);
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
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			campusNew.Editorid = form["id"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = campusNewDaoImpl.UniversalPageAss(campusNew, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AllCampusNews()
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			DataTable dataTable = associationNoticeDaoImpl.QueryAllAssociationNoticeTopSlider();
			utils.OpJson dtbtojson = new utils.OpJson();
			ViewData["noticedtb"] = dtbtojson.DbToJson(dataTable);
			return View();
		}
		public ActionResult AllCampusNewsPage(int pageno)
		{
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = campusNewDaoImpl.UniversalPage(campusNew, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AddCampusNews()
		{
			return View();
		}
		public ActionResult AddAssCampusNews()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddCampusNewsAction(FormCollection form)
		{
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			string msg = null;
			campusNew.Newtitle = form["newtitle"];
			campusNew.Newcontent = form["newcontent"];
			campusNew.Editorid = form["edid"];
			campusNew.Editorname = form["edname"];
			campusNew.Id = generateSomeId.Token();
			campusNew.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (campusNewDaoImpl.InsertCampusNew(campusNew) > 0)
			{
				msg = "添加成功！";
			}
			else
			{
				msg = "添加失败！";
			}
			return Content(msg);
		}
		public ActionResult AddAssCampusNewsAction(FormCollection form)
		{
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			string msg = null;
			campusNew.Newtitle = form["newtitle"];
			campusNew.Newcontent = form["newcontent"];
			campusNew.Editorid = form["edid"];
			campusNew.Editorname = form["edname"];
			campusNew.Id = generateSomeId.Token();
			campusNew.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (campusNewDaoImpl.InsertCampusNew(campusNew) > 0)
			{
				msg = "添加成功！";
			}
			else
			{
				msg = "添加失败！";
			}
			return Content(msg);
		}
		public ActionResult DeleteCampusNews(string id)
		{
			string msg = "";
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			campusNew.Id = id;
			if (campusNewDaoImpl.DeleteCampusNew(campusNew) > 0)
			{
				msg = "删除成功！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult UpdateCampusNews(FormCollection form)
		{
			string msg = "";
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			campusNew.Id = form["nid"];
			campusNew.Newtitle = form["ntitle"];
			campusNew.Newcontent = form["ncontent"];
			if (campusNewDaoImpl.UpdateCampusNew(campusNew) > 0)
			{
				msg = "修改成功！";
			}
			else
			{
				msg = "修改失败！";
			}
			return Content(msg);
		}
		public ActionResult OneCampusNews(string id)
		{
			daoimpl.CampusNewDaoImpl campusNewDaoImpl = new daoimpl.CampusNewDaoImpl();
			Models.CampusNew campusNew = new Models.CampusNew();
			utils.OpJson opJson = new utils.OpJson();
			campusNew.Id = id;
			string newsdtb = campusNewDaoImpl.QueryCampusNewWithId(campusNew);
			DataTable cndtb = campusNewDaoImpl.QueryCampusNewTop();
			string[] newinfo = newsdtb.Split(',');
			ViewData["newid"]= newinfo[0];
			ViewData["newtitle"] = newinfo[1];
			ViewData["newcontent"] = newinfo[2];
			ViewData["editorid"] = newinfo[3];
			ViewData["editorname"] = newinfo[4];
			ViewData["uptime"] = newinfo[5];
			ViewData["cndtb"] = opJson.DbToJson(cndtb);
			return View();
		}
	}
}