using System;
namespace SIS.Business.Exceptions
{
	public class UserCreateFailureException:Exception
	{
		public UserCreateFailureException(string message):base(message)
		{
		}
	}
}

