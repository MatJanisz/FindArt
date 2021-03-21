using FindArt.Core.Models;
using FindArt.DataAccess.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindArt.DataAccess
{
	public class FindArtDbContext : IdentityDbContext<User>
	{
		public FindArtDbContext(DbContextOptions options)
        : base(options) {}

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new UserConfiguration());
			//modelBuilder.ApplyConfiguration(new RolesConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());

		}
	}
}
