using Contacts_App.Api;
using Contacts_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_App.Dao.Repositories
{
	public class ApiContactRepository : IContactsRepository
	{
		private readonly IContactsApi _contactsApi;

		public ApiContactRepository(IContactsApi contactsApi)
		{
			this._contactsApi = contactsApi;
		}

		public bool Add(ContactViewModel contact)
		{
			return this._contactsApi.Add(contact.ToContactDetails());
		}

		public void Delete(string email)
		{
			this._contactsApi.Delete(email);
		}

		public IReadOnlyList<ContactViewModel> GetList()
		{
			return this._contactsApi.GetList().Select(cd => ContactViewModel.CreateFromDetails(cd)).ToList();
		}
	}
}