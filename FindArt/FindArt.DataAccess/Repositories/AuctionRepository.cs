using FindArt.Core.Interfaces.Repositories;
using FindArt.Core.Models;
using FindArt.Core.RequestFeatures;
using FindArt.DataAccess.Repositories.Base;
using FindArt.DataAccess.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindArt.DataAccess
{
	public class AuctionRepository : Repository<Auction>, IAuctionRepository
	{
		public AuctionRepository(FindArtDbContext repositoryContext) : base(repositoryContext)
		{
		}

		public async Task<PagedList<Auction>> GetAllAuctionsAsync(AuctionParameters auctionParameters, bool trackChanges)
		{
			var auctions = await FindByCondition(p => p.Active == auctionParameters.Active, trackChanges)
			.Sort(auctionParameters.OrderBy)
			.ToListAsync();

			return PagedList<Auction>
				.ToPagedList(auctions, auctionParameters.PageNumber, auctionParameters.PageSize);
		}


		public async Task<Auction> GetAuctionAsync(string id, bool trackChanges) =>
			await FindByCondition(p => p.AuctionID.Equals(id), trackChanges)
			.Include(p => p.Product)
			.SingleOrDefaultAsync();

		public void CreateAuction(Auction auction) => Create(auction);

		public void DeleteAuction(Auction auction) => Delete(auction);

		public void UpdateAuction(Auction auction) => Update(auction);
	}
}
