using Contacts_Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contacts_App.Models
{
	public class ContactViewModel
	{
		public static ContactViewModel CreateFromDetails(ContactDetails contactDetails)
		{
			return new ContactViewModel
			{
				FirstName = contactDetails.FirstName,
				LastName = contactDetails.LastName,
				Email = contactDetails.Email,
				MobilePhone = contactDetails.MobilePhone,
				Address = contactDetails.Address,
			};
		}

		[Required(ErrorMessage = "First name is requiered")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is requiered")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email is requiered")]
		[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
		public string Email { get; set; }

		public string MobilePhone { get; set; }

		public string Address { get; set; }

		public ContactDetails ToContactDetails()
		{
			return new ContactDetails
			{
				FirstName = this.FirstName,
				LastName = this.LastName,
				Email = this.Email,
				MobilePhone = this.MobilePhone,
				Address = this.Address,
			};
		}

	}
}