using FindArt.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindArt.DataAccess.Configuration
{
	public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
	{
		public void Configure(EntityTypeBuilder<Auction> modelBuilder)
		{
			modelBuilder.HasKey(b => b.AuctionID);
			modelBuilder.Property(b => b.DueDate).IsRequired();
			modelBuilder.Property(b => b.InitialPrice).IsRequired().HasColumnType("decimal(18,2)");

			//one to one relation between Auction and Product
			modelBuilder
				.HasOne(b => b.Product)
				.WithOne(b => b.Auction)
				.HasForeignKey<Auction>("ProductID");

		}
	}
}
