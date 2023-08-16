using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationWeb.Controllers
{
    public class ApplyJoinController : Controller
    {
        // GET: ApplyJoin
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult IndexPage(FormCollection form)
		{
			daoimpl.ApplyJoinDaoImpl applyJoinDaoImpl = new daoimpl.ApplyJoinDaoImpl();
			Models.ApplyJoin applyJoin = new Models.ApplyJoin();
			applyJoin.Associationid = form["id"];
			applyJoin.Auditstatus = form["auditstatus"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = applyJoinDaoImpl.UniversalPageAss(applyJoin, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult MyStuApplyJoin()
		{
			return View();
		}
		public ActionResult MyStuApplyJoinPage(FormCollection form)
		{
			daoimpl.ApplyJoinDaoImpl applyJoinDaoImpl = new daoimpl.ApplyJoinDaoImpl();
			Models.ApplyJoin applyJoin = new Models.ApplyJoin();
			applyJoin.Stuid = form["stuid"];
			int pageNo;
			/*if (pageno == 0)
			{
				pageNo = 1;
			}*/
			pageNo = int.Parse(form["pageno"]);
			int onepagesize = 10;
			Models.UniversalPage pagedtb = applyJoinDaoImpl.UniversalPageStu(applyJoin, pageNo, onepagesize);
			utils.OpJson dtbtojson = new utils.OpJson();
			//ViewData["newdtb"] = dtbtojson.PageToJson(pagedtb);
			//return Json();
			return Content(dtbtojson.PageToJson(pagedtb));
		}
		public ActionResult AddApplyJoin()
		{
			daoimpl.AssociationInfoDaoImpl associationInfoDaoImpl = new daoimpl.AssociationInfoDaoImpl();
			DataTable assinfodtb = associationInfoDaoImpl.QueryAllAssociationInfo();
			utils.OpJson dtbtijson = new utils.OpJson();
			ViewData["assinfo"] = dtbtijson.DbToJson(assinfodtb);
			return View();
		}
		[HttpPost]
		public ActionResult AddApplyJoin(FormCollection form)
		{
			daoimpl.ApplyJoinDaoImpl applyJoinDaoImpl = new daoimpl.ApplyJoinDaoImpl();
			Models.ApplyJoin applyJoin = new Models.ApplyJoin();
			utils.GenerateSomeId generateSomeId = new utils.GenerateSomeId();
			string stuid = form["stuid"];
			string hobbyspeciality = form["hobbyspeciality"];
			string applyreason = form["applyreason"];
			string personalintro = form["personalintro"];
			string assid = form["assid"];
			applyJoin.Stuid = stuid;
			applyJoin.Hobbyspeciality = hobbyspeciality;
			applyJoin.Applyreason = applyreason;
			applyJoin.Personalintro = personalintro;
			applyJoin.Associationid = assid;
			applyJoin.Id = generateSomeId.GetTimeToId();
			applyJoin.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (hobbyspeciality == "" || applyreason == "" || personalintro == "" || assid == "")
			{
				ViewBag.AddApprise = "不能为空！";
			}
			else if (applyJoinDaoImpl.InsertApplyJoin(applyJoin)> 0)
			{
				ViewBag.AddApprise = "已发表评价！";
			}
			else
			{
				ViewBag.AddApprise = "发表评价失败！";
			}
			return RedirectToAction("AddApplyJoin");
		}
		public ActionResult DeleteApplyJoin(string id)
		{
			string msg = "";
			daoimpl.ApplyJoinDaoImpl applyJoinDaoImpl = new daoimpl.ApplyJoinDaoImpl();
			Models.ApplyJoin applyJoin = new Models.ApplyJoin();
			applyJoin.Id = id;
			if (applyJoinDaoImpl.DeleteApplyJoin(applyJoin) > 0)
			{
				msg = "已删除！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult UpdateApplyJoin(FormCollection form)
		{
			string msg = "";
			daoimpl.ApplyJoinDaoImpl applyJoinDaoImpl = new daoimpl.ApplyJoinDaoImpl();
			Models.ApplyJoin applyJoin = new Models.ApplyJoin();
			applyJoin.Id = form["nid"];
			applyJoin.Personalintro = form["nperintro"];
			applyJoin.Hobbyspeciality = form["nhobby"];
			applyJoin.Applyreason = form["napplyreason"];
			if (applyJoinDaoImpl.UpdateApplyJoinContent(applyJoin) > 0)
			{
				msg = "修改成功！";
			}
			else
			{
				msg = "修改失败！";
			}
			return Content(msg);
		}
		public ActionResult AgreeApplyJoin(FormCollection form)
		{
			string msg = "";
			daoimpl.ApplyJoinDaoImpl applyJoinDaoImpl = new daoimpl.ApplyJoinDaoImpl();
			daoimpl.StuMemberDaoImpl stuMemberDaoImpl = new daoimpl.StuMemberDaoImpl();
			Models.StuMember stuMember = new Models.StuMember();
			Models.ApplyJoin applyJoin = new Models.ApplyJoin();
			applyJoin.Id = form["nid"];
			//stuMember.Personalintro = form["nperintro"];
			//stuMember.Hobbyspeciality = form["nhobby"];
			//applyJoin.Applyreason = form["napplyreason"];
			applyJoin.Auditstatus = "1";//form["auditstatus"];
			stuMember.Id = form["nstuid"];
			stuMember.Associationids = form["nassid"];
			if (applyJoinDaoImpl.UpdateApplyJoinauditstatus(applyJoin) > 0)
			{
				stuMemberDaoImpl.UpdateStuMemberFromApplyJoin(stuMember);
				msg = "同意加入本社团！";
			}
			else
			{
				msg = "申请加入社团失败！";
			}
			return Content(msg);
		}
		public ActionResult MyAssApplyJoin()
		{
			return View();
		}
		public ActionResult OneAssApplyJoin(string id)
		{
			daoimpl.ApplyJoinDaoImpl applyJoinDaoImpl = new daoimpl.ApplyJoinDaoImpl();
			Models.ApplyJoin applyJoin = new Models.ApplyJoin();
			applyJoin.Id = id;
			string newsdtb = applyJoinDaoImpl.QueryOneApplyJoin(applyJoin);
			string[] newinfo = newsdtb.Split(',');
			ViewData["id"] = newinfo[0];
			ViewData["associationid"] = newinfo[1];
			ViewData["hobbyspeciality"] = newinfo[2];
			ViewData["applyreason"] = newinfo[3];
			ViewData["personalintro"] = newinfo[4];
			ViewData["auditstatus"] = newinfo[5];
			ViewData["create_time"] = newinfo[6];
			ViewData["associationname"] = newinfo[7];
			ViewData["realname"] = newinfo[8];
			return View();
		}
	}
}