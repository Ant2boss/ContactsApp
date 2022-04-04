using Contacts_Data.Models;
using Contacts_Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_API.Dal.Repositories
{
	public interface IContactRepository
	{
		/// <summary>
		/// Adds the Contact to the repository.
		/// </summary>
		/// <param name="contact">Contact to add</param>
		/// <exception cref="DuplicateEmailException" />
		/// <exception cref="InvalidOperationException" />
		void Add(ContactDetails contact);

		/// <summary>
		/// Removes the Contact from the repositroy.
		/// If no such contact exists, nothing is removed.
		/// </summary>
		/// <param name="contact">Contact to remove.</param>
		/// <exception cref="InvalidOperationException" />
		void Delete(ContactDetails contact);

		/// <summary>
		/// List of all the Contacts in the repository.
		/// </summary>
		/// <returns>List of Contacts.</returns>
		IReadOnlyList<ContactDetails> GetList();
	}
}
