using Contacts_Data.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Contacts_App.Api
{
	public class ContactsApi : IContactsApi
	{

		private const string ENDPOINT_ADD = "/Add";
		private const string ENDPOINT_DELETE = "/Delete";
		private const string ENDPOINT_GET_LIST = "";

		private readonly string _contactsEndpoint;

		public ContactsApi(string contactsEndpoint)
		{
			this._contactsEndpoint = contactsEndpoint;
		}

		public bool Add(ContactDetails contact)
		{
			using (RestClient client = new RestClient(this._contactsEndpoint + ENDPOINT_ADD))
			{
				RestRequest request = new RestRequest()
					.AddBody(
						JsonConvert.SerializeObject(contact),
						"application/json"
					);

				try
				{
					RestResponse response = client.PostAsync(request).GetAwaiter().GetResult();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
		}

		public void Delete(string email)
		{
			using (RestClient client = new RestClient(this._contactsEndpoint + ENDPOINT_DELETE))
			{
				RestRequest request = new RestRequest()
					.AddQueryParameter(
						"email",
						email
					);

				RestResponse response = client.DeleteAsync(request).GetAwaiter().GetResult();
			}
		}

		public IReadOnlyList<ContactDetails> GetList()
		{
			using (RestClient client = new RestClient(this._contactsEndpoint + ENDPOINT_GET_LIST))
			{
				RestRequest request = new RestRequest();
				RestResponse response = client.GetAsync(request).Result;

				if (response.StatusCode != HttpStatusCode.OK)
				{
					throw new Exception("Unable to get contatct list.");
				}

				string contactsList = response.Content;
				return JsonConvert.DeserializeObject<List<ContactDetails>>(contactsList);
			}
		}
	}
}