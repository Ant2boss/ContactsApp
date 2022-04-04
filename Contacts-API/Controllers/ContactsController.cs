using Contacts_API.Dal.Factories;
using Contacts_API.Dal.Repositories;
using Contacts_API.Validators;
using Contacts_Data.Exceptions;
using Contacts_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contacts_API.Controllers
{
	public class ContactsController : ApiController
	{

		private readonly IContactRepository _contactRepository;

		public ContactsController()
		{
			this._contactRepository = RepositoryFactory.GetFactory().GetContactRepsoitory();
		}

		[HttpGet]
		public HttpResponseMessage GetList()
		{
			IReadOnlyList<ContactDetails> contacts = this._contactRepository.GetList();

			return this.Request.CreateResponse(HttpStatusCode.OK, contacts);
		}

		[HttpPost]
		public HttpResponseMessage Add([FromBody] ContactDetails contact)
		{

			if (ContactValidator.IsInvalidContact(contact))
			{
				return this.Request.CreateResponse(HttpStatusCode.BadRequest);
			}

			try
			{
				this._contactRepository.Add(contact);
				return this.Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (DuplicateEmailException)
			{
				return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Email already exists!");
			}
		}

		[HttpDelete]
		public HttpResponseMessage Delete([FromBody] ContactDetails contact)
		{
			if (ContactValidator.IsInvalidContact(contact))
			{
				return this.Request.CreateResponse(HttpStatusCode.BadRequest);
			}

			this._contactRepository.Delete(contact);
			return this.Request.CreateResponse(HttpStatusCode.OK);
		}

	}
}
