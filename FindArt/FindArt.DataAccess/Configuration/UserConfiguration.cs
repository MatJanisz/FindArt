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
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> modelBuilder)
		{
			modelBuilder.HasKey(b => b.Id);
			modelBuilder.Property(b => b.Email).IsRequired();
		}
	}
}
