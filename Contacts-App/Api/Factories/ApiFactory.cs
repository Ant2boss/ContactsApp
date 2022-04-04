using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_App.Api.Factories
{
	public class ApiFactory : IApiFactory
	{
		private const string ENDPOINT_URL = "http://localhost:61436/api/Contacts";

		public static IApiFactory GetFactory()
		{
			return new ApiFactory();
		}

		private ApiFactory()
		{
		}

		public IContactsApi GetContactsApi()
		{
			return new ContactsApi(ENDPOINT_URL);
		}
	}
}