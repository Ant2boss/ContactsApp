using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Data.Models
{
	public class ContactDetails
	{
		[JsonProperty("firstname")]
		public string FirstName { get; set; }

		[JsonProperty("lastname")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("mobilephone")]
		public string MobilePhone { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		public override bool Equals(object obj)
		{
			return obj is ContactDetails details &&
				   Email == details.Email;
		}

		public override int GetHashCode()
		{
			return -506688385 + EqualityComparer<string>.Default.GetHashCode(Email);
		}
	}
}
