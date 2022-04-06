using Contacts_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_App.Dao.Repositories
{
	/// <summary>
	/// Reposiotry for <see cref="ContactViewModel"/>
	/// </summary>
	public interface IContactsRepository
	{
		/// <summary>
		/// Adds Contact to repository.
		/// </summary>
		/// <param name="contact"></param>
		/// <returns></returns>
		bool Add(ContactViewModel contact);

		/// <summary>
		/// Removes Contact from repository.
		/// </summary>
		/// <param name="email"></param>
		void Delete(string email);

		/// <summary>
		/// Returns a list of Contacts in the Repository.
		/// </summary>
		/// <returns></returns>
		IReadOnlyList<ContactViewModel> GetList();

	}
}
