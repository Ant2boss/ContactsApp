using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Data.Exceptions
{
	public class DuplicateEmailException : Exception
	{
		public DuplicateEmailException() : this("Email aleready exists!")
		{
		}

		public DuplicateEmailException(string message) : base(message)
		{
		}
	}
}
