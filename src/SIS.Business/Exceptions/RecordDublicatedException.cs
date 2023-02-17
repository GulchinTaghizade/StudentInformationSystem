using System;
namespace SIS.Business.Exceptions
{
	public class RecordDublicatedException:Exception
	{
		public RecordDublicatedException(string message):base(message)
		{
		}
	}
}

