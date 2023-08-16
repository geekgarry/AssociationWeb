using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationWeb.Controllers
{
    public class FileResourceController : Controller
    {
		// GET: FileResource[HttpPost]
		public ActionResult Index()
        {
			//ViewData["id"] = id;
			return View();
        }
		public ActionResult FileIndex()
		{
			//ViewData["id"] = id;
			return View();
		}
		[HttpPost]
		public ActionResult UploadFile(FormCollection form)
		{
			//var fileName = file.FileName;
			HttpPostedFileBase files = Request.Files["fileposition"];
			//var file = files[0];
			bool isOk = false;
			string msg = string.Empty;
			string filePath = Server.MapPath("/UpFile");//(string.Format("~/{0}", "UpFile"));//取得目标文件夹的路径
			string fileurlname = files.FileName;//取得文件名字
			try
			{
				files.SaveAs(Path.Combine(filePath, fileurlname));
				isOk = true;
			}
			catch (Exception ex)
			{
				ViewBag.UploadStatus = string.Format("上传文件出现异常：{0}", ex.Message);
			}
			if (isOk)
			{
				ViewBag.UploadStatus = "上传成功！";
				//AddUploadFile(form);
				ViewData["filepath"] = "/UpFile/" + fileurlname;
			}
			else
			{
				ViewBag.UploadStatus = "上传失败！";
			}
			//return RedirectToAction("Index");
			return View("Index");
		}
		[HttpPost]
		public ActionResult AssUploadFile(FormCollection form)
		{
			//var fileName = file.FileName;
			HttpPostedFileBase files = Request.Files["fileposition"];
			//var file = files[0];
			bool isOk = false;
			string filePath = Server.MapPath("/UpFile");//(string.Format("~/{0}", "UpFile"));//取得目标文件夹的路径
			string fileurlname = files.FileName;//取得文件名字
			try
			{
				//if(resourceDaoImpl.InsertResource(resources) > 0)
				files.SaveAs(Path.Combine(filePath, fileurlname));
				isOk = true;
			}
			catch (Exception ex)
			{
				ViewBag.UploadStatus = string.Format("上传文件出现异常：{0}", ex.Message);
			}
			if (isOk)
			{
				ViewBag.UploadStatus = "上传成功！";
				ViewData["filepath"] = "/UpFile/" + fileurlname;
			}
			else
			{
				ViewBag.UploadStatus = "上传失败！";
			}
			//return RedirectToAction("FileIndex");
			return View("FileIndex");
		}
		[HttpPost]
		public ActionResult AddUploadFile(FormCollection form)
		{
			string filename = form["filename"];
			string filecontent = form["filecontent"];
			string filetype = form["filetype"];
			string upname = form["upname"];
			string upid = form["upid"];
			string filepath = form["filepath"];
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			Models.Resources resources = new Models.Resources();
			resources.Upid = upid;
			resources.Upidname = upname;
			resources.Dtitle = filename;
			resources.Dcontent = filecontent;
			resources.Dtype = filetype;
			resources.Create_time = DateTime.Now.ToLocalTime().ToString();
			resources.Id = generateSomeId.GenerateNum();
			resources.Dfileposition = filepath;
			if(resourceDaoImpl.InsertResource(resources) > 0)
			{
				ViewBag.UploadState = "添加成功！";
			}
			else
			{
				ViewBag.UploadState = "添加失败！";
			}
			//return RedirectToAction("Index");
			return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult AddUploadFileAss(FormCollection form)
		{
			string filename = form["filename"];
			string filecontent = form["filecontent"];
			string filetype = form["filetype"];
			string upname = form["upname"];
			string upid = form["upid"];
			string filepath = form["filepath"];
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			Models.Resources resources = new Models.Resources();
			resources.Upid = upid;
			resources.Upidname = upname;
			resources.Dtitle = filename;
			resources.Dcontent = filecontent;
			resources.Dtype = filetype;
			resources.Create_time = DateTime.Now.ToLocalTime().ToString();
			resources.Id = generateSomeId.GenerateNum();
			resources.Dfileposition = filepath;
			if (resourceDaoImpl.InsertResource(resources) > 0)
			{
				ViewBag.UploadState = "添加成功！";
			}
			else
			{
				ViewBag.UploadState = "添加失败！";
			}
			return RedirectToAction("FileIndex");
		}
		public ActionResult AllResource()
		{
			daoimpl.AssociationNoticeDaoImpl associationNoticeDaoImpl = new daoimpl.AssociationNoticeDaoImpl();
			DataTable dataTable = associationNoticeDaoImpl.QueryAllAssociationNoticeTopSlider();
			utils.OpJson dtbtojson = new utils.OpJson();
			ViewData["noticedtb"] = dtbtojson.DbToJson(dataTable);
			return View();
		}
		public ActionResult AllResourcePage(int pageno)
		{
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = resourceDaoImpl.UniversalPage(pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AddResource()
		{
			return View();
		}
		public ActionResult UpdateResource()
		{
			return View();
		}
		public ActionResult UpdateResourceAss(FormCollection form)
		{
			string msg = "";
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			Models.Resources resources = new Models.Resources();
			resources.Id = form["nid"];
			resources.Dtitle = form["ntitle"];
			resources.Dcontent = form["ncontent"];
			resources.Dtype = form["ntype"];
			if (resourceDaoImpl.UpdateResource(resources) > 0)
			{
				msg = "修改成功！";
			}
			else
			{
				msg = "修改失败！";
			}
			return Content(msg);
		}
		public ActionResult DeleteResource(string id)
		{
			string msg = "";
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			Models.Resources resources = new Models.Resources();
			resources.Id = id;
			if (resourceDaoImpl.DeleteResource(resources) > 0)
			{
				msg = "删除成功！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult AllFileResourceAdmin()
		{
			return View();
		}
		public ActionResult AllFileResourceAdminPage(int pageno)
		{
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = pageno;
			int onepagesize = 10;
			Models.UniversalPage pagedtb = resourceDaoImpl.UniversalPage(pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AllFileResourceAss()
		{
			return View();
		}
		public ActionResult AllFileResourceAssPage(FormCollection form)
		{
			daoimpl.ResourceDaoImpl resourceDaoImpl = new daoimpl.ResourceDaoImpl();
			Models.Resources resources = new Models.Resources();
			resources.Upid = form["id"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = resourceDaoImpl.UniversalPageAss(resources, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public FileResult DownLoadMyFile(string fileName)
		{
			string root = Server.MapPath("/UpFile/");
			//string fileName = "test.jpg";
			string[] filanmes = fileName.Split('/');
			string filePath = Path.Combine(root, filanmes[1]);
			string s = MimeMapping.GetMimeMapping(filanmes[1]);

			return File(filePath, s, Path.GetFileName(filePath));
		}
	}
}