using Contacts_App.Api;
using Contacts_App.Api.Factories;
using Contacts_App.Dao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_App.Dao.Factories
{
	public class RepositoryFactory : IRepositoryFactory
	{

		public static IRepositoryFactory GetFactory() => new RepositoryFactory();

		private RepositoryFactory()
		{
		}

		public IContactsRepository GetContactsRepository() => new ApiContactRepository(ApiFactory.GetFactory().GetContactsApi());

	}
}