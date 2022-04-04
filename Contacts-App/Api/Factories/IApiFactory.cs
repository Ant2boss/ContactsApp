using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_App.Api.Factories
{
	public interface IApiFactory
	{
		IContactsApi GetContactsApi();
	}
}
