﻿using Contacts_Data.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_App.Api
{
	public class ContactsApi : IContactsApi
	{

		private const string ENDPOINT_ADD = "Add";
		private const string ENDPOINT_DELETE = "Delete";
		private const string ENDPOINT_GET_LIST = "";

		private readonly string _contactsEndpoint;

		public ContactsApi(string contactsEndpoint)
		{
			this._contactsEndpoint = contactsEndpoint;
		}

		public void Add(ContactDetails contact)
		{
			throw new NotImplementedException();
		}

		public void Delete(ContactDetails contact)
		{
			throw new NotImplementedException();
		}

		public IReadOnlyList<ContactDetails> GetList()
		{
			using (RestClient client = new RestClient(this._contactsEndpoint + ENDPOINT_GET_LIST))
			{
				RestRequest request = new RestRequest();
				RestResponse response = client.GetAsync(request).Result;

				string contactsList = response.Content;
				return JsonConvert.DeserializeObject<List<ContactDetails>>(contactsList);
			}
		}
	}
}