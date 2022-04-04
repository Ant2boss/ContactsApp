using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Contacts_Data.Validators
{
	public static class BasicValidators
	{
		public static bool IsValidEmail(string email)
		{
			return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
		}

		public static bool IsValidAddress(string address)
		{
			return Regex.IsMatch(address, @"[\w',-\\/.\s]");
		}
	}
}
