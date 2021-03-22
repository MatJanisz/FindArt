using FindArt.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.DataAccess.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> modelBuilder)
		{
			modelBuilder.HasKey(b => b.ID);
			modelBuilder.Property(b => b.Name).IsRequired();
			modelBuilder.Property(b => b.Description).IsRequired();

			//one to many relation between Product and User
			modelBuilder
				.HasOne(b => b.Owner)
				.WithMany(b => b.ProductsOnAuction)
				.HasForeignKey(b => b.OwnerID);

			//one to many relation between Product and ProductType
			modelBuilder
				.HasOne(b => b.ProductType)
				.WithMany(b => b.Products)
				.HasForeignKey(b => b.ProductTypeID);

		}
	}
}
