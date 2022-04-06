using Contacts_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_App.Api
{
	/// <summary>
	/// Handles communication with Contacts Endpoint.
	/// </summary>
	public interface IContactsApi
	{

		/// <summary>
		/// Adds the Contact to the remote API endpoint.
		/// </summary>
		/// <param name="contact">Contact to add.</param>
		bool Add(ContactDetails contact);

		/// <summary>
		/// Deletes the contact from the remote API endpoint.
		/// </summary>
		/// <param name="email">Email of contact to remove.</param>
		void Delete(string email);

		/// <summary>
		/// Gets the list of Contacts from the remote API endpoint.
		/// </summary>
		/// <returns></returns>
		IReadOnlyList<ContactDetails> GetList();

	}
}
