using Contacts_App.Dao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_App.Dao.Factories
{
	public interface IRepositoryFactory
	{
		IContactsRepository GetContactsRepository();
	}
}
