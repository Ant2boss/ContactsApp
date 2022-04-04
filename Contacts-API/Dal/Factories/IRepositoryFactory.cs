using Contacts_API.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_API.Dal.Factories
{
	public interface IRepositoryFactory
	{
		IContactRepository GetContactRepsoitory();
	}
}
