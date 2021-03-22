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
	class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
	{
		public void Configure(EntityTypeBuilder<ProductType> modelBuilder)
		{
			modelBuilder.HasKey(b => b.ProductTypeID);
			modelBuilder.HasData(
				Enum.GetValues(typeof(ProductTypeID))
					.Cast<ProductTypeID>()
					.Select(e => new ProductType()
					{
						ProductTypeID = e,
						Name = e.ToString()
					})
				);
		}
	}
}
