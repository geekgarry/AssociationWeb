using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.IO;

namespace AssociationWeb.Controllers
{
    public class AssociationController : Controller
    {
        // GET: Association
        public ActionResult Index()
        {
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			DataTable dt = associationInfoDaoImpl.QueryAllAssociationInfo();
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				string intro = null;
				if(dt.Rows[i]["associationintro"].ToString().Length> 20)
				{
					intro = dt.Rows[i]["associationintro"].ToString().Substring(0, 15);
				}
				else
				{
					intro = dt.Rows[i]["associationintro"].ToString();
				}
				sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td>" +
					"<td>{5}</td><td><div><button type='button' class='btn btn - primary btn - xs' onclick='return firm({6});'>删除</button>&nbsp;<a type='button' class='btn btn - primary btn - xs' href='/Association/OneAssInfoAdmin/{6}'>详情</a></div></td></tr>", dt.Rows[i]["username"], dt.Rows[i]["associationname"], intro
					, dt.Rows[i]["teacherincharge"], dt.Rows[i]["stuincharge"], dt.Rows[i]["create_time"], dt.Rows[i]["id"]);
			}
			ViewData["assdata"] = sb;
			//return this.Content(sb.ToString());
			return View();
        }

        // GET: Association/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Association/Create
        public ActionResult Create()
        {
            return View();
        }
		public ActionResult AllAssociation()
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			DataTable dataTable = associationNoticeDaoImpl.QueryAllAssociationNoticeTopSlider();
			utils.OpJson dtbtojson = new utils.OpJson();
			ViewData["noticedtb"] = dtbtojson.DbToJson(dataTable);
			return View();
		}
		public ActionResult AllAssociationPage(int pageno)
		{
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = associationInfoDaoImpl.UniversalPage(pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		// POST: Association/Create
		[HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Association/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Association/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Association/Delete/5
        public ActionResult Delete(String id)
        {
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			associationInfo.Id = id;
			if (associationInfoDaoImpl.DeleteAssociationInfo(associationInfo) > 0)
			{
				ViewBag.delete = "已删除！";
			}
			else
			{
				ViewBag.delete = "删除失败！";
			}
			return RedirectToAction("Index");
        }
		public ActionResult UpdateAssInfo(FormCollection form)
		{
			string msg = "";
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			associationInfo.Id = form["uid"];
			associationInfo.Username = form["username"];
			associationInfo.Password = form["password"];
			associationInfo.Associationname = form["assname"];
			associationInfo.Associationintro = form["assintro"];
			associationInfo.Teacherincharge = form["teacher"];
			associationInfo.Stuincharge = form["student"];
			if (associationInfoDaoImpl.UpdateAssociationInfo(associationInfo) > 0)
			{
				msg = "修改成功！";
			}
			else
			{
				msg = "修改失败！";
			}
			return Content(msg);
		}
		// POST: Association/Delete/5
		[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
		}
		public ActionResult MyAssInfo(string id)
		{
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			associationInfo.Id = id;
			string admin = associationInfoDaoImpl.QueryOneAssociationInfo(associationInfo);
			string[] admininfo = admin.Split(',');
			ViewData["id"] = admininfo[0];
			ViewData["username"] = admininfo[1];
			ViewData["password"] = admininfo[2];
			ViewData["assname"] = admininfo[3];
			ViewData["assintro"] = admininfo[4];
			ViewData["teacher"] = admininfo[5];
			ViewData["student"] = admininfo[6];
			ViewData["ctime"] = admininfo[7];
			return View();
		}
		public ActionResult OneAssInfo(string id)
		{
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			utils.OpJson opJson = new utils.OpJson();
			associationInfo.Id = id;
			string dtb = associationInfoDaoImpl.QueryOneAssociationInfo(associationInfo);
			DataTable aidtb = associationInfoDaoImpl.QueryAllAssociationInfoTop();
			string[] info = dtb.Split(',');
			ViewData["id"] = info[0];
			ViewData["username"] = info[1];
			ViewData["password"] = info[2];
			ViewData["associationname"] = info[3];
			ViewData["associationintro"] = info[4];
			ViewData["teacherincharge"] = info[5];
			ViewData["stuincharge"] = info[6];
			ViewData["create_time"] = info[7];
			ViewData["aidtb"] = opJson.DbToJson(aidtb);
			return View();
		}
		public ActionResult OneAssInfoAdmin(string id)
		{
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			Models.AssociationInfo associationInfo = new Models.AssociationInfo();
			utils.OpJson opJson = new utils.OpJson();
			associationInfo.Id = id;
			string dtb = associationInfoDaoImpl.QueryOneAssociationInfo(associationInfo);
			DataTable aidtb = associationInfoDaoImpl.QueryAllAssociationInfoTop();
			string[] info = dtb.Split(',');
			ViewData["id"] = info[0];
			ViewData["username"] = info[1];
			ViewData["password"] = info[2];
			ViewData["associationname"] = info[3];
			ViewData["associationintro"] = info[4];
			ViewData["teacherincharge"] = info[5];
			ViewData["stuincharge"] = info[6];
			ViewData["create_time"] = info[7];
			ViewData["aidtb"] = opJson.DbToJson(aidtb);
			return View();
		}
	}
}
