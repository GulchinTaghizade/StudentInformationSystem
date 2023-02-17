using System;
namespace SIS.Business.Exceptions
{
	public class RoleCreateFailureException:Exception
	{
		public RoleCreateFailureException(string message):base(message)
		{
		}
	}
}

