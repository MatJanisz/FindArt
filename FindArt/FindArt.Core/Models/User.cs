using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FindArt.Core.Models
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		//user's products on auction
		public List<Product> ProductsOnAuction { get; set; } //one-to-many
	}
}
