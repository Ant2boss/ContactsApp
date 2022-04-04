using Contacts_API.Validators;
using Contacts_Data.Exceptions;
using Contacts_Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Contacts_API.Dal.Repositories
{
	public class JsonContactRepository : IContactRepository
	{

		private readonly string _jsonFilePath;

		public JsonContactRepository(string jsonFilePath)
		{
			this._jsonFilePath = jsonFilePath;
		}

		public void Add(ContactDetails contact)
		{

			if (ContactValidator.IsInvalidContact(contact))
			{
				throw new InvalidOperationException();
			}

			ISet<ContactDetails> existingContactsSet = this._LoadContactsList();
			if (existingContactsSet.Add(contact))
			{
				this._SaveContactsList(existingContactsSet);
				return;
			}

			throw new DuplicateEmailException($"{contact.Email} already exists in repository!");
		}

		public void Delete(ContactDetails contact)
		{
			if (ContactValidator.IsInvalidContact(contact))
			{
				throw new InvalidOperationException();
			}

			ISet<ContactDetails> contactsSet = this._LoadContactsList();
			contactsSet.Remove(contact);
			this._SaveContactsList(contactsSet);
		}

		public IReadOnlyList<ContactDetails> GetList()
		{
			ISet<ContactDetails> contacts = this._LoadContactsList();
			return contacts.ToList();
		}

		private ISet<ContactDetails> _LoadContactsList()
		{
			ISet<ContactDetails> existingContacts = new HashSet<ContactDetails>();

			if (File.Exists(this._jsonFilePath))
			{
				string listOfContacts = File.ReadAllText(this._jsonFilePath);
				object value = JsonConvert.DeserializeObject<ISet<ContactDetails>>(listOfContacts);
				existingContacts =  value as ISet<ContactDetails>;
			}

			return existingContacts;
		}

		private void _SaveContactsList(ISet<ContactDetails> contacts)
		{
			string convertedObject = JsonConvert.SerializeObject(contacts);
			File.WriteAllText(this._jsonFilePath, convertedObject);
		}
	}
}