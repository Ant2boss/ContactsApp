using Contacts_App.Api;
using Contacts_App.Api.Factories;
using Contacts_App.Models;
using Contacts_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Contacts_App.Controllers
{
	public class ContactsController : Controller
	{
		private readonly IContactsApi _contactsApi;

		public ContactsController()
		{
			this._contactsApi = ApiFactory.GetFactory().GetContactsApi();
		}

		[HttpGet]
		public ActionResult Index()
		{
			IList<ContactViewModel> contactViewModels = this._contactsApi
				.GetList()
				.Select(contact => ContactViewModel.CreateFromDetails(contact))
				.ToList();

			return View(contactViewModels);
		}

		[HttpGet]
		public ActionResult Create()
		{
			ContactViewModel contactVM = new ContactViewModel();
			return this.View(contactVM);
		}

		[HttpPost]
		public ActionResult Create(ContactViewModel contactViewModel)
		{
			if (this.ModelState.IsValid == false)
			{
				return this.View(contactViewModel);
			}

			ContactDetails contactDetails = contactViewModel.ToContactDetails();
			this._contactsApi.Add(contactDetails);

			return this.RedirectToAction("Index");
		}
	}
}