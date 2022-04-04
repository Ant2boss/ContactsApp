using Contacts_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_App.Api
{
	public interface IContactsApi
	{

		/// <summary>
		/// Adds the Contact to the remote API endpoint.
		/// </summary>
		/// <param name="contact">Contact to add.</param>
		void Add(ContactDetails contact);

		/// <summary>
		/// Deletes the contact from the remote API endpoint.
		/// </summary>
		/// <param name="contact">Contact to remove.</param>
		void Delete(ContactDetails contact);

		/// <summary>
		/// Gets the list of Contacts from the remote API endpoint.
		/// </summary>
		/// <returns></returns>
		IReadOnlyList<ContactDetails> GetList();

	}
}
