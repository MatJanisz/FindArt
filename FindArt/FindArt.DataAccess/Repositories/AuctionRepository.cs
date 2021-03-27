using FindArt.Core.Interfaces.Repositories;
using FindArt.Core.Models;
using FindArt.DataAccess.Repositories.Base;
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

		public async Task<IEnumerable<Auction>> GetAllAuctionsAsync(bool trackChanges) =>
			await FindAll(trackChanges)
			.OrderBy(a => a.DueDate)
			.ToListAsync();

		public async Task<Auction> GetAuctionAsync(string id, bool trackChanges) =>
			await FindByCondition(p => p.AuctionID.Equals(id), trackChanges)
			.Include(p => p.Product)
			.SingleOrDefaultAsync();

		public void AssignProductToAuction(string productID, string auctionID)
		{
			var auction = FindByCondition(p => p.AuctionID.Equals(auctionID), true).Single();
			auction.ProductID = productID;
			Update(auction);
		}
	}
}
