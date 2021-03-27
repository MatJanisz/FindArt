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

		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Auction> Auctions { get; set; }
		public DbSet<Offer> Offers { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new UserConfiguration());
			//modelBuilder.ApplyConfiguration(new RolesConfiguration());
			modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new AuctionConfiguration());
			modelBuilder.ApplyConfiguration(new OfferConfiguration());

		}
	}
}
