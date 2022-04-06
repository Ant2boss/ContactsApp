using Contacts_App.Api;
using Contacts_App.Api.Factories;
using Contacts_App.Dao.Factories;
using Contacts_App.Dao.Repositories;
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
		private readonly IContactsRepository _contactsRepository;

		public ContactsController()
		{
			this._contactsRepository = RepositoryFactory.GetFactory().GetContactsRepository();
		}

		[HttpGet]
		public ActionResult Index()
		{
			IReadOnlyList<ContactViewModel> contactViewModels = this._contactsRepository.GetList();

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

			if (this._contactsRepository.Add(contactViewModel))
			{
				return this.RedirectToAction("Index");

			}

			this.ViewBag.Error = "Unable to add Contact, Email is taken.";

			return this.View(contactViewModel);
		}

		[HttpGet]
		public ActionResult Delete(string contactEmail)
		{
			if (String.IsNullOrEmpty(contactEmail))
			{
				throw new Exception("Invalid contact!");
			}

			ContactViewModel actualContact = this._contactsRepository.GetList().First(cvm => cvm.Email.Equals(contactEmail));
			return this.View(actualContact);
		}

		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeleteConfirmed(string contactEmail)
		{
			this._contactsRepository.Delete(contactEmail);
			return this.RedirectToAction("Index", "Contacts");
		}

	}
}