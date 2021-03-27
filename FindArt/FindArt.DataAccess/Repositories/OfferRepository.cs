using FindArt.Core.Interfaces.Repositories;
using FindArt.Core.Models;
using FindArt.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.DataAccess.Repositories
{
	public class OfferRepository : Repository<Offer>, IOfferRepository
	{
		public OfferRepository(FindArtDbContext repositoryContext) : base(repositoryContext)
		{
		}

		public async Task<IEnumerable<Offer>> GetAllOffersAsync(bool trackChanges) =>
			await FindAll(trackChanges)
			.ToListAsync();

		public async Task<Offer> GetOfferAsync(string id, bool trackChanges) =>
			await FindByCondition(o => o.OfferID.Equals(id), trackChanges)
			.SingleOrDefaultAsync();
	}
}
