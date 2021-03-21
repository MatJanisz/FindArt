using FindArt.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindArt.DataAccess
{
	public class FindArtDbContext : IdentityDbContext<User>
	{
		public FindArtDbContext(DbContextOptions options)
        : base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}
