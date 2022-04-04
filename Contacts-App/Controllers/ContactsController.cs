using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts_App.Controllers
{
	public class ContactsController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}