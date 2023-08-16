using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationWeb.Controllers
{
    public class AssociationInformController : Controller
    {
        // GET: AssociationInform
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult IndexPage(FormCollection form)
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			Models.AssociationInform associationInform = new Models.AssociationInform();
			associationInform.Associationid = form["id"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = associationNoticeDaoImpl.UniversalPageAss(associationInform, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AllInform()
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			DataTable dataTable = associationNoticeDaoImpl.QueryAllAssociationNoticeTopSlider();
			utils.OpJson dtbtojson = new utils.OpJson();
			ViewData["noticedtb"] = dtbtojson.DbToJson(dataTable);
			return View();
		}
		public ActionResult AllInformPage(int pageno)
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = associationNoticeDaoImpl.UniversalPage(pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult DeleteInform(string id)
		{
			string msg = "";
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			Models.AssociationInform associationInform = new Models.AssociationInform();
			associationInform.Id = id;
			if (associationNoticeDaoImpl.DeleteAssociationNotice(associationInform) > 0)
			{
				msg = "删除成功！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult UpdateAssInform(FormCollection form)
		{
			string msg = "";
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			Models.AssociationInform associationInform = new Models.AssociationInform();
			associationInform.Id = form["nid"];
			associationInform.Noticetitle = form["ntitle"];
			associationInform.Noticecontent = form["ncontent"];
			associationInform.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (associationNoticeDaoImpl.UpdateAssociationNotice(associationInform) > 0)
			{
				msg = "修改成功！";
			}
			else
			{
				msg = "修改失败！";
			}
			return Content(msg);
		}
		public ActionResult AddAssInform()
		{
			return View();
		}
		public ActionResult AddAssInformPage(FormCollection form)
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			Models.AssociationInform associationInform = new Models.AssociationInform();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			string msg = null;
			associationInform.Noticetitle = form["noticetitle"];
			associationInform.Noticecontent = form["noticecontent"];
			associationInform.Associationid = form["assid"];
			associationInform.Id = generateSomeId.GetTimeToId();
			associationInform.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (associationNoticeDaoImpl.InsertAssociationNotice(associationInform) > 0)
			{
				msg = "添加成功！";
			}
			else
			{
				msg = "添加失败！";
			}
			return Content(msg);
		}
			public ActionResult OneAssInform(string id)
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			Models.AssociationInform associationInform = new Models.AssociationInform();
			utils.OpJson opJson= new utils.OpJson();
			associationInform.Id = id;
			string dtb = associationNoticeDaoImpl.QueryOneAssociationNotice(associationInform);
			DataTable anidtb = associationNoticeDaoImpl.QueryAllAssociationNoticeTop();
			string[] info = dtb.Split(',');
			ViewData["id"] = info[0];
			ViewData["noticetitle"] = info[1];
			ViewData["noticecontent"] = info[2];
			ViewData["associationid"] = info[3];
			ViewData["associationname"] = info[4];
			ViewData["create_time"] = info[5];
			ViewData["anidtb"] = opJson.DbToJson(anidtb);
			return View();
		}
	}
}