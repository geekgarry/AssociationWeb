using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationWeb.Controllers
{
    public class FriendshipLinkController : Controller
    {
        // GET: FriendshipLink
        public ActionResult Index()
        {
			daoimpl.FriendShipLinkDaoImpl friendShipLinkDaoImpl = new daoimpl.FriendShipLinkDaoImpl();
			DataTable linkdtb = friendShipLinkDaoImpl.QueryFriendShipLink();
			utils.OpJson opJson = new utils.OpJson();
			ViewData["datadtb"]= opJson.DbToJson(linkdtb);
			return View();
        }
		public ActionResult Addlink()
		{
			return View();
		}
		public ActionResult AddFriendshipLink(FormCollection form)
		{
			string msg = "";
			daoimpl.FriendShipLinkDaoImpl friendShipLinkDaoImpl = new daoimpl.FriendShipLinkDaoImpl();
			Models.FriendshipLink friendshipLink = new Models.FriendshipLink();
			friendshipLink.Linkname = form["linkname"];
			friendshipLink.Linkurl = form["linkurl"];
			if (friendShipLinkDaoImpl.InsertFriendShipLink(friendshipLink) > 0)
			{
				msg = "添加成功！";
			}
			else
			{
				msg = "添加失败！";
			}
			return Content(msg);
		}
		public ActionResult DeleteFriendshipLink(string id)
		{
			string msg = "";
			daoimpl.FriendShipLinkDaoImpl friendShipLinkDaoImpl = new daoimpl.FriendShipLinkDaoImpl();
			Models.FriendshipLink friendshipLink = new Models.FriendshipLink();
			friendshipLink.Id = id;
			if (friendShipLinkDaoImpl.DeleteFriendShipLink(friendshipLink) > 0)
			{
				msg = "已删除！";
			}
			else
			{
				msg = "删除失败！";
			}
			return Content(msg);
		}
		public ActionResult UpdateFriendshipLink(FormCollection form)
		{
			daoimpl.FriendShipLinkDaoImpl friendShipLinkDaoImpl = new daoimpl.FriendShipLinkDaoImpl();
			Models.FriendshipLink friendshipLink = new Models.FriendshipLink();
			string msg = null;
			friendshipLink.Id = form["nid"];
			friendshipLink.Linkname = form["ntitle"];
			friendshipLink.Linkurl = form["ncontent"];
			if (form["username"] == "" || form["password"] == "")
			{
				msg = "不能为空！";
			}
			else
			//administrator.Create_time = DateTime.Now.ToLocalTime().ToString();
			if (friendShipLinkDaoImpl.UpdateFriendShipLink(friendshipLink) > 0)
			{
				msg = "已更新！";
			}
			else
			{
				msg = "更新失败！";
			}
			return Content(msg);
		}
		public ActionResult AllFriendshipLink()
		{
			return View();
		}
	}
}