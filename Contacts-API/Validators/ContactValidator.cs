using Contacts_Data.Models;
using Contacts_Data.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Contacts_API.Validators
{
	public static class ContactValidator
	{
		public static bool IsInvalidContact(ContactDetails contact)
		{
			return
				contact == null
				|| string.IsNullOrEmpty(contact.FirstName)
				|| string.IsNullOrEmpty(contact.LastName)
				|| string.IsNullOrEmpty(contact.Email)
				|| BasicValidators.IsValidEmail(contact.Email) == false;
		}
	}
}