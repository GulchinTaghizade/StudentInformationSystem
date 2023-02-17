using System;
using Microsoft.AspNetCore.Identity;

namespace SIS.Core.Entities.Identity
{
	public class AppUser:IdentityUser
	{
            public string? Fullname { get; set; }
	}
}

