using Microsoft.AspNetCore.Identity;

namespace FindArt.Core.Models
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
