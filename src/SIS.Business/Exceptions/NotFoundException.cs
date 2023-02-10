using System;
namespace SIS.Business.Exceptions
{
	public class NotFoundException:Exception
	{
		public NotFoundException(string message):base(message)
		{
		}
	}
}

