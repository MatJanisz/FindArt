using FindArt.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindArt.DataAccess.Configuration
{
	public class OfferConfiguration : IEntityTypeConfiguration<Offer>
	{
		public void Configure(EntityTypeBuilder<Offer> modelBuilder)
		{
			modelBuilder.HasKey(b => b.OfferID);
			modelBuilder.Property(b => b.ProposedPrice).IsRequired().HasColumnType("decimal(18,2)");
			modelBuilder.Property(b => b.BeatenPrice).IsRequired().HasColumnType("decimal(18,2)");

			//one to many relation between Offer and Buyer
			modelBuilder
				.HasOne(b => b.Buyer)
				.WithMany(b => b.SubmittedOffers)
				.HasForeignKey(b => b.BuyerID);

			//one to many relation between Offer and Auction
			modelBuilder
				.HasOne(b => b.Auction)
				.WithMany(b => b.AuctionOffers)
				.HasForeignKey(b => b.AuctionID);
		}
	}
}
