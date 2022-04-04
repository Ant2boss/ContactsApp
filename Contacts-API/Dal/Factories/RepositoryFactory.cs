using Contacts_API.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_API.Dal.Factories
{
	public class RepositoryFactory : IRepositoryFactory
	{
		public static IRepositoryFactory GetFactory()
		{
			return new RepositoryFactory();
		}

		public IContactRepository GetContactRepsoitory()
		{
			return new JsonContactRepository(HttpContext.Current.Server.MapPath($"~/contacts.json"));
		}

		private RepositoryFactory()
		{ }
	}
}